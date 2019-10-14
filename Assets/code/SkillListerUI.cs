using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using LIMB;


/// <summary>
/// Populates a UI Panel with UI Buttons representing a single Skill.
/// </summary>
public class SkillListerUI : MonoBehaviour
{
    ///
    /// I'm thinking of showing only 4 Skills at a time.
    /// To see more Skills than that, you will need to scroll 4 Skills at a time.
    /// This might get annoying when you have 20+ skills though...
    /// 
    private static int MAX_SKILL_NUM = 4;
    
    /// <summary>
    /// The UI Button prefab that represents a Skill.
    /// </summary>
    [SerializeField]
    GameObject skillButtonPrefab;

    List<Skill> currentSkills;
    Stack<SkillButton> skillButtonPool;
    List<SkillButton> activeButtons;

    void Start()
    {
        skillButtonPool = new Stack<SkillButton>();
        activeButtons = new List<SkillButton>();
        for(int i = 0; i < MAX_SKILL_NUM; i++){
            GameObject button = GameObject.Instantiate<GameObject>(skillButtonPrefab);
            button.transform.SetParent(this.transform);

            SkillButton skillButton = button.GetComponent<SkillButton>();
            if(!skillButton){
                Debug.LogError("No SkillButton component found in skillButtonPrefab.");
                return;
            }
            skillButton.gameObject.SetActive(false);
            skillButtonPool.Push(skillButton);
        }
    }

    /// <summary>
    /// Creates Buttons for the first four skills that the Combatant has.
    /// </summary>
    /// <param name="combatant"></param>
    public void ListSkills(Combatant combatant){
        currentSkills = combatant.GetSkills();
        int skillNum = Mathf.Min(MAX_SKILL_NUM, currentSkills.Count);
        
        for(int i = 0; i < skillNum; i++){
            SkillButton skillButton = PopSkillButton();
            if(skillButton){
                skillButton.SetSkill(currentSkills[i]);
                skillButton.gameObject.SetActive(true);
            }else{
                Debug.LogError("Out of SkillButtons from pool!");
            }
        }
    }

    public void Clear(){
        foreach(SkillButton button in activeButtons){
            button.gameObject.SetActive(false);
        }
    }

    SkillButton PopSkillButton(){
        SkillButton button = skillButtonPool.Pop();
        activeButtons.Add(button);
        return button;   
    }
}
