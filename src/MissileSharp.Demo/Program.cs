using System;
using System.Collections.Generic;
using MissileSharp;

namespace MissileSharp.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MissileSharp demo application");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine();
            Console.WriteLine("This will move the missile launcher and fire 2 missiles.");
            Console.WriteLine();
            Console.WriteLine("Pick one of the following options (enter the number), then press <RETURN> to run the demo!");
            Console.WriteLine();
            Console.WriteLine("1 : The commands are executed directly");
            Console.WriteLine("2 : A pre-programmed sequence of commands is executed");
            Console.WriteLine("3 : same as 2, but the commands are loaded from a config file");
            Console.WriteLine();
            string choice = Console.ReadLine();
            Console.WriteLine();

            // instead of hardcoding the name, you could load it from a config file here
            var launcherModel = LauncherModelFactory.GetLauncher("MissileSharp.ThunderMissileLauncher");
            using (var launcher = new CommandCenter(launcherModel))
            {
                if (launcher.IsReady)
                {
                    switch (choice)
                    {
                        case "1":

                            Console.WriteLine("1. reset position (move to bottom left)");
                            launcher.Reset();

                            Console.WriteLine("2. turn right (1 second)");
                            launcher.Right(1000);

                            Console.WriteLine("3. move up (0.5 seconds)");
                            launcher.Up(500);

                            Console.WriteLine("4. fire 2 missiles");
                            launcher.Fire(2);

                            break;

                        case "2":

                            var commands = new List<LauncherCommand>();
                            commands.Add(new LauncherCommand(Command.Reset, 0));
                            commands.Add(new LauncherCommand(Command.Right, 1000));
                            commands.Add(new LauncherCommand(Command.Up, 500));
                            commands.Add(new LauncherCommand(Command.Fire, 2));

                            launcher.RunCommandSet(commands);

                            break;

                        case "3":

                            if (launcher.LoadCommandSets("settings.txt"))
                            {
                                // upper/lower case doesn't matter - "steve" or "sTeVe" would work as well
                                launcher.RunCommandSet("Steve");
                            }

                            break;

                    }
                }
            }
        }
    }
}
