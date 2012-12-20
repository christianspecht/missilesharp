using System.Diagnostics;
using System.Reflection;

namespace MissileSharp.Launcher.ViewModels
{
    public class AboutWindowViewModel : BaseViewModel
    {
        private FileVersionInfo info;

        public AboutWindowViewModel()
        {
            this.info = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
        }

        public string VersionNumber
        {
            get { return this.info.ProductName + " " + this.info.FileVersion; }
        }

        public string CopyRight
        {
            get { return this.info.LegalCopyright; }
        }
    }
}
