using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI_ConsoleApplication
{

    class Program
    {
        static BL.IBL bl;

        static Program()
        {
            bl = BL.FactoryBl.getBl();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                getUserValue();
            }
        }

        private static void getUserValue()
        {
            string valueStr;
            int value = 0;
            bool valid = false;

            Console.WriteLine("enter your value: ");
            while (!valid)
            {
                valueStr = Console.ReadLine();
                try
                {
                    value = int.Parse(valueStr);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("err: \n UI Exception: please enter some number ...");
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("err: \n UI Exception: please enter only number value...");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("err: \n UI Exception: please enter a valid number value...");
                    continue;
                }
                valid = true;
            }

            try
            {
                bl.InsertValue(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("err: \n UI Exception: " + ex.GetType() + ": " + ex.Message);
                Console.WriteLine(ex);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
