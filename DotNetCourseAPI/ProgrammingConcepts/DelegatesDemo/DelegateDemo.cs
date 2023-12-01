using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCourseAPI.ProgrammingConcepts.DelegatesDemo
{
    public delegate void AddDelegate(int a, int b);
    public delegate string GreetDelegate(string name);
    public class DelegateDemo
    {
        public void AddNums(int a, int b)
        {
            Console.WriteLine($"Sum : {a+b}");
        }

        public static string GreetUser(string name)
        {
            return "Hello " + name;
        }

    }
}
