﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace newbarbershop
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class barbershopEntities : DbContext
    {
        public barbershopEntities()
            : base("name=barbershopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<grafik> grafik { get; set; }
        public virtual DbSet<klienci> klienci { get; set; }
        public virtual DbSet<pracownicy> pracownicy { get; set; }
        public virtual DbSet<rezerwacje> rezerwacje { get; set; }
        public virtual DbSet<uslugi> uslugi { get; set; }
    }
}
