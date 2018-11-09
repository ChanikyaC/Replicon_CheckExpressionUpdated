using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            bool error = false;
            var expression = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            Stack<int> stackPosition = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(' || expression[i] == '{' || expression[i] == '[')
                {
                    stack.Push(expression[i]);
                    stackPosition.Push(i + 1);
                }
                else if (expression[i] == ')' || expression[i] == '}' || expression[i] == ']')
                {
                    if (stack.Peek() != CorrespondingOpenBracket(expression[i]))
                    {
                        error = true;
                        break;
                    }
                    stack.Pop();
                    stackPosition.Pop();
                }
            }

            if (error || stack.Count != 0)
            {
                Console.WriteLine("Invalid Expression. Character {0} at postion {1} is responsible", stack.Peek(), stackPosition.Peek());
            }
            else
                Console.WriteLine("Valid Expression");
            Console.ReadKey();
        }

        private static char CorrespondingOpenBracket(char item)
        {
            switch (item)
            {
                case ')':
                    return '(';
                case '}':
                    return '{';
                case ']':
                    return '[';
                default:
                    return ' ';
            }
        }
    }
}
