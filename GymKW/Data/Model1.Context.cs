﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GYMKWEntities : DbContext
    {
        public GYMKWEntities()
            : base("name=GYMKWEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Coach> Coach { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<SubscriptionType> SubscriptionType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Workout> Workout { get; set; }
        public virtual DbSet<WorkoutGoal> WorkoutGoal { get; set; }
    }
}
