﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF_01
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HastaneSabahEntities : DbContext
    {
        public HastaneSabahEntities()
            : base("name=HastaneSabahEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bolumler> Bolumler { get; set; }
        public virtual DbSet<Doktorlar> Doktorlar { get; set; }
        public virtual DbSet<Hastalar> Hastalar { get; set; }
    }
}
