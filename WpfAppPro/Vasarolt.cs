//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfAppPro
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vasarolt
    {
        public int Id { get; set; }
        public Nullable<int> Ki { get; set; }
        public Nullable<int> Milyent { get; set; }
        public Nullable<int> Ertek { get; set; }
    
        public virtual Berlet Berlet { get; set; }
        public virtual Ertek Ertek1 { get; set; }
        public virtual User User { get; set; }
    }
}
