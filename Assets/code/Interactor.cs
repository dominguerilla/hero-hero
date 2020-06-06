using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles interacting with whateever's under the mouse cursor.
/// </summary>
public class Interactor : MonoBehaviour
{
    public float maxInteractionDistance = 2f;
    public float maxDropDistance = 2f;

    InventoryComponent inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = this.GetComponent<InventoryComponent>();    
    }

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 10, 10), "");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            PickUp();
        }else if(Input.GetKeyDown(KeyCode.R)){
            Drop();
        }
    }

    void PickUp()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, maxInteractionDistance))
        {
            Transform objectHit = hit.transform;

            ItemComponent item = objectHit.GetComponent<ItemComponent>();
            if (item)
            {
                inventory.Add(item.gameObject);
            }
        }
    }

    void Drop()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //TODO: Can only drop if mouse is on something
        //TODO: One can drop an item through a wall/object
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 position = (hit.point - transform.position).normalized;
            this.inventory.Drop(transform.position + position);
        }
    }
}
