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
    
    public partial class squadplayer
    {
        public int idSquadPlayer { get; set; }
        public int PlayersTeamFK { get; set; }
        public int FootballPlayerFK { get; set; }
        public int priority { get; set; }
    
        public virtual footballplayer footballplayer { get; set; }
        public virtual squad squad { get; set; }
    }
}
