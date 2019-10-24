using System;
using System.Collections.Generic;

namespace _4.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var a540Builder = new PlanetBuilderA540();

            var director = new PlanetBuildingDirector();
            director.PlanetBuilder = a540Builder;
            director.ProcessBuilding();

            var resultPlanet = a540Builder.GetResultPlanet();
            Console.WriteLine($"Result Planet: {resultPlanet}\n");

            var M820Builder = new PlanetBuilderM820();
            director.PlanetBuilder = M820Builder;
            director.ProcessBuilding();

            resultPlanet = M820Builder.GetResultPlanet();
            Console.WriteLine($"Result Planet: {resultPlanet}");


        }
    }

    #region UML Implementation

    class Client
    {
        void Main()
        {
            Builder builder = new ConcreteBuilder();
            Director director = new Director(builder);

            director.Build();
            Product product = builder.GetProduct();
        }
    }

    class Director
    {
        private readonly Builder _builder;
        public Director(Builder builder)
        {
            this._builder = builder;
        }

        public void Build()
        {
            _builder.StartBuilding();
            _builder.BuildingStages();
            _builder.FinishBuilding();
        }
    }


    abstract class Builder
    {
        public abstract void StartBuilding();
        public abstract void BuildingStages();
        public abstract void FinishBuilding();
        public abstract Product GetProduct();
    }

    class ConcreteBuilder : Builder
    {
        Product product = new Product();

        public override void StartBuilding()
        {
            product.Add("Part 1");
        }

        public override void BuildingStages()
        {
            product.Add("Part 2");
        }

        public  override void FinishBuilding()
        {
            product.Add("Part 3");
        }

        public override Product GetProduct()
        {
            return product;  
        }

    }

    class Product
    {
        List<object> parts = new List<object>();
        public void Add(string part)
        {
            parts.Add(part);
        }
    }


    #endregion

    #region Custom Implementation
    public class PlanetBuildingDirector
    {
       public PlanetBuilder PlanetBuilder { get; set; }
        public PlanetBuildingDirector() {}
        public PlanetBuildingDirector(PlanetBuilder builder)
        {
            PlanetBuilder = builder;
        }

        public void ProcessBuilding()
        {
            PlanetBuilder.ImaginePlanet();
            PlanetBuilder.CreatePlanet();
            PlanetBuilder.PlaceThePlanet();
        }

    }
    
    public abstract class PlanetBuilder
    {
        public abstract void ImaginePlanet();
        public abstract void CreatePlanet();
        public abstract void PlaceThePlanet();
    }

    
    public class PlanetBuilderA540 : PlanetBuilder
    {
        private Planet ResultPlanet = new Planet();
        private string Name = "A540";

        public override void CreatePlanet()
        {
            Console.WriteLine($"Builder-{Name} Creating Planet...");
            this.ResultPlanet.Name = $"{Name}-Planet";
        }

        public override void ImaginePlanet()
        {
            Console.WriteLine($"Builder-{Name} Imagining Planet...");
            this.ResultPlanet.Appearance = "Blue Planet";
        }

        public override void PlaceThePlanet()
        {
            Console.WriteLine($"Builder-{Name} Placing Planet...");
            this.ResultPlanet.Coordinates = "12h 51.4m+27.13°";
        }

        public Planet GetResultPlanet()
        {
            return this.ResultPlanet;
        }
    }


    public class PlanetBuilderM820 : PlanetBuilder
    {
        private Planet ResultPlanet = new Planet();
        private string Name = "M820";


        public override void CreatePlanet()
        {
            Console.WriteLine($"Builder-{Name} Creating Planet...");
            this.ResultPlanet.Name = $"{Name}-Planet";
        }

        public override void ImaginePlanet()
        {
            Console.WriteLine($"Builder-{Name} Imagining Planet...");
            this.ResultPlanet.Appearance = "Green Planet";
        }

        public override void PlaceThePlanet()
        {
            Console.WriteLine($"Builder-{Name} Creating Planet...");
            this.ResultPlanet.Coordinates = "06h 17.5m+39.18°";
        }

        public Planet GetResultPlanet()
        {
            return this.ResultPlanet;
        }
    }

    public class Planet
    {
        public string Name { get; set; }
        public string Appearance { get; set; }
        public string Coordinates { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Appearance} - {Coordinates}";
        }
    }
    #endregion
}
