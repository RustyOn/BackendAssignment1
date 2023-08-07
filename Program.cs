using BackendAssignment1.Namespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hero wizard = new Wizard("Leo");
            Console.WriteLine(wizard.Display()); 

        }
    }
}
