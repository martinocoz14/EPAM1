//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Camione
    {
        public string SerialNumber { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public short Year { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
