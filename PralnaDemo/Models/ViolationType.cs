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
    
    public partial class ViolationType
    {
        public ViolationType()
        {
            this.AllowedViolations = new HashSet<AllowedViolation>();
            this.FoundViolations = new HashSet<FoundViolation>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrganizationId { get; set; }
    
        public virtual Organization Organization { get; set; }
        public virtual ICollection<AllowedViolation> AllowedViolations { get; set; }
        public virtual ICollection<FoundViolation> FoundViolations { get; set; }
    }
}
