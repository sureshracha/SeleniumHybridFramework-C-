﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestAutomation.TestData.Resource_Files {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class WorklistSummaryResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal WorklistSummaryResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TestAutomation.TestData.Resource_Files.WorklistSummaryResource", typeof(WorklistSummaryResource).Assembly);
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
        ///   Looks up a localized string similar to Self Pay Vendor.
        /// </summary>
        internal static string AccountBasedNonZeroWorklist {
            get {
                return ResourceManager.GetString("AccountBasedNonZeroWorklist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Claims - Pending Passed.
        /// </summary>
        internal static string ClaimBasedNonZeroWorklist {
            get {
                return ResourceManager.GetString("ClaimBasedNonZeroWorklist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        internal static string DBQueryforAllDataAccountsWorklist {
            get {
                return ResourceManager.GetString("DBQueryforAllDataAccountsWorklist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        internal static string DBQueryforAllDataClaimsWorklist {
            get {
                return ResourceManager.GetString("DBQueryforAllDataClaimsWorklist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///              count(DISTINCT CAST(wq.PatientVisitID AS varchar(20))+CAST(wq.OWNER AS varchar(10))+CAST(ISNULL(wq.ClaimID, 0) AS varchar(20))+pv.PatientVisitAccount) PatientVisitAccount
        ///                    , 
        ///                     ISNULL(sum(
        ///                    CASE 
        ///                           WHEN q.BalanceType = 1 THEN ft.CurrentAccountBalance
        ///                           WHEN q.BalanceType = 2 THEN ft.TXNCurrentBalance
        ///                           WHEN q.BalanceType = 3 THEN ce.ClaimAmount
        ///    [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string DBQueryforFIlteredDataAccountsWorklist {
            get {
                return ResourceManager.GetString("DBQueryforFIlteredDataAccountsWorklist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        internal static string DBQueryforFIlteredDataClaimsWorklist {
            get {
                return ResourceManager.GetString("DBQueryforFIlteredDataClaimsWorklist", resourceCulture);
            }
        }
    }
}