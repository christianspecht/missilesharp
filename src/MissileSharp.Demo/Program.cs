using System;
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
            Console.WriteLine("Press <RETURN> to run the demo!");
            Console.ReadLine();
            Console.WriteLine();

            using (var launcher = new CommandCenter(new ThunderMissileLauncher()))
            {
                if (launcher.IsReady)
                {
                    Console.WriteLine("1. reset position (move to bottom left)");
                    launcher.Reset();

                    Console.WriteLine("2. turn right (1 second)");
                    launcher.Right(1000);

                    Console.WriteLine("3. move up (0.5 seconds)");
                    launcher.Up(500);

                    Console.WriteLine("4. fire 2 missiles");
                    launcher.Fire(2);
                }
            }
        }
    }
}
