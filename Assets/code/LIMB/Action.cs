using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LIMB {
    /// <summary>
    /// Uses a Skill and specified Combatant to start building an Action, which has target(s).
    /// </summary>
    /// When Actions are performed, all buffs should have already been applied to all characters.
    /// Three phases of selecting an Action:
    /// 1. Select an actor
    /// 2. Select an Action
    /// 3. Select a target
    public class Action {
        
        Skill skill;
        Combatant actor;
        Combatant[] registeredTargets;

        public Action(Skill skill, Combatant actor) {
            this.skill = skill;
            this.actor = actor;
        }

        public override string ToString() {
            string targets = "";
            if(registeredTargets.Length == 0){
                targets = "NONE";
            }else if(registeredTargets.Length == 1){
                targets = registeredTargets[0].ToString();
            }
            else{
                for (int i = 0; i < registeredTargets.Length - 1; i++){
                    targets += registeredTargets[i] + ", ";
                }
                targets += "and " + registeredTargets[registeredTargets.Length - 1].ToString();
            }

            return actor.ToString() + " uses " + skill.actionName + " on " + targets;
        }
    }
}
