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
    
    public partial class WorkPlace
    {
        public WorkPlace()
        {
            this.Workers = new HashSet<Worker>();
            this.ServiceTypes = new HashSet<ServiceType>();
        }
    
        public int Id { get; set; }
        public int DivisionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual Division Division { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
        public virtual ICollection<ServiceType> ServiceTypes { get; set; }
    }
}
