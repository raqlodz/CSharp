using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree1
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, int, int>> expression = (a, b) => a * b;

            Console.WriteLine(expression.Type);
            Console.WriteLine(expression.NodeType);
            Console.WriteLine(expression.ReturnType);

            for (int i = 0; i < expression.Parameters.Count; i++)
            {
                ParameterExpression parameter = expression.Parameters[i];
                Console.WriteLine("{0} {1}:, Name: {2}, Type: {3}", parameter.NodeType, i, parameter.Name, parameter.Type);   
            }

            Expression body = expression.Body;
            Console.WriteLine("Body: {0}, Node Type: {1}, Type: {2}", body, body.NodeType, body.Type);

            BinaryExpression bodybin = (BinaryExpression)body;
            ParameterExpression left = (ParameterExpression)bodybin.Left;
            ParameterExpression right = (ParameterExpression)bodybin.Right;
         
            Console.WriteLine("Left {0} Name: {1}, Type: {2}", left.NodeType, left.Name, left.Type);
            Console.WriteLine("Right {0} Name: {1}, Type: {2}", right.NodeType, right.Name, right.Type);
                        
            Console.ReadKey();
        }
    }
}
