﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace XMCL.Core {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource1 {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource1() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("XMCL.Core.Resource1", typeof(Resource1).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   重写当前线程的 CurrentUICulture 属性
        ///   重写当前线程的 CurrentUICulture 属性。
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
        ///   查找 System.Byte[] 类型的本地化资源。
        /// </summary>
        internal static byte[] launcher_profiles {
            get {
                object obj = ResourceManager.GetObject("launcher_profiles", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   查找类似 [
        ///	{
        ///		&quot;url&quot;:&quot;https://bmclapi2.bangbang93.com/optifine/1.7.2/HD_U/F7&quot;,
        ///		&quot;name&quot;:&quot;OptiFine-1.7.2_HD_U_F7&quot;,
        ///		&quot;website&quot;:&quot;http://optifine.net/adloadx?f=OptiFine_1.7.2_HD_U_F7.jar&quot;,
        ///		&quot;R/P&quot;:&quot;Release&quot;,
        ///		&quot;time&quot;:&quot;2018.04.04&quot;
        ///	},
        ///	{
        ///		&quot;url&quot;:&quot;https://bmclapi2.bangbang93.com/optifine/1.7.10/HD_U/E7&quot;,
        ///		&quot;name&quot;:&quot;OptiFine-1.7.10_HD_U_E7&quot;,
        ///		&quot;website&quot;:&quot;http://optifine.net/adloadx?f=OptiFine_1.7.10_HD_U_E7.jar&quot;,
        ///		&quot;R/P&quot;:&quot;Release&quot;,
        ///		&quot;time&quot;:&quot;2018.04.04&quot;
        ///	},
        ///	{
        ///		&quot;url&quot;:&quot;https://bmclapi2.bangbang93.com/optif [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string OptifineList {
            get {
                return ResourceManager.GetString("OptifineList", resourceCulture);
            }
        }
    }
}
