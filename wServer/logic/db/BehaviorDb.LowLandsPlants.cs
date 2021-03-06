﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ LowLandsPlants = () => Behav()
           .Init("Planted Carrot",
               new State(
               new StayCloseToSpawn(0.3, range: 7)
                ),
               new ItemLoot("Carrot's Revenge", 0.07),
               new ItemLoot("Carrot of Wisdom", 0.1)
            )
        .Init("Barrel Loot",
               new State(
               new StayCloseToSpawn(0.3, range: 7)
                ),
              new MostDamagers(4,
               new OnlyOne(
               new ItemLoot("Potion of Dexterity", 0.1),
               new ItemLoot("Potion of Defense", 0.4),
               new ItemLoot("Potion of Attack", 0.3),
               new ItemLoot("Potion of Vitality", 0.2)
              ),
               new Threshold(0.05,
                   new ItemLoot("Light Iron Boots", 0.04)


                   ))
            );
    }
}
