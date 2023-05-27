using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBed : MonoBehaviour
{
    private ResourceType type;
    
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Worker"))
        {
            return;
        }

        var worker = other.GetComponent<Worker>();
        
        worker.PickupResources(type);
    }
}
