﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsApp.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ConsApp.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        ///   Looks up a localized string similar to is created.
        /// </summary>
        internal static string Created {
            get {
                return ResourceManager.GetString("Created", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to is deleted.
        /// </summary>
        internal static string Deleted {
            get {
                return ResourceManager.GetString("Deleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File with this name already exists - create another file.
        /// </summary>
        internal static string existingFile {
            get {
                return ResourceManager.GetString("existingFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File.
        /// </summary>
        internal static string File {
            get {
                return ResourceManager.GetString("File", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The rule is found and this file is moved to &quot;TargetFolder&quot; directory.
        /// </summary>
        internal static string foundRule {
            get {
                return ResourceManager.GetString("foundRule", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The rule isn&apos;t found and this file is moved to &quot;DefaultFolder&quot; directory.
        /// </summary>
        internal static string notFoundRule {
            get {
                return ResourceManager.GetString("notFoundRule", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This program is watching a &quot;WatcherFolder&quot; directory for files: .txt, .docx, .rar and if they are found they will be removed to &quot;TargetFolder&quot; directory, any other files will be removed to &quot;DefaultFolder&quot; directory..
        /// </summary>
        internal static string programGoal {
            get {
                return ResourceManager.GetString("programGoal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Press q to quit the Program.
        /// </summary>
        internal static string toExit {
            get {
                return ResourceManager.GetString("toExit", resourceCulture);
            }
        }
    }
}
