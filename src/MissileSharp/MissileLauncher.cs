
namespace MissileSharp
{
    public class MissileLauncher
    {
        ILauncherDevice launcher;

        public MissileLauncher(ILauncherDevice launcher)
        {
            this.launcher = launcher;
        }
    }
}
