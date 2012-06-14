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

            using (var launcher = new MissileLauncher(new ThunderMissileLauncher()))
            {
                launcher.Up(500);
            }
        }
    }
}
