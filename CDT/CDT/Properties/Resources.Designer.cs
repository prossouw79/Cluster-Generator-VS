﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CDT.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
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
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CDT.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to #componentName:componentCost:componentTDP:frequencyMhz:instructionsPerCycle:numOfCores:Hyperthreaded(Y/N)
        ///Intel Core i3 4370:146:54:3800:16:2:N
        ///Intel Core i3 4150:120:35:3500:16:2:N
        ///Intel Core i5 4460:188:84:3200:16:4:N
        ///Intel Core i5 4690:222:84:3500:16:4:N
        ///Intel Core i7 4790:302:84:3600:16:8:Y
        ///Intel Core i7 5960X:1045:140:3000:16:8:Y
        ///Intel Xeon E5-2637 v2:1391:130:3500:8:8:Y
        ///Intel Xeon E5-2690 v2:2669:130:3000:16:10:Y
        ///AMD FX 8370:200:125:4000:8:8:N
        ///AMD FX 9370:210:220:4400:8:8:N
        ///AMD FX 9590:240: [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string cpus {
            get {
                return ResourceManager.GetString("cpus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #componentName:componentCost:componentTDP:vramGB:sfpTFLOPS:dfpTFLOPS
        ///Nvidia GTX 980 Ti:680:250:6:5.60:1.87
        ///Nvidia Titan X:1030:250:12:6.10:2.04
        ///AMD Fury X2:1850:375:8:17.10:5.72
        ///AMD R9 295X2:1450:450:8:11.40:3.81
        ///Nvidia Tesla K40:3200:245:12:4.29:1.43
        ///Nvidia Tesla K80:4950:300:24:5.60:1.87
        ///AMD FirePro S9050:1600:225:12:3.23:0.81
        ///AMD FirePro S9150:3040:235:16:10.14:2.53
        ///#.
        /// </summary>
        internal static string gpus {
            get {
                return ResourceManager.GetString("gpus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #componentName:componentCost:componentTDP:capacityGB:frequencyMhz
        ///Kingston DDR3 Unbuffered SM:57:4:8:1600
        ///Kingston DDR3 Unbuffered SM:116:5:16:1600
        ///Kingston DDR3 Unbuffered SM:126:6:16:1866
        ///Kingston DDR3 Unbuffered SM:346:8:32:1866
        ///Crucial DDR3 ECC Registered SM:49:3:4:1866
        ///Axiom DDR3 ECC Registered SM:119:4:8:1866
        ///Hynix DDR3 ECC Registered SM:90:4:8:1866
        ///Samsung DDR3 Unbuffered SM:360:6:32:1866
        ///Nemix DDR3 ECC Registered SM:489:10:32:2133
        ///#.
        /// </summary>
        internal static string mems {
            get {
                return ResourceManager.GetString("mems", resourceCulture);
            }
        }
    }
}
