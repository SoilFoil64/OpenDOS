using System;
using System.Drawing;
using System.Text;
using Sys = Cosmos.System;

namespace OpenDOS
{
    public class Kernel : Sys.Kernel
    {

        string help =
@"CLS            Clears the screen.
ECHO           Displays messages.
SHUTDOWN       Shut down machine.
REBOOT         restart machine.
";
        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("OpenDOS v21.1\nThe Active Open Source DOS!\nEnter 'help' to begin.");
        }

        protected override void Run()
        {
            Console.Write("SHELL > ");
            var input = Console.ReadLine();
            if (input.ToLower().StartsWith("echo"))
            {
                // if user input is "echo.", only make a new line, just like regular batch
                if (input.ToLower().StartsWith("echo "))
                    Console.WriteLine(input.Replace("echo ", ""));
                else if (input == "echo.")
                    Console.WriteLine();
            }
            else if (input.ToLower() == "shutdown")
            {
                // shut down
                Cosmos.System.Power.Shutdown();
            }
            else if (input.ToLower() == "reboot")
            {
                // reboot
                Cosmos.System.Power.Reboot();
            }
            else if (input.ToLower() == "cls") { Console.Clear(); }
            else if (input.ToLower() == "help")
            {
                Console.WriteLine(help);
            }
            else
                Console.WriteLine("'" + input + "' is not a batch/OpenDOS command.");
        }
    }
}
