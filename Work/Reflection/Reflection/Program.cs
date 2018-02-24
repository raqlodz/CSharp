using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        public static int gwint = 1;
        public static decimal decymetr = 2.6M;
        public static string pstrong = "ala";
        public static bool bulin = true;
        public static int Propertas { get; set; }

        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] assemblyTypes = assembly.GetTypes();

            foreach (Type assemblyType in assemblyTypes)
            {
                Console.WriteLine(assemblyType.Name);

                FieldInfo[] fields = assemblyType.GetFields();
                foreach (FieldInfo field in fields)
                    Console.WriteLine("Field Name = {0}, Field Type = {1}, Field Value = {2}, Field Attribures = {3}", 
                        field.Name, field.FieldType, field.GetValue(null), field.Attributes);

                PropertyInfo[] properties = assemblyType.GetProperties();
                foreach (PropertyInfo property in properties)
                    Console.WriteLine("Property Name = {0}, Property Type = {1}, Property Value = {2}, Property Attributes = {3}", 
                        property.Name, property.PropertyType, property.GetValue(null), property.Attributes);

                MethodInfo[] methods = assemblyType.GetMethods();
                foreach (MethodInfo method in methods)
                    Console.WriteLine("Method Name = {0}, Method ReturnType = {1}, Method Attributes = {2}", 
                        method.Name, method.ReturnType, method.Attributes);
            }

            Console.ReadKey();
        }
    }

    class DummyClass1
    {
        public static int inttest1 = 21;
        public static double doubletest1;
        public static string s;
        public int test1()
        {
            return 0;
        }
    }

    class DummyClass2
    {
        public static byte bytetest2 = 255;
        public static int inttest2 = 44;
        public bool test2a (int a)
        {
            return true;
        }
    }
}
