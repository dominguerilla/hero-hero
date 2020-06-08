using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }
    public void Freeze()
    {
        if (rb)
        {
            rb.isKinematic = true;
        }
    }

    public void Unfreeze()
    {
        if (rb)
        {
            rb.isKinematic = false;
        }
    }
}
