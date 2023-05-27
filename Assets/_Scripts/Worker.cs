using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    [Header("Locations")]
    [SerializeField] private GameObject destination;
    [SerializeField] private GameObject lab;

    [Header("Worker Stats")]
    [SerializeField] private float baseCollectionAmount;
    [SerializeField] private float collectionModifier;
    
    [Tooltip("Worker speed in Meters per Second")]
    [SerializeField] private float speed;
    
    private ResourceBag bag = new ResourceBag();

    public void PickupResources(ResourceType type)
    {
        bag.ResourceType = type;
        bag.Amount = (int)(baseCollectionAmount * collectionModifier);
    }

    public void DropoffResources()
    {
        if (bag.ResourceType == ResourceType.Uranium)
        {
            GameState.Uranium.Add(bag.Amount);
        } else if (bag.ResourceType == ResourceType.Money)
        {
            GameState.Money.Add(bag.Amount);
        }

        bag.Amount = 0;
    }

    private void MoveToResourceBed()
    {
        
    }

    private void MoveToLab()
    {
        
    }

    private void Update()
    {
        if (!bag.Full)
        {
            MoveToResourceBed();
        }
        else
        {
            MoveToLab();
        }
    }
}

public class ResourceBag
{
    public bool Full = false;
    public ResourceType ResourceType;
    public int Amount;
}
