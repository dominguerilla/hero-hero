using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LIMB;
using UnityEngine.UI;
public class SkillButton : MonoBehaviour
{
    [SerializeField]
    Skill skill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSkill(Skill skill){
        this.skill = skill;
        Text text = GetComponentInChildren<Text>();
        text.text = skill.actionName;
    }

    public Skill GetSkill(){
        return this.skill;
    }

}
