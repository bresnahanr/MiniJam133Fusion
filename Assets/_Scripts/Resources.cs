using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    [SerializeField]
    private float money;
    [SerializeField]
    private float moneyBasePay = 1000;
    [SerializeField]
    private float moneyMultiplier;

    private float wood;
    private float water;
    private float uranium;

    // Start is called before the first frame update
    void Start()
    {
        money = 5000;
        wood = 0;
        water = 0;
        uranium = 0;
    }

	private void OnEnable()
	{
        TimeController.OnHourChanged += IncreaseFundsHourly;
	}

	private void OnDisable()
	{
        TimeController.OnHourChanged -= IncreaseFundsHourly;
	}

	// Update is called once per frame
	void Update()
    {
        
    }

    private void IncreaseFundsHourly()
	{
        money += moneyBasePay * moneyMultiplier;
	}
}
