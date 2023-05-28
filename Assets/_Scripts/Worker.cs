using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public event Action<Location> Embark;

    [Header("Worker Stats")]
    [SerializeField] private int baseCollectionAmount;
    [SerializeField] private float collectionModifier;
    [SerializeField] private float collectionTime;

    [SerializeField] private ResourceType type;

    private ResourceBag bag = new ResourceBag();
    private NavMovementController movement;

    private bool reachedCheckpoint = true;

    public void Init()
    {
        var labLocation = GameObject.FindGameObjectWithTag("Lab");
        GameObject resourceLocation;
        switch (type)
        {
            case ResourceType.Uranium:
                resourceLocation = GameObject.FindGameObjectWithTag("UraniumBed");
                movement.SetLocations(labLocation, resourceLocation);
                break;
            case ResourceType.Wood:
                resourceLocation = GameObject.FindGameObjectWithTag("WoodBed");
                movement.SetLocations(labLocation, resourceLocation);
                break;
            case ResourceType.Water:
                resourceLocation = GameObject.FindGameObjectWithTag("WaterBed");
                movement.SetLocations(labLocation, resourceLocation);
                break;
            default:
                break;
        }
    }

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
            movement.MoveTo(Location.Lab);
        }
        else
        {
            movement.MoveTo(Location.ResourceBed);
        }
    }

    private void Awake()
    {
        movement = GetComponent<NavMovementController>();
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
