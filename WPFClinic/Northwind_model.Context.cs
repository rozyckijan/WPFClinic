﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFClinic
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class projektjimmyEntities : DbContext
    {
        public projektjimmyEntities()
            : base("name=projektjimmyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<choroba> chorobas { get; set; }
        public virtual DbSet<cza> czas { get; set; }
        public virtual DbSet<lekarz> lekarzs { get; set; }
        public virtual DbSet<pacjent> pacjents { get; set; }
        public virtual DbSet<recepta> receptas { get; set; }
        public virtual DbSet<wizyty> wizyties { get; set; }
    }
}
