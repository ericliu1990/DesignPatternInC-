using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.CreationalPattern
{
    public class BuilderPattern
    {
        //Ref: https://www.tutorialspoint.com/design_pattern/builder_pattern.htm
        //Builder pattern builds a complex object using simple objects and using a step by step approach. 
        //This type of design pattern comes under creational pattern as this pattern provides one of the best ways to create an object.
        //A Builder class builds the final object step by step. This builder is independent of other objects.

        //a business case of fast-food restaurant where a typical meal could be a burger and a cold drink.

        public interface IItems
        {
            /// <summary>
            /// Name of the Item
            /// </summary>
            string ItemName();

            /// <summary>
            /// Price of a single Item
            /// </summary>
            double Price();
            /// <summary>
            /// Packing Method
            /// </summary>
            IPacking Packing
            {
                get;
            }
        }

        public interface IPacking
        {
            /// <summary>
            /// Packing Method
            /// </summary>
            string Pack
            {
                get;
            }
        }

        public class Warpper : IPacking
        {
            public string Pack
            {
                get;
                private set;
            }
            public Warpper()
            {
                this.Pack = "Warpping";
            }
        }

        public class Bottle : IPacking
        {
            public string Pack
            {
                get;
                private set;
            }
            public Bottle()
            {
                this.Pack = "Bottle";
            }
        }

        public abstract class Burger : IItems
        {
            public IPacking Packing 
            {
                get;
                private set;
            }

            public virtual double Price()
            {
                return 0.0;
            }

            public virtual string ItemName()
            {
                return null;
            }

            public Burger()
            {
                this.Packing = new Warpper();
            }

        }

        public abstract class ColdDrink : IItems
        {
            public IPacking Packing 
            {
                get;
                private set;
            }

            public virtual double Price()
            {
                return 0.0;
            }

            public virtual string ItemName()
            {
                return null;
            }

            public ColdDrink()
            {
                this.Packing = new Bottle();
            }
        }

        public class VegBurger : Burger 
        {
            public override string ItemName()
            {
                return "VegBurger";
            }
            public override double Price()
            {
                return 10.5;
            }
        }

        public class ChickenBurger : Burger
        {
            public override string ItemName()
            {
                return "ChickenBurger";
            }
            public override double Price()
            {
                return 13.5;
            }
        }

        public class Coke : ColdDrink
        {
            public override string ItemName()
            {
                return "Coke";
            }
            public override double Price()
            {
                return 3.0;
            }
        }

        public class Pepsi : ColdDrink
        {
            public override string ItemName()
            {
                return "Pepsi";
            }
            public override double Price()
            {
                return 2.5;
            }
        }

        public class Meal
        {
            private List<IItems> ItemList = new List<IItems>();

            public void AddItem(IItems item)
            {
                ItemList.Add(item);
            }

            public double GetCost()
            {
                double TotalPrice = 0;
                foreach (IItems item in ItemList)
                {
                    TotalPrice += item.Price();
                }
                return TotalPrice;
            }

            public void ShowItems()
            {
                foreach (IItems item in ItemList)
                {
                    Console.WriteLine(String.Format("Item Name:{0}",item.ItemName()));
                    Console.WriteLine(String.Format("Item Packing:{0}", item.Packing.Pack));
                    Console.WriteLine(String.Format("Item Price:{0}", item.Price()));
                }
            }
        }

        public class MealBuilder
        {
            public Meal PrepareVegMeal()
            {
                Meal VegMeal = new Meal();
                VegMeal.AddItem(new VegBurger());
                VegMeal.AddItem(new Coke());
                return VegMeal;
            }

            public Meal PrepareChickenMeal()
            {
                Meal ChickenMeal = new Meal();
                ChickenMeal.AddItem(new ChickenBurger());
                ChickenMeal.AddItem(new Pepsi());
                return ChickenMeal;
            }
        }

        public class BuilderPatternDemo
        {
            public static void BuilderPatternDemoFunc()
            {
                MealBuilder VegMealBuilder = new MealBuilder();
                Meal vegMeal = VegMealBuilder.PrepareVegMeal();
                Console.WriteLine("VegMeal");
                vegMeal.ShowItems();
                Console.WriteLine(string.Format("TotalCost:{0}",vegMeal.GetCost()));

                Console.WriteLine("\n-----------------------------------------------\n");

                MealBuilder ChickenMealBuilder = new MealBuilder();
                Meal chickenMeal = ChickenMealBuilder.PrepareChickenMeal();
                Console.WriteLine("ChickenMeal");
                chickenMeal.ShowItems();
                Console.WriteLine(string.Format("TotalCost:{0}", chickenMeal.GetCost()));
            }
        }

    }
}
