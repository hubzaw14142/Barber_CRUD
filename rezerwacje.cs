//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class rezerwacje
    {
        public int id_rezerwacji { get; set; }
        public int id_klienta { get; set; }
        public Nullable<int> id_pracownika { get; set; }
        public Nullable<int> id_uslugi { get; set; }
        public System.DateTime data { get; set; }
        public System.TimeSpan godzina { get; set; }
    
        public virtual klienci klienci { get; set; }
        public virtual pracownicy pracownicy { get; set; }
        public virtual uslugi uslugi { get; set; }
    }
}
