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
    
    /// <summary>
    /// The UI Button prefab that represents a Skill.
    /// </summary>
    [SerializeField]
    GameObject skillButtonPrefab;

    List<Skill> currentSkills;
    
    void Start()
    {
    }

    public void ListSkills(Combatant combatant){
        currentSkills = combatant.GetSkills();
        int skillNum = Mathf.Min(4, currentSkills.Count);
        
        for(int i = 0; i < skillNum; i++){
            GameObject button = GameObject.Instantiate<GameObject>(skillButtonPrefab);
            button.transform.SetParent(this.transform);
            Text buttonText = button.GetComponentInChildren<Text>();
            buttonText.text = currentSkills[i].actionName;
        }
    }

    public void Clear(){
        for(int i = transform.childCount - 1; i >= 0; i--){
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
