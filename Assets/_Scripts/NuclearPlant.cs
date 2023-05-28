using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearPlant : MonoBehaviour
{
    [SerializeField] private int hourlyIncome;
    [SerializeField] private int uraniumCost;

    private void Start()
    {
        TimeController.OnHourChanged += GenerateIncome;
        TimeController.OnHourChanged += ExpendUranium;
    }

    private void ExpendUranium()
    {
        if (!GameState.Uranium.Subtract(uraniumCost))
        {
            // TODO: Game over
        }
    }

    private void GenerateIncome()
    {
        GameState.Money.Add(hourlyIncome);
    }
}
