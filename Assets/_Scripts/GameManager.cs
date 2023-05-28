using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action OnGameOver;
    
    [SerializeField] private int hourlyIncome;
    [SerializeField] private int uraniumCost;

    private void Start()
    {
        GameState.Money = new Resource(ResourceType.Money);
        GameState.Uranium = new Resource(ResourceType.Uranium);
        
        TimeController.OnHourChanged += GenerateIncome;
        TimeController.OnHourChanged += ExpendUranium;
    }

    public void EndGame()
	{
        OnGameOver?.Invoke();
	}
    
    private void ExpendUranium()
    {
        if (!GameState.Uranium.Subtract(uraniumCost))
        {
            EndGame();
        }
    }

    private void GenerateIncome()
    {
        GameState.Money.Add(hourlyIncome);
    }
}
