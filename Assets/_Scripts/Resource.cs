using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
	private int _currentAmount = 0;

	public ResourceType ResourceType { get; private set; }

	public Resource(ResourceType type)
	{
		ResourceType = type;
	}

	public int Value => _currentAmount;

	private bool CheckFunds(int amount)
    {
	    return amount >= _currentAmount;
    }
    
    public void Add(int amount)
    {
	    _currentAmount += amount;
    }

    public bool Subtract(int amount)
    {
	    if (CheckFunds(amount))
	    {
		    _currentAmount -= amount;
		    return true;
	    }
	    return false;
    }
}

public enum ResourceType
{
	Money,
	Uranium,
}