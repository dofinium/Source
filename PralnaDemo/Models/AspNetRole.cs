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
    
    public partial class AspNetRole
    {
        public AspNetRole()
        {
            this.AspNetUserRoles = new HashSet<AspNetUserRole>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
        public string RussianName { get; set; }
        public Nullable<int> IdAsInt { get; set; }
        public Nullable<bool> IsNotForUsers { get; set; }
    
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
    }
}
