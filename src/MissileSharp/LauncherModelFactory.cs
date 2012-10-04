using System;
using System.Reflection;
using MissileSharp.Properties;

namespace MissileSharp
{
    /// <summary>
    /// Factory for loading an ILauncherModel by its name
    /// </summary>
    public class LauncherModelFactory
    {
        /// <summary>
        /// Loads the ILauncherModel with the given name
        /// </summary>
        /// <param name="className">The ILauncherModel class to load (syntax: Namespace.Class)</param>
        /// <param name="assemblyName">The name of the assembly (if the class is not in the MissileSharp assembly)</param>
        /// <returns></returns>
        public static ILauncherModel GetLauncher(string className, string assemblyName)
        {
            Type type;

            if (string.IsNullOrWhiteSpace(assemblyName))
            {
                type = Type.GetType(className);
            }
            else
            {
                Assembly assembly = Assembly.LoadFrom(assemblyName);
                type = assembly.GetType(className);
            }

            if (type == null)
            {
                throw new TypeLoadException(Resources.LauncherModelNotFound + className);
            }

            if (!typeof(ILauncherModel).IsAssignableFrom(type))
            {
                throw new ArgumentOutOfRangeException(string.Format(Resources.LauncherModelIsNotILauncherModel, className));
            }

            return (ILauncherModel)Activator.CreateInstance(type);
        }

        /// <summary>
        /// Loads the ILauncherModel with the given name
        /// </summary>
        /// <param name="className">The ILauncherModel class to load (syntax: Namespace.Class)</param>
        /// <returns></returns>
        public static ILauncherModel GetLauncher(string className)
        {
            return GetLauncher(className, null);
        }
    }
}
