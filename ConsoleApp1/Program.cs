//INSTANT C# NOTE: Formerly VB project-level imports:
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System;
using System.Runtime.CompilerServices;

namespace ConsoleApp9
{
    internal static class Program
    {
        #region
        private static Func<int, (double x1, double x2)> A = ProductParamtersFood;
        private static Func<int, (double x1, double x2)> B = ProductParamtersBeverage;
        private static Func<int, (double x1, double x2)> C = ProductParamtersRawMaterial;
        private static Order R = new Order { OrderID = 10, ProductIndex = 100, Quantity = 20, UnitPrice = 4 };
        #endregion



        public static void Main(string[] args)
        {

            //var product = ProductType.Food;
            //Func<int, (double x1, double x2)> P = (product == ProductType.Food) ? A : ((product == ProductType.Beverage) ? B : C);
            //Console.WriteLine(ClaculateDiscount(P, R).ToString());
            //Console.ReadLine();


            #region
            Func<double, double> DlgtTest1 = Test1;
            Func<double, double> DlgtTest2 = Test2;
            List<Func<Double, Double>> z = new List<Func<Double, Double>>
            {
                DlgtTest1,
                DlgtTest2
            };

            Console.WriteLine(Test2(Test1(5)).ToString());
            Console.WriteLine(Test1(Test2(5)).ToString());

            Console.WriteLine(z[0](5).ToString());
            Console.WriteLine(z[1](5).ToString());

            Console.WriteLine(Test3(Test1, 5).ToString());
            Console.WriteLine(Test3(Test2, 5).ToString());

            Console.ReadLine();
            #endregion

        }

        #region
        public static double Test1(double x)
        {
            return x / 2;
        }

        public static double Test2(double x)
        {
            return x / 4 + 1;
        }


        public static double Test3(Func<double, double> F, Double Value)
        {
            return F(Value) + Value;
        }
        #endregion




        public static double ClaculateDiscount(Func<int, (double x1, double x2)> ProductParamterCalc, Order Order)
        {
            (double x1, double x2) paramters = ProductParamterCalc(Order.ProductIndex);
            return paramters.x1 * Order.Quantity + paramters.x2 * Order.UnitPrice;
        }


        public static (double x1, double x2) ProductParamtersFood(int ProductIndex)
        {
            return (x1:ProductIndex / (double)(ProductIndex + 100), x2:ProductIndex / (double)(ProductIndex + 300));

        }

        public static (double x1, double x2) ProductParamtersBeverage(int ProductIndex)
        {
            return (x1:ProductIndex / (double)(ProductIndex + 300), x2:ProductIndex / (double)(ProductIndex + 400));
        }

        public static (double x1, double x2) ProductParamtersRawMaterial(int ProductIndex)
        {
            return (x1:ProductIndex / (double)(ProductIndex + 400), x2:ProductIndex / (double)(ProductIndex + 700));
        }



        public enum ProductType
        {
            Food,
            Beverage,
            RawMaterial

        }

        public class Order
        {

            public int OrderID;
            public int ProductIndex;
            public double Quantity;
            public double UnitPrice;

        }
    }
}
