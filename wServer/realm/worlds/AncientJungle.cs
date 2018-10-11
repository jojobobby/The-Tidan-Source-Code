using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class AncientJungle : World
    {
        public AncientJungle()
        {
            Name = "Ancient Jungle";
            ClientWorldName = "Ancient Jungle";
            Background = 0;
            Difficulty = 1;
            AllowTeleport = false;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.AncientJungle.jm", MapType.Json);
        }
    }
}