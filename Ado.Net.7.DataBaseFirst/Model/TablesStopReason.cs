//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ado.Net._7.DataBaseFirst.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TablesStopReason
    {
        public int intStopReason { get; set; }
        public string strReason { get; set; }
        public bool bitDowntime { get; set; }
        public bool bitUnscheduled { get; set; }
        public bool bitPMStoppages { get; set; }
        public bool bitScheduledRepairsAndOther { get; set; }
        public int intLocationId { get; set; }
    }
}
