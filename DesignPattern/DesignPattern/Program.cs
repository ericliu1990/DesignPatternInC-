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
            #region CreationalPattern
            // BuilderPattern
            BuilderPattern.BuilderPatternDemo.BuilderPatternDemoFunc();
            Console.WriteLine("\n====================================");
            AdapterPattern.AdapterPatternDemoClass.AdapterPatternFunc();
            #endregion
            Console.ReadKey();
        }
    }
}
