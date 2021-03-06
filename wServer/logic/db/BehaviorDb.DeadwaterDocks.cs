﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ DeadwaterDocks = () => Behav()
              .Init("Deadwater Docks Parrot",
                  new State(
                    new EntityNotExistsTransition("Jon Bilgewater the Pirate King", 90000, "rip"),
                    new State("CircleOrWander",
                        new Prioritize(
                            new Orbit(0.55, 2, 5, "Parrot Cage"),
                            new Wander(0.12)
                            )
                        ),
                    new State("Orbit&HealJon",
                    new Orbit(0.55, 2, 20, "Jon Bilgewater the Pirate King"),
                    new SpecificHeal(2, 1000, "JonBilgewater", coolDown: 2850)
                    ),
                    new State("rip",
                    new Suicide()
                    )
                 )
              )
              .Init("Parrot Cage",
                  new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("NoSpawn"
                        ),
                    new State("SpawnParrots",
                    new Spawn("Deadwater Docks Parrot", 5, coolDown: 2500)
                    )
                 )
              )
             .Init("Bottled Evil Water",
                 new State(
                    new State("water",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(2000, "drop")
                        ),
                    new State("drop",
                       new ApplySetpiece("BottledEvil"),
                       new Decay()
                    )))
          .Init("Deadwater Docks Lieutenant",
                new State(
                    new Follow(1, 8, 1),
                    new Shoot(8, 1, 10, coolDown: 1000),
                    new TossObject("Bottled Evil Water", angle: null, coolDown: 6750)
                    ),
                new ItemLoot("Health Potion", 0.1),
                new ItemLoot("Magic Potion", 0.1)
            )
          .Init("Deadwater Docks Veteran",
                new State(
                    new Follow(0.8, 8, 1),
                    new Shoot(8, 1, 10, coolDown: 500)
                    ),
                new TierLoot(10, ItemType.Weapon, 0.05),
                new ItemLoot("Health Potion", 0.1),
                new ItemLoot("Magic Potion", 0.1)
            )
          .Init("Deadwater Docks Admiral",
                new State(
                    new Follow(0.6, 8, 1),
                    new Shoot(8, 3, 10, coolDown: 1325)
                    ),
                new ItemLoot("Health Potion", 0.1),
                new ItemLoot("Magic Potion", 0.1)
            )
          .Init("Deadwater Docks Brawler",
                new State(
                    new Follow(1.12, 8, 1),
                    new Shoot(8, 1, 10, coolDown: 350)
                    ),
                new ItemLoot("Health Potion", 0.1),
                new ItemLoot("Magic Potion", 0.1)
            )
          .Init("Deadwater Docks Sailor",
                new State(
                    new Follow(0.9, 8, 1),
                    new Shoot(8, 1, 10, coolDown: 525)
                    ),
                new ItemLoot("Health Potion", 0.1),
                new ItemLoot("Magic Potion", 0.1)
            )
          .Init("Deadwater Docks Commander",
                new State(
                    new Follow(0.90, 8, 1),
                    new Shoot(8, 1, 10, coolDown: 900),
                    new TossObject("Bottled Evil Water", angle: null, coolDown: 8750)
                    ),
                new ItemLoot("Health Potion", 0.1),
                new ItemLoot("Magic Potion", 0.1)
            )
          .Init("Deadwater Docks Captain",
                new State(
                    new Follow(0.47, 8, 1),
                    new Shoot(8, 1, 10, coolDown: 3500)
                    ),
                new ItemLoot("Health Potion", 0.1),
                new ItemLoot("Magic Potion", 0.1)
            )

          .Init("Jon Bilgewater the Pirate King",
                new State(
                    new RealmPortalDrop(),
                    new State("default",
                        new Taunt(true, "With Dreadstump gone, I’m the new king!"),
                        new PlayerWithinTransition(8, "coinphase")
                        ),
                  new State(
                      new Order(90, "Parrot Cage", "SpawnParrots"),
                    new DamageTakenTransition(32500, "gotoSpawn"),
                    new State("coinphase",
                        new Wander(0.11),
                        new Taunt(true, "Dodge this!"),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 2000),
                        new TimedTransition(4500, "cannonballs")
                        ),
                    new State("cannonballs",
                        new Follow(0.32, 8, coolDown: 1000),
                        new Taunt(true, "Check out my AWESOME CANNON CLUSTER!"),
                        new Shoot(10, count: 7, shootAngle: 30, projectileIndex: 1, coolDown: 2150),
                        new TimedTransition(5000, "coinphase")
                        )
                      ),

                    new State("gotoSpawn",
                        new ReturnToSpawn(once: true, speed: 0.52),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt(true, "Dreadstump was a dreadCHUMP! And so are you!"),
                        new ConditionalEffect(ConditionEffectIndex.StunImmune),
                        new TimedTransition(3500, "blastcannonballs")
                        ),
                    new State("blastcannonballs",
                        new ConditionalEffect(ConditionEffectIndex.StunImmune),
                        new Taunt(true, "CANNON BARRAGE!"),
                        new Order(90, "Deadwater Docks Parrot", "CircleOrWander"),
                        new Shoot(10, count: 7, shootAngle: 30, projectileIndex: 1, coolDown: 1750),
                        new TimedTransition(6000, "parrotcircle")
                        ),
                    new State("parrotcircle",
                        new ConditionalEffect(ConditionEffectIndex.StunImmune),
                        new Taunt(true, "Now you’re making me angry! PARROT BARRIER ACTIVATE!"),
                        new Order(90, "Deadwater Docks Parrot", "Orbit&HealJon"),
                        new TimedTransition(6000, "blastcannonballs")
                        )
                    ),
                new MostDamagers(3,
                    new ItemLoot("Potion of Speed", 1.0)
                ),
                new MostDamagers(1,
                    new ItemLoot("Potion of Dexterity", 1.0)
                ),
                new Threshold(0.025,
                    new TierLoot(12, ItemType.Weapon, 0.1),
                    new TierLoot(5, ItemType.Ability, 0.1),
                    new TierLoot(11, ItemType.Armor, 0.05),
                    new TierLoot(11, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("Pirate King's Cutlass", 0.024)
                )
            )
            ;
    }
}