using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LIMB {
    public class BattleManager : MonoBehaviour {
        
        Battle battle;
        bool inBattle;
        Combatant[] lCombatants, rCombatants;

        private void Awake() {
        }

        public void StartBattle(NPCParty leftParty, NPCParty rightParty){
            if(!inBattle){
                inBattle = true;
                lCombatants = GenerateCombatants(leftParty);
                rCombatants = GenerateCombatants(rightParty);

                Debug.Log("Battle started!");
            }
        }

        public void EndBattle(){
            if(inBattle){
                inBattle = false;
                Debug.Log("Battle ended!");
                lCombatants = null;
                rCombatants = null;
            }
        }

        Combatant[] GenerateCombatants(NPCParty party){
            CombatantData[] data = party.GetData();
            Combatant[] combatants = new Combatant[data.Length];
            for (int i = 0; i < combatants.Length; i++){
                
                Combatant combatant = new Combatant(data[i]);
                combatants[i] = combatant;
            }
            return combatants;
        }

        public Combatant[] GetLeftCombatants() {
            return this.lCombatants;
        }

        public Combatant[] GetRightCombatants() {
            return this.rCombatants;
        }
    }
}
