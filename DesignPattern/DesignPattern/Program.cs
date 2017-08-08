using DesignPattern.CreationalPattern;
using DesignPattern.StructuralPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== Creational Pattern ================\n");
            #region CreationalPattern
            // BuilderPattern
            Console.WriteLine("______Builder Pattern_________");
            BuilderPattern.BuilderPatternDemo.BuilderPatternDemoFunc();
            #endregion
            Console.WriteLine("\n========= Structural Pattern ==============\n");
            #region StructuralPattern
            //AdapterPatter
            Console.WriteLine("______Adapter Pattern_________");
            AdapterPattern.AdapterPatternDemoClass.AdapterPatternFunc();
            #endregion
            Console.ReadKey();
        }
    }
}
