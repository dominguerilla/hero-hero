﻿using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace LIMB {
    public class BattleManager : MonoBehaviour {

        List<Action> currentRound;
        int roundCount;
        bool inBattle;
        List<Combatant> lCombatants, rCombatants;

        // Sorted by descending SPEED.
        IEnumerable<Combatant> allCombatants;

        private void Awake() {
            currentRound = new List<Action>();
        }

        public void StartBattle(NPCParty leftParty, NPCParty rightParty){
            if(!inBattle){
                inBattle = true;
                lCombatants = GenerateCombatants(leftParty);
                rCombatants = GenerateCombatants(rightParty);

                allCombatants = lCombatants.Concat<Combatant>(rCombatants);
                allCombatants.OrderByDescending(c => c.GetRawStat(Stats.STAT.SPEED));

                Debug.Log("Battle started!");
            }
        }

        public void EndBattle(){
            if(inBattle){
                inBattle = false;
                Debug.Log("Battle ended!");
                lCombatants = null;
                rCombatants = null;
                allCombatants = null;
            }
        }
        
        public void ExecuteRound() {
            this.currentRound.Clear();
            this.roundCount++;
        }

        public void AddActions(params Action[] actions) {
            this.currentRound.AddRange(actions);
        }

        /// <summary>
        /// Return the number of rounds that have gone by.
        /// </summary>
        /// <returns></returns>
        public int GetRoundCount() {
            return roundCount;
        }

        /// <summary>
        /// Return the number of Actions in the current round.
        /// </summary>
        /// <returns></returns>
        public int GetRoundLength() {
            return currentRound.Count;
        }

        List<Combatant> GenerateCombatants(NPCParty party){
            CombatantData[] data = party.GetData();
            List<Combatant> combatants = new List<Combatant>();
            foreach(CombatantData c in data){
                combatants.Add(new Combatant(c));
            }
                
            return combatants;
        }

        public List<Combatant> GetLeftCombatants() {
            return this.lCombatants;
        }

        public List<Combatant> GetRightCombatants() {
            return this.rCombatants;
        }
    }
}
