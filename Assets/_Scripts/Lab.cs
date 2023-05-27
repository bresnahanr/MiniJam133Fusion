using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Worker"))
        {
            return;
        }

        var worker = other.GetComponent<Worker>();
        
        worker.DropoffResources();
    }
}
