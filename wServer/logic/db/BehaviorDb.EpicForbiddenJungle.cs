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
        private _ EpicForbiddenJunglet = () => Behav()
            .Init("Golden Totem",
                new State(
                    new EntityNotExistsTransition("Primaeval The Ancient Totem", 100, "Despawn"),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                 new State("Idle",
                 new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                 new TimedTransition(300, "AttackingC1")
                     ),
                new State("AttackingC1",
                 new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                 new Shoot(10, 3, projectileIndex: 1, fixedAngle: 0, coolDownOffset: 0, coolDown: 750),
                 new Shoot(10, 3, projectileIndex: 1, fixedAngle: 24, coolDownOffset: 200, coolDown: 750),
                 new Shoot(10, 3, projectileIndex: 1, fixedAngle: 48, coolDownOffset: 400, coolDown: 750),
                 new Shoot(10, 3, projectileIndex: 1, fixedAngle: 72, coolDownOffset: 600, coolDown: 750),
                 new Shoot(10, 3, projectileIndex: 1, fixedAngle: 96, coolDownOffset: 800, coolDown: 750),
                 new TimedTransition(5000, "transition2")
                      ),
                 new State("transition2",
                 new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                 new Shoot(10, 3, projectileIndex: 0, fixedAngle: 96, coolDownOffset: 800, coolDown: 750),
                 new Shoot(10, 3, projectileIndex: 0, fixedAngle: -72, coolDownOffset: 600, coolDown: 750),
                 new Shoot(10, 3, projectileIndex: 0, fixedAngle: -48, coolDownOffset: 400, coolDown: 750),
                 new Shoot(10, 3, projectileIndex: 0, fixedAngle: -24, coolDownOffset: 200, coolDown: 750),
                 new Shoot(10, 3, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 0, coolDown: 750),
                 new TimedTransition(5000, "Wait")
                     ),
                 new State("Wait",
                     new Flash(0xe0cb79, 0.1, 1),
                 new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                 new TimedTransition(5000, "AttackingC1")
                     ),
                  new State("Despawn",
                  new Timed(1000, new Suicide())
                     )

                )
                    )
                    
             .Init("Primaeval The Ancient Totem",
                new State(
                    new DropPortalOnDeath("Temple Servant Portal", 75),
                new State("Idle",
                 new ConditionalEffect(ConditionEffectIndex.Invincible),
                 new Flash(0xff0000, 0.1, 10),
                 new Taunt("..."),
                 new TimedTransition(2000, "Idle2")
                    ),
                new State("Idle2",
                 new ConditionalEffect(ConditionEffectIndex.Invincible),
                 new Flash(0xff0000, 0.1, 10),
                 new Taunt("..."),
                 new TimedTransition(2500, "Taunt")
                    ),
                new State("Taunt",
                 new ConditionalEffect(ConditionEffectIndex.Invincible),
                 new Taunt("You've fallen into the wrong cave."),
                 new TimedTransition(1800, "Taunt2")
                    ),
                new State("Taunt2",
                 new ConditionalEffect(ConditionEffectIndex.Invincible),
                 new Taunt("But, if you wish to fight then so be it."),
                 new TimedTransition(1800, "Taunt3")
                    ),
                new State("Taunt3",
                 new ConditionalEffect(ConditionEffectIndex.Invincible),
                 new Taunt("Prepare yourself."),
                 new TimedTransition(1200, "Starting")
                    ),
                new State("Starting",
                 new ConditionalEffect(ConditionEffectIndex.Armored),
                 new TimedTransition(1000, "Attacks")
                    ),
                new State("Attacks",
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                    new Flash(0xff0000, 0.1, 10),
                        new TimedTransition(1500, "AttackC", randomized: true),
                        new TimedTransition(1500, "AttackA", randomized: true),
                        new HpLessTransition(.56, "HalfHP")
                ),
                new State("AttackC",
                    new Shoot(20, 1, 0, 1, 60),
                        new Shoot(20, 1, 3, 1, 120),
                        new Shoot(20, 1, 3, 1, 180),
                        new Shoot(20, 1, 3, 1, 240),
                        new Shoot(20, 1, 3, 1, 300),
                        new Shoot(20, 1, 3, 1, 0),
                        new Shoot(20, 1, 3, 1, 70, coolDownOffset: 200),
                        new Shoot(20, 1, 3, 1, 130, coolDownOffset: 200),
                        new Shoot(20, 1, 3, 1, 190, coolDownOffset: 200),
                        new Shoot(20, 1, 3, 1, 250, coolDownOffset: 200),
                        new Shoot(20, 1, 3, 1, 310, coolDownOffset: 200),
                        new Shoot(20, 1, 3, 1, 10, coolDownOffset: 200),
                        new Shoot(20, 1, 3, 1, 80, coolDownOffset: 400),
                        new Shoot(20, 1, 3, 1, 140, coolDownOffset: 400),
                        new Shoot(20, 1, 3, 1, 200, coolDownOffset: 400),
                        new Shoot(20, 1, 3, 1, 260, coolDownOffset: 400),
                        new Shoot(20, 1, 3, 1, 320, coolDownOffset: 400),
                        new Shoot(20, 1, 3, 1, 20, coolDownOffset: 400),
                        new Shoot(20, 1, 3, 1, 90, coolDownOffset: 600),
                        new Shoot(20, 1, 3, 1, 150, coolDownOffset: 600),
                        new Shoot(20, 1, 3, 1, 210, coolDownOffset: 600),
                        new Shoot(20, 1, 3, 1, 270, coolDownOffset: 600),
                        new Shoot(20, 1, 3, 1, 330, coolDownOffset: 600),
                        new Shoot(20, 1, 3, 1, 30, coolDownOffset: 600),
                        new Shoot(20, 1, 3, 1, 100, coolDownOffset: 800),
                        new Shoot(20, 1, 3, 1, 160, coolDownOffset: 800),
                        new Shoot(20, 1, 3, 1, 220, coolDownOffset: 800),
                        new Shoot(20, 1, 3, 1, 280, coolDownOffset: 800),
                        new Shoot(20, 1, 3, 1, 340, coolDownOffset: 800),
                        new Shoot(20, 1, 3, 1, 40, coolDownOffset: 800),
                        new Shoot(20, 1, 3, 1, 110, coolDownOffset: 1000),
                        new Shoot(20, 1, 3, 1, 170, coolDownOffset: 1000),
                        new Shoot(20, 1, 3, 1, 230, coolDownOffset: 1000),
                        new Shoot(20, 1, 3, 1, 290, coolDownOffset: 1000),
                        new Shoot(20, 1, 3, 1, 350, coolDownOffset: 1000),
                        new Shoot(20, 1, 3, 1, 50, coolDownOffset: 1000),
                        new Shoot(20, 1, 3, 1, 120, coolDownOffset: 1200),
                        new Shoot(20, 1, 3, 1, 180, coolDownOffset: 1200),
                        new Shoot(20, 1, 3, 1, 240, coolDownOffset: 1200),
                        new Shoot(20, 1, 3, 1, 300, coolDownOffset: 1200),
                        new Shoot(20, 1, 3, 1, 0, coolDownOffset: 1200),
                        new Shoot(20, 1, 3, 1, 60, coolDownOffset: 1200),
                        new HpLessTransition(.56, "HalfHP"),
                        new TimedTransition(12000, "Attacks")
                    ),
                   new State("AttackA",
                       new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(25, projectileIndex: 1, count: 2, shootAngle: 10, predictive: 1, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 2, count: 3, shootAngle: 10, predictive: 0, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(9, 3, projectileIndex: 3, shootAngle: 10, coolDown: 500),
                        new Shoot(9, count: 6, fixedAngle: 3, projectileIndex: 2, coolDown: 2000),
                        new HpLessTransition(.56, "HalfHP"),
                        new TimedTransition(12000, "Attacks")
                    ),
                   new State("HalfHP",
                       new ConditionalEffect(ConditionEffectIndex.Invincible),
                       new Taunt("I'll make you wish you never did that."),
                       new Flash(0xff0000, 0.1, 10),
                       new TimedTransition(1400, "Spawn Totems")
                       ),
                   new State("Spawn Totems",
                     new Flash(0xff0000, 0.1, 10),
                     new ConditionalEffect(ConditionEffectIndex.Invincible),
                     new Order(20, "1Golden Totem Spawner", "Idle"),
                     new TimedTransition(3000, "HardAttacks")
                     ),
                   new State("HardAttacks",
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                    new Flash(0xff0000, 0.1, 10),
                        new TimedTransition(2000, "HAttackC", randomized: true),
                        new TimedTransition(2000, "HAttackA", randomized: true),
                        new HpLessTransition(.07, "Dead")
                        ),
                new State("HAttackC",
                    new Shoot(20, 1, 0, 1, 60),
                        new Shoot(20, 1, 3, 1, 120),
                        new Shoot(20, 1, 3, 1, 180),
                        new Shoot(20, 1, 3, 1, 240),
                        new Shoot(20, 1, 3, 1, 300),
                        new Shoot(20, 1, 3, 1, 0),
                        new Shoot(20, 1, 3, 1, 70, coolDownOffset: 200),
                        new Shoot(20, 1, 3, 1, 130, coolDownOffset: 200),
                        new Shoot(20, 1, 3, 1, 190, coolDownOffset: 200),
                        new Shoot(20, 1, 3, 1, 250, coolDownOffset: 200),
                        new Shoot(20, 1, 3, 1, 310, coolDownOffset: 200),
                        new Shoot(20, 1, 3, 1, 10, coolDownOffset: 200),
                        new Shoot(20, 1, 3, 1, 80, coolDownOffset: 400),
                        new Shoot(20, 1, 3, 1, 140, coolDownOffset: 400),
                        new Shoot(20, 1, 3, 1, 200, coolDownOffset: 400),
                        new Shoot(20, 1, 3, 1, 260, coolDownOffset: 400),
                        new Shoot(20, 1, 3, 1, 320, coolDownOffset: 400),
                        new Shoot(20, 1, 3, 1, 20, coolDownOffset: 400),
                        new Shoot(20, 1, 3, 1, 90, coolDownOffset: 600),
                        new Shoot(20, 1, 3, 1, 150, coolDownOffset: 600),
                        new Shoot(20, 1, 3, 1, 210, coolDownOffset: 600),
                        new Shoot(20, 1, 3, 1, 270, coolDownOffset: 600),
                        new Shoot(20, 1, 3, 1, 330, coolDownOffset: 600),
                        new Shoot(20, 1, 3, 1, 30, coolDownOffset: 600),
                        new Shoot(20, 1, 3, 1, 100, coolDownOffset: 800),
                        new Shoot(20, 1, 3, 1, 160, coolDownOffset: 800),
                        new Shoot(20, 1, 3, 1, 220, coolDownOffset: 800),
                        new Shoot(20, 1, 3, 1, 280, coolDownOffset: 800),
                        new Shoot(20, 1, 3, 1, 340, coolDownOffset: 800),
                        new Shoot(20, 1, 3, 1, 40, coolDownOffset: 800),
                        new Shoot(20, 1, 3, 1, 110, coolDownOffset: 1000),
                        new Shoot(20, 1, 3, 1, 170, coolDownOffset: 1000),
                        new Shoot(20, 1, 3, 1, 230, coolDownOffset: 1000),
                        new Shoot(20, 1, 3, 1, 290, coolDownOffset: 1000),
                        new Shoot(20, 1, 3, 1, 350, coolDownOffset: 1000),
                        new Shoot(20, 1, 3, 1, 50, coolDownOffset: 1000),
                        new Shoot(20, 1, 3, 1, 120, coolDownOffset: 1200),
                        new Shoot(20, 1, 3, 1, 180, coolDownOffset: 1200),
                        new Shoot(20, 1, 3, 1, 240, coolDownOffset: 1200),
                        new Shoot(20, 1, 3, 1, 300, coolDownOffset: 1200),
                        new Shoot(20, 1, 3, 1, 0, coolDownOffset: 1200),
                        new Shoot(20, 1, 3, 1, 60, coolDownOffset: 1200),
                         new HpLessTransition(.07, "Dead"),
                        new TimedTransition(12000, "HardAttacks")
                      ),
                   new State("HAttackA",
                        new Shoot(25, projectileIndex: 1, count: 2, shootAngle: 10, predictive: 1, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 2, count: 3, shootAngle: 10, predictive: 0, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(9, 3, projectileIndex: 3, shootAngle: 10, coolDown: 500),
                        new Shoot(9, count: 6, fixedAngle: 3, projectileIndex: 2, coolDown: 2000),
                         new HpLessTransition(.07, "Dead"),
                        new TimedTransition(12000, "HardAttacks")
                       ),
                    new State("Dead",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("My remains will become one in the realm one day."),
                        new TimedTransition(1800, "Suicide1")
                        ),
                    new State("Suicide1",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(400, "Suicide")

                       ),
                    new State("Suicide",
                        new Suicide()
                        )
                ),
                new MostDamagers(4,
                    new ItemLoot("Potion of Unknown", 0.04),
                    new ItemLoot("SamuraiST3", 0.015),
                    new ItemLoot("SamuraiST1", 0.015),
                    new ItemLoot("SamuraiST0", 0.015),
                    new ItemLoot("SamuraiST2", 0.015),
                    new ItemLoot("Sealed Crystal Skull", 0.02)
                ),
                new Threshold(0.05,
                    new ItemLoot("Potion of Attack", 1),
                    new ItemLoot("Potion of Defense", 1),
                    new ItemLoot("Potion of Defense", 1)
                ),
                new Threshold(0.1,
                    new TierLoot(11, ItemType.Weapon, 0.08),
                    new TierLoot(12, ItemType.Weapon, 0.07),
                    new TierLoot(5, ItemType.Ability, 0.08),
                    new TierLoot(6, ItemType.Ability, 0.06),
                    new TierLoot(12, ItemType.Armor, 0.08),
                    new TierLoot(13, ItemType.Armor, 0.07),
                    new TierLoot(6, ItemType.Ring, 0.07)
                 )
            
            )



            .Init("1Golden Totem Spawner",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("Nothing",
                        new Flash(0xff0000, 0.1, 10)
                        ),
                 new State("Idle",
                     new Spawn("Golden Totem", 1, 1, 1000000)
                     )
                    )
            )

           
        
        .Init("Jungle Event Loot Chest",
                new State(
                new State("Nothing",
                 new ConditionalEffect(ConditionEffectIndex.Invincible),
                 new TimedTransition(10000, "Attack")
                    ),
                new State("Attack"
                    )
                    
                    ),
                    
                 new Threshold(0.05,
                    new ItemLoot("Potion of Attack", 1),
                    new ItemLoot("Potion of Defense", 1),
                    new ItemLoot("Potion of Defense", 1),
                    new ItemLoot("Potion of Unknown", 0.01),
                    new ItemLoot("Backpack", 0.03),
                    new ItemLoot("XP Booster 20 min", 0.03),
                    new ItemLoot("Loot Drop Potion", 0.03),
                    new TierLoot(11, ItemType.Weapon, 0.08),
                    new TierLoot(12, ItemType.Weapon, 0.07),
                    new TierLoot(13, ItemType.Weapon, 0.06),
                    new TierLoot(5, ItemType.Ability, 0.08),
                    new TierLoot(6, ItemType.Ability, 0.06),
                    new TierLoot(12, ItemType.Armor, 0.08),
                    new TierLoot(13, ItemType.Armor, 0.07),
                    new TierLoot(6, ItemType.Ring, 0.07),
                     new ItemLoot("SamuraiST3", 0.015),
                    new ItemLoot("SamuraiST1", 0.015),
                    new ItemLoot("SamuraiST0", 0.015),
                    new ItemLoot("SamuraiST2", 0.015),
                    new ItemLoot("Sealed Crystal Skull", 0.02)
                     )
            
                    
            
        






            );
    }
}
