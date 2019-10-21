using System;

namespace _1.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            FieldSingleton.Instance.DoWork();

            LazyFieldSingleton.Instance.DoWork();

            DoubleLockSingleton.Instance.DoWork();

            NestedClassSingleton.Instance.DoWork();
        }
    }


    sealed class FieldSingleton
    {
        private static readonly FieldSingleton _instance = new FieldSingleton();
        public static FieldSingleton Instance => _instance;

        public void DoWork()
        {
            Console.WriteLine("Field Singleton works fine.");
        }
    }


    sealed class LazyFieldSingleton
    {
        private static readonly Lazy<LazyFieldSingleton> _instance = new Lazy<LazyFieldSingleton>(() => new LazyFieldSingleton());
        public static LazyFieldSingleton Instance { get { return _instance.Value; } }


        public void DoWork()
        {
            Console.WriteLine("Lazy Field Singleton works good");
        }
    }


    sealed class DoubleLockSingleton
    {
        //Attention, volatile means that compiler is restricted to modify or making changes in process of initialization and work of _instance
        //Also it means that it cannot be cached and all calls to this instance will be addressed to it's default(initial) address (memory at motherboard, not cache)
        private static volatile DoubleLockSingleton _instance;
        private static readonly object _duck = new object();

        public static DoubleLockSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_duck)
                    {
                        if (_instance == null)
                        {
                            _instance = new DoubleLockSingleton();
                        }
                    }
                }
                return _instance;
            }
        }

        public void DoWork()
        {
            Console.WriteLine("Double Locked Singleton works perfect");
        }
    }


    sealed class NestedClassSingleton
    {
        public static NestedClassSingleton Instance
        {
            //here's our lazy loading because of nested class;
            get { return SingletonHolder._instance; }
        }

        public void DoWork()
        {
            Console.WriteLine("Nested class singleton works awesome");
        }

        private static class SingletonHolder
        {
            public static readonly NestedClassSingleton _instance = new NestedClassSingleton();
        }
    }

}
