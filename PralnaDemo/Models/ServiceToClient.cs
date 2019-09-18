//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PralnaDemo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiceToClient
    {
        public ServiceToClient()
        {
            this.IsCallbackAllowed = true;
            this.FoundViolations = new HashSet<FoundViolation>();
        }
    
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int ServiceTypeId { get; set; }
        public short Value { get; set; }
        public string UniqueKey { get; set; }
        public Nullable<System.DateTime> ValueSet { get; set; }
        public bool IsCallbackAllowed { get; set; }
        public string ClientFeedback { get; set; }
        public Nullable<System.DateTime> Assigned { get; set; }
        public Nullable<System.DateTime> Started { get; set; }
        public Nullable<System.DateTime> Finished { get; set; }
        public string ClientId { get; set; }
    
        public virtual Worker Worker { get; set; }
        public virtual ServiceType ServiceType { get; set; }
        public virtual ICollection<FoundViolation> FoundViolations { get; set; }
        public virtual AspNetUser Client { get; set; }
    }
}
