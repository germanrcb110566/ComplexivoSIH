//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class mPersona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mPersona()
        {
            this.mAuditoria = new HashSet<mAuditoria>();
            this.mCita = new HashSet<mCita>();
            this.mCita1 = new HashSet<mCita>();
            this.rMedico_Calendario = new HashSet<rMedico_Calendario>();
            this.rMedico_Especialidad = new HashSet<rMedico_Especialidad>();
            this.rRol_Persona = new HashSet<rRol_Persona>();
        }
    
        public int persona_id { get; set; }
        public int identificacion_tipo { get; set; }
        public string identificacion { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public System.DateTime fecha_nacimiento { get; set; }
        public string correo_electronico { get; set; }
        public int genero { get; set; }
        public int ciudad_residencia { get; set; }
        public int nacionalidad { get; set; }
        public string clave { get; set; }
        public bool estado { get; set; }
    
        public virtual Catalogo Catalogo { get; set; }
        public virtual Catalogo Catalogo1 { get; set; }
        public virtual Catalogo Catalogo2 { get; set; }
        public virtual Catalogo Catalogo3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mAuditoria> mAuditoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mCita> mCita { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mCita> mCita1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rMedico_Calendario> rMedico_Calendario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rMedico_Especialidad> rMedico_Especialidad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rRol_Persona> rRol_Persona { get; set; }
    }
}
