//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GeoQuiz.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kontinent
    {
        public Kontinent()
        {
            this.Drzava = new HashSet<Drzava>();
        }
    
        public byte SifraKontinent { get; set; }
        public string NazivKontinent { get; set; }
    
        public virtual ICollection<Drzava> Drzava { get; set; }
    }
}