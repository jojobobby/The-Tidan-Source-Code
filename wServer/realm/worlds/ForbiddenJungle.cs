﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class DragonsLair : World
    {
        public DragonsLair()
        {
            Name = "DragonsLair";
            ClientWorldName = "DragonsLair";
            Background = 0;
            Difficulty = 2;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.jungle.jm", MapType.Json);
        }
    }
}