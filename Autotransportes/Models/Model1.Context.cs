﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Autotransportes.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Basis> Bases { get; set; }
        public virtual DbSet<Camione> Camiones { get; set; }
        public virtual DbSet<Conductore> Conductores { get; set; }
        public virtual DbSet<Gasolinera> Gasolineras { get; set; }
        public virtual DbSet<GastosViaje> GastosViajes { get; set; }
        public virtual DbSet<Ruta> Rutas { get; set; }
        public virtual DbSet<Viaje> Viajes { get; set; }
    }
}