//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shopping.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Offer
    {
        public int Offer_Id { get; set; }
        public Nullable<int> Manager_Id { get; set; }
        public Nullable<int> Customer_Id { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
