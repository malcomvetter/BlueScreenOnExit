using System;
using System.Security.Principal;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!isAdmin())
            {
                Console.WriteLine("Go away user. Come back with your admin.");
                Console.ReadLine();
                return;
            }
            ProcessProtection.ProcessProtection.Protect();
            Console.WriteLine("I'm a protected process, try to kill me.");
            Console.ReadLine();
            ProcessProtection.ProcessProtection.Unprotect();
            Console.WriteLine("Whew! It's safe now.");
        }

        private static bool isAdmin()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
