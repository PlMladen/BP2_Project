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
    
    public partial class Komponenta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Komponenta()
        {
            this.Sastoji_se = new HashSet<Sastoji_se>();
            this.Sastoji_se1 = new HashSet<Sastoji_se>();
        }
    
        public int Id_komp { get; set; }
        public string Naz_komp { get; set; }
        public double Cijena_komp { get; set; }
        public Nullable<int> RacunarID_racunara { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sastoji_se> Sastoji_se { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sastoji_se> Sastoji_se1 { get; set; }
        public virtual Racunar Racunar { get; set; }
    }
}
