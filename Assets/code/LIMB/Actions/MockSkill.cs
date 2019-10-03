using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LIMB;
using System;

public class MockSkill : Skill {
    
    public delegate bool canBeCastFunc(Combatant actor, Combatant[] actorParty = null, Combatant[] enemyParty = null);
    public delegate bool canTargetFunc(Combatant actor, Combatant target, Combatant[] actorParty = null, Combatant[] enemyParty = null);

    public canBeCastFunc canBeCast;
    public canTargetFunc canTarget;

    public override bool CanBeCast(Combatant actor, Combatant[] actorParty = null, Combatant[] enemyParty = null) {
        if(canBeCast != null) {
            return canBeCast.Invoke(actor, actorParty, enemyParty);
        }else {
            return false;
        }
    }

    public override bool CanTarget(Combatant actor, Combatant target, Combatant[] actorParty = null, Combatant[] enemyParty = null) {
        if(canTarget != null) {
            return canTarget.Invoke(actor, target, actorParty, enemyParty);
        }else {
            return false;
        }
    }

    public override void Execute(Combatant[] actorParty, Combatant[] enemyParty, Combatant actor, Combatant[] targets, string targetLimb = null) {
        return;
    }
}
