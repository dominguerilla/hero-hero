﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LIMB;
/// <summary>
/// Used to debug the ActionBuilderUI functionality.
/// </summary>
public class ActionBuilderUITester : MonoBehaviour
{
    [SerializeField]
    CombatantData currentCombatant;

    [SerializeField]
    Skill currentSkill;

    [SerializeField]
    CombatantData currentTarget;

    ActionBuilderUI ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindObjectOfType<ActionBuilderUI>();
        if(!ui){
            Debug.LogError("No ActionBuilderUI found in scene.");
            Destroy(this);
        }
        Debug.Log("ActionBuilderUI found in " + ui.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
