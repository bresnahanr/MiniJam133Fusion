using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public static event Action<Location> Embark;

    [Header("Worker Stats")]
    [SerializeField] private int baseCollectionAmount;
    [SerializeField] private float collectionModifier;
    [SerializeField] private float collectionTime;

    private ResourceBag bag = new ResourceBag();

    private bool reachedCheckpoint = true;

    public void PickupResources(ResourceType type)
    {
        bag.ResourceType = type;
        bag.Amount = (int)(baseCollectionAmount * collectionModifier);
        bag.Full = true;
        reachedCheckpoint = true;
    }

    public void DropoffResources()
    {
        reachedCheckpoint = true;
        
        if (bag.ResourceType == ResourceType.Uranium)
        {
            GameState.Uranium.Add(bag.Amount);
        } else if (bag.ResourceType == ResourceType.Money)
        {
            GameState.Money.Add(bag.Amount);
        }

        bag.Amount = 0;
        bag.Full = false;
    }

    private void FinishCollecting()
    {
        if (bag.Full)
        {
            Embark?.Invoke(Location.Lab);
        }
        else
        {
            Embark?.Invoke(Location.ResourceBed);
        }
    }
    
    private void Update()
    {
        if (reachedCheckpoint)
        {
            DOVirtual.DelayedCall(collectionTime, FinishCollecting);
            reachedCheckpoint = false;
        }
    }
}

public class ResourceBag
{
    public bool Full = false;
    public ResourceType ResourceType;
    public int Amount;
}

public enum Location{
    Lab,
    ResourceBed,
}
