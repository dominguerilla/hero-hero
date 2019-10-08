﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LIMB {
    /// <summary>
    /// Base class for attacks made with equipped weapons.
    /// </summary>
    [CreateAssetMenu(fileName = "New BasicAttack", menuName = "Basic Attack", order = 51)]
    public class BasicAttack : Skill {

        public Damage damage;

        public override bool CanTarget(Combatant actor, Combatant target, Combatant[] actorParty = null, Combatant[] enemyParty = null) {
            if(target.IsAlive() && actor != target){
                return true;
            }
            return false;
        }

        public override void Execute(Combatant actor, Combatant target) {
            target.InflictDamage(damage);
        }
    }
}
