using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Reflection_1
{
    class Program
    {
        private static int a = 5, b = 10, c = 20;

        static void Main(string[] args)
        {
            test0();
            test1();
            test2();
            test3();
        }

        static void test0()
        {
            Console.WriteLine("a + b + c = " + (a + b + c));
            Console.WriteLine("Please enter the name of the variable that you wish to change:");
            string varName = Console.ReadLine();
            Type t = typeof(Program);
            FieldInfo fieldInfo = t.GetField(varName, BindingFlags.NonPublic | BindingFlags.Static);
            if (fieldInfo != null)
            {
                Console.WriteLine("The current value of " + fieldInfo.Name + " is " + fieldInfo.GetValue(null) + ". You may enter a new value now:");
                string newValue = Console.ReadLine();
                int newInt;
                if (int.TryParse(newValue, out newInt))
                {
                    fieldInfo.SetValue(null, newInt);
                    Console.WriteLine("a + b + c = " + (a + b + c));
                }

                Console.ReadKey();
            }
        }

        static void test1()
        {
            string test = "test";
            Console.WriteLine(test.GetType().FullName);
            Console.WriteLine(typeof(Int32).FullName);

            Console.ReadKey();
        }

        static void test2()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] assemblyTypes = assembly.GetTypes();

            foreach (Type t in assemblyTypes)
                Console.WriteLine(t.Name);

            Console.ReadKey();
        }

        static void test3()
        {
            Type testType = typeof(TestClass);
            ConstructorInfo ctor = testType.GetConstructor(System.Type.EmptyTypes);
            if (ctor != null)
            {
                object instance = ctor.Invoke(null);
                MethodInfo methodInfo = testType.GetMethod("TestMethod");
                Console.WriteLine(methodInfo.Invoke(instance, new object[] { 10 }));
            }

            Console.ReadKey();
        }
    }

    class DummyClass
    {
        //Just here to make the output a tad less boring :)
    }

    public class TestClass
    {
        private int testValue = 42;

        public int TestMethod(int numberToAdd)
        {
            return this.testValue + numberToAdd;
        }
    }
}

