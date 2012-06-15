using System;
using MissileSharp;

namespace MissileSharp.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press <RETURN> to run the demo!");
            Console.ReadLine();

            using (var launcher = new CommandCenter(new ThunderMissileLauncher()))
            {
                if (launcher.IsReady)
                {
                    launcher.Reset();
                    launcher.Right(1000);
                    launcher.Up(500);
                    launcher.Fire(2);
                }
            }
        }
    }
}
