using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class TempleServant : World
    {
        public TempleServant()
        {
            Name = "Temple Servant";
            ClientWorldName = "Temple Servant";
            Dungeon = true;
            Background = 0;
            Difficulty = 1;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.TempleServant.jm", MapType.Json);
        }
    }
}