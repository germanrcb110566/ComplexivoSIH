﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComplexivoSIH.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SIHEntities : DbContext
    {
        public SIHEntities()
            : base("name=SIHEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Catalogo> Catalogo { get; set; }
        public virtual DbSet<mAtencion> mAtencion { get; set; }
        public virtual DbSet<mAuditoria> mAuditoria { get; set; }
        public virtual DbSet<mCalendario> mCalendario { get; set; }
        public virtual DbSet<mCatalogo> mCatalogo { get; set; }
        public virtual DbSet<mCita> mCita { get; set; }
        public virtual DbSet<mParametros> mParametros { get; set; }
        public virtual DbSet<mPermisos> mPermisos { get; set; }
        public virtual DbSet<mPersona> mPersona { get; set; }
        public virtual DbSet<mTratamiento> mTratamiento { get; set; }
        public virtual DbSet<rMedico_Calendario> rMedico_Calendario { get; set; }
        public virtual DbSet<rMedico_Especialidad> rMedico_Especialidad { get; set; }
        public virtual DbSet<rRol_Persona> rRol_Persona { get; set; }
    }
}
