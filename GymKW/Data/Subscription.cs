//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GymKW.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subscription
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int SubscriptionTypeID { get; set; }
        public int Price { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
    
        public virtual SubscriptionType SubscriptionType { get; set; }
        public virtual User User { get; set; }
    }
}
