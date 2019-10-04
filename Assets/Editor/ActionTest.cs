using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using LIMB;

namespace Tests
{
    public class ActionTest
    {
        [Test]
        public void ActionTestConstructionSuccessful()
        {
            Combatant actor = new Combatant();
            MockSkill mockSkill = ScriptableObject.CreateInstance<MockSkill>();
            Action action = new Action(actor, mockSkill);
        }

        [Test]
        public void HeroAttacksGoblin() {
            Combatant hero = new Combatant();
            Combatant goblin = new Combatant();
            MockSkill attack = ScriptableObject.CreateInstance<MockSkill>();
            attack.execute = (actor, target) => { target.InflictDamage(new Damage(10f)); };

            Action attackAction = new Action(hero, attack, goblin);
            float startingHealth = goblin.GetCurrentHealth();
            attackAction.Execute();
            Assert.Less(goblin.GetCurrentHealth(), startingHealth);            
        }

    }
}
