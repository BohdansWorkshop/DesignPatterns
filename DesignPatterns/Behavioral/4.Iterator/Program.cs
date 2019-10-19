using System;
using System.Linq;

namespace _4.Iterator
{
    public class Program
    {
        static void Main()
        {
            var candles = new Candle[3]
            {
            new Candle(){Name = "Candle A"},
            new Candle(){Name ="Candle B"},
            new Candle(){Name = "Candle C"}
            };

            var reader = new CandleReader(candles);

            Console.WriteLine("Enumerate Data From Start");
            reader.ReadData();

            Console.WriteLine("\nEnumerate Data From End");
            reader.ReadDataFromEnd();

        }
    }

    public class CandleReader
    {
        public Candle[] _candles;
        public CandlesNumerator _numerator;
        public CandlesIterator _iterator;

        public CandleReader(Candle[] candles)
        {
            this._candles = candles;
            _numerator = new CandleCase(this._candles);
            _iterator = _numerator.CreateIterator();
        }

        public void ReadData()
        {
            while (_iterator.MoveNext())
            {
                Console.WriteLine(_iterator.Next().Name);
            }
        }

        public void ReadDataFromEnd()
        {
            this._numerator = new CandleCase(this._candles.Reverse().ToArray());
            _iterator = _numerator.CreateIterator();
            ReadData();
        }
    }


    public class Candle
    {
        public string Name { get; set; }
    }

    public class CandleCase : CandlesNumerator
    {
        public Candle[] _candles;

        public CandleCase(Candle[] candles)
        {
            this._candles = candles;
        }

        public Candle this[int index]
        {
            get { return _candles[index]; }
        }

        public int Count()
        {
            return _candles.Length;
        }

        public CandlesIterator CreateIterator()
        {
            return new CandleIterator(this);
        }
    }

    public class CandleIterator : CandlesIterator
    {
        CandlesNumerator _numerator;
        int index = 0;
        public CandleIterator(CandlesNumerator numerator)
        {
            this._numerator = numerator;
        }
        public bool MoveNext()
        {
            return index < _numerator.Count();
        }

        public Candle Next()
        {
            return _numerator[index++];
        }
    }


    public interface CandlesNumerator
    {
        Candle this[int index] { get; }
        int Count();
        CandlesIterator CreateIterator();
    }

    public interface CandlesIterator
    {
        Candle Next();
        bool MoveNext();
    }
}
