﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DocumentGenerator.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.4.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Users\\Tom\\Desktop\\TestReportItems.xml")]
        public string testReportItemList {
            get {
                return ((string)(this["testReportItemList"]));
            }
            set {
                this["testReportItemList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Users\\Tom\\Documents\\TestReport.docx")]
        public string templateDoc {
            get {
                return ((string)(this["templateDoc"]));
            }
            set {
                this["templateDoc"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Generic.List<System.String> dataSourceTypes {
            get {
                return ((global::System.Collections.Generic.List<System.String>)(this["dataSourceTypes"]));
            }
            set {
                this["dataSourceTypes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ReportItemReader.XML.XMLReportItemReader, ReportItemReader.XML, Version=1.0.0.0, " +
            "Culture=neutral")]
        public string currentDataSourceType {
            get {
                return ((string)(this["currentDataSourceType"]));
            }
            set {
                this["currentDataSourceType"] = value;
            }
        }
    }
}
