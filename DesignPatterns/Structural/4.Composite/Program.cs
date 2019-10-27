using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileManager = new Directory("FileManager");

            var discC = new Directory("Local disc C");
            var discD = new Directory("Local disc D");

            var image = new File("Image.png");
            discC.Add(image);


            var wordDocument = new File("Report.docx");
            discD.Add(wordDocument);


            fileManager.Add(discC);
            fileManager.Add(discD);


            fileManager.CurrentDirectory();

            discC.CurrentDirectory();
            discD.CurrentDirectory();
        }
    }

    #region UML Implementation
    class Client
    {
        public void Main()
        {
            Component root = new Composite("Root");
            Component leaf = new Leaf("Leaf");
            Composite subtree = new Composite("Subtree");
            root.Add(leaf);
            root.Add(subtree);
            root.Display();
        }
    }

    abstract class Component
    {
        protected string Name { get; set; }
        public Component(string name)
        {
            this.Name = name;
        }
       public abstract void Add(Component component);
       public abstract void Remove(Component component);
       public abstract void Display(); 
    }

    class Composite : Component
    {
        List<Component> components = new List<Component>();

        public Composite(string name) : base(name) {}
        public override void Add(Component component)
        {
            components.Add(component);
        }

        public override void Remove(Component component)
        {
            component.Remove(component);
        }

        public override void Display()
        {
            Console.WriteLine(this.Name);
            foreach(var component in components)
            {
                component.Display();
            }
        }
    }

    class Leaf : Component
    {
        //Anyway we using instance of Component class, so we don't need to implement anything here, 
        //because we will use Leaf as Component class inside Composite instance, where all the functionality is implemented already
        public Leaf(string name) : base(name){}
        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Display()
        {
            Console.WriteLine(this.Name);
        }

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }
    }


    #endregion

    #region Custom Implementation
    public abstract class FileSystemComponent
    {
        public abstract string Name { get; set; }

        public abstract void Add(FileSystemComponent component);
        public abstract void Remove(FileSystemComponent component);
        public abstract void Rename(FileSystemComponent component, string newName);

        public virtual void CurrentDirectory()
        {
            Console.WriteLine($"{Name}");
        }
    }

    public class Directory : FileSystemComponent
    {
        List<FileSystemComponent> _localComponents = new List<FileSystemComponent>();
        public override string Name { get; set; }

        public Directory(string name)
        {
            Name = name;
        }

        public override void Add(FileSystemComponent component)
        {
            _localComponents.Add(component);
        }

        public override void Remove(FileSystemComponent component)
        {
            _localComponents.Remove(component);
        }

        public override void Rename(FileSystemComponent component, string newName)
        {
            var oldComponent = _localComponents.FirstOrDefault(x => x == component);
            oldComponent.Name = newName;
            
            _localComponents[_localComponents.IndexOf(component)] =  oldComponent;
        }

        public override void CurrentDirectory()
        {
            Console.WriteLine($"Current directory is: {this.Name}");
            foreach (var item in _localComponents)
            {
                Console.WriteLine(item.Name);
            }
        }

    }


    public class File : FileSystemComponent
    {
        public override string Name { get; set; }

        public File(string name)
        {
            Name = name;
        }

        public override void Add(FileSystemComponent component){}

        public override void Remove(FileSystemComponent component){}

        public override void Rename(FileSystemComponent component, string newName) {}
    }
    #endregion
}
