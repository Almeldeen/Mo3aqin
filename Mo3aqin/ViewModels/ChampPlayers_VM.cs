using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.ViewModels
{
    public class ChampPlayers_VM
    {
        public int ChampId { get; set; }
        public string ChampName { get; set; }
        public string GameIds { get; set; }
        public string Comptions { get; set; }
        public List<Player_VM> players { get; set; }
        public string PlayersIds { get; set; }
        public int[] PlayerschIds { get; set; }

    }
}
