using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MissileSharp.Launcher.Services
{
    public interface IAppConfigService
    {
        string LauncherName { get; }
        string LauncherAssembly { get; }
    }
}
