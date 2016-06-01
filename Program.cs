using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Principal;

namespace DirectorySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //WindowsIdentity currentIdentity = WindowsIdentity.GetCurrent();
            //WindowsPrincipal currentPrinciple = new WindowsPrincipal(currentIdentity);
            //if (currentPrinciple.IsInRole(WindowsBuiltInRole.Administrator))
            //{
            //    Console.WriteLine("Running in Administrator Mode");
            //}
            //else
            //{
            //    Console.WriteLine("Not an admin!");
            //}
            if (args.Length == 1)
            {
                if (args[0] == "/?")
                {
                    Console.WriteLine("DirectorySearch C:\\");
                    Console.WriteLine(args[0]);
                }
                else
                {
                    string[] folders = Directory.GetDirectories(args[0]);
                    if (folders.Length > 0)
                    {
                        DirSearch(args[0]);
                    }
                    else
                    {
                        Console.WriteLine("\n ----- [DIRECTORY] ----- " + args[0] + "\n");
                        foreach (string f in Directory.GetFiles(args[0]))
                        {
                            string file = System.IO.Path.GetFileName(f);
                            Console.WriteLine(file);
                        }
                    }
                    //Console.WriteLine("DirSearch " + args[0]);
                }
            }
            else
            {
                Console.WriteLine("Only 1 parameter is allowed");
            }
        }
        static void DirSearch(string sDir)
        {
            try
            {
                    foreach (string d in Directory.GetDirectories(sDir))
                    {
                        Console.WriteLine("\n ----- [DIRECTORY] ----- " + d + "\n");
                        try
                        {
                            foreach (string f in Directory.GetFiles(d))
                            {
                            string file = Path.GetFileName(f);
                                Console.WriteLine(file);
                            }
                        }
                        catch (Exception exc)
                        {
                            Console.Write("\n**********" + exc.Message + "**********\n");
                            continue;
                        }
                        DirSearch(d);
                    }
                }
            catch (Exception excep)
            {
                Console.WriteLine(excep.Message);
            }
        }
    }
}