//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server
{
    using System;
    using System.Collections.Generic;
    
    public partial class Servis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Servis()
        {
            this.Adresa_serv = new Adresa();
            this.Br_tel_serv = new Broj_telefona();
        }
    
        public int ID_servisa { get; set; }
        public string Naziv_serv { get; set; }
        public Tip_servisa Tip_serv { get; set; }
    
        public Adresa Adresa_serv { get; set; }
        public Broj_telefona Br_tel_serv { get; set; }
    }
}