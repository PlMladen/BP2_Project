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
    
    public partial class Vlasnik_racunara
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vlasnik_racunara()
        {
            this.Posjeduje = new HashSet<Posjeduje>();
            this.Adresa_vl = new Adresa();
        }
    
        public long JMBG_vl { get; set; }
        public string Ime_vl { get; set; }
        public string Prezime_vl { get; set; }
        public System.DateTime Dat_rodjenja_vl { get; set; }
    
        public Adresa Adresa_vl { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Posjeduje> Posjeduje { get; set; }
    }
}
