﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.269
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MissileSharp.Properties {
    using System;
    
    
    /// <summary>
    ///   Eine stark typisierte Ressourcenklasse zum Suchen von lokalisierten Zeichenfolgen usw.
    /// </summary>
    // Diese Klasse wurde von der StronglyTypedResourceBuilder automatisch generiert
    // -Klasse über ein Tool wie ResGen oder Visual Studio automatisch generiert.
    // Um einen Member hinzuzufügen oder zu entfernen, bearbeiten Sie die .ResX-Datei und führen dann ResGen
    // mit der /str-Option erneut aus, oder Sie erstellen Ihr VS-Projekt neu.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Gibt die zwischengespeicherte ResourceManager-Instanz zurück, die von dieser Klasse verwendet wird.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MissileSharp.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Überschreibt die CurrentUICulture-Eigenschaft des aktuellen Threads für alle
        ///   Ressourcenzuordnungen, die diese stark typisierte Ressourcenklasse verwenden.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die command is empty ähnelt.
        /// </summary>
        internal static string CommandEmpty {
            get {
                return ResourceManager.GetString("CommandEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die command must be one of the following: up, down, left, right, reset, fire ähnelt.
        /// </summary>
        internal static string CommandMustBeOneOfFollowing {
            get {
                return ResourceManager.GetString("CommandMustBeOneOfFollowing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die command set name is empty ähnelt.
        /// </summary>
        internal static string CommandSetNameEmpty {
            get {
                return ResourceManager.GetString("CommandSetNameEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die &quot;device&quot; parameter is null! ähnelt.
        /// </summary>
        internal static string DeviceIsNull {
            get {
                return ResourceManager.GetString("DeviceIsNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die The first line in the config must be a command set name. There can be no commands before the first command set name! ähnelt.
        /// </summary>
        internal static string FirstLineMustBeCommandSetName {
            get {
                return ResourceManager.GetString("FirstLineMustBeCommandSetName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die &quot;launcher&quot; parameter is null! ähnelt.
        /// </summary>
        internal static string LauncherIsNull {
            get {
                return ResourceManager.GetString("LauncherIsNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Launcher model &apos;{0}&apos; does not implement interface ILauncherModel ähnelt.
        /// </summary>
        internal static string LauncherModelIsNotILauncherModel {
            get {
                return ResourceManager.GetString("LauncherModelIsNotILauncherModel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die No launcher model with this name available:  ähnelt.
        /// </summary>
        internal static string LauncherModelNotFound {
            get {
                return ResourceManager.GetString("LauncherModelNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die This line in the config file does not contain exactly two items:  ähnelt.
        /// </summary>
        internal static string LineDoesNotContainTwoItems {
            get {
                return ResourceManager.GetString("LineDoesNotContainTwoItems", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die No command sets available. You need to load them first using the LoadCommandSets method! ähnelt.
        /// </summary>
        internal static string NoCommandSets {
            get {
                return ResourceManager.GetString("NoCommandSets", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die The second item in this line in the config file must be numeric:  ähnelt.
        /// </summary>
        internal static string SecondItemMustBeNumeric {
            get {
                return ResourceManager.GetString("SecondItemMustBeNumeric", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die value must be equal or greater than zero ähnelt.
        /// </summary>
        internal static string ValueMustBeEqualGreaterZero {
            get {
                return ResourceManager.GetString("ValueMustBeEqualGreaterZero", resourceCulture);
            }
        }
    }
}
