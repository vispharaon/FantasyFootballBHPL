//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ETA.FantasyFootbalBHPL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class squadstructure
    {
        public squadstructure()
        {
            this.season = new HashSet<season>();
        }
    
        public int idSquadStructure { get; set; }
        public int GK_min { get; set; }
        public int GK_max { get; set; }
        public int MF_min { get; set; }
        public int MF_max { get; set; }
        public int DEF_min { get; set; }
        public int DEF_max { get; set; }
        public int FW_min { get; set; }
        public int FW_max { get; set; }
    
        public virtual ICollection<season> season { get; set; }
    }
}
