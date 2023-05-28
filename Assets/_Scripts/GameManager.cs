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
        GameState.Wood = new Resource(ResourceType.Wood);
        GameState.Water = new Resource(ResourceType.Water);
        GameState.UraniumMeter = 100f;
        GameState.WoodMeter = 100f;
        GameState.WaterMeter = 100f;
    }

	private void OnEnable()
	{
        TimeController.OnHourChanged += GenerateIncome;
        TimeController.OnHourChanged += ExpendUranium;
        TimeController.OnHourChanged += SpendHourlyResource;
        TimeController.OnDayChanged += ResourceCostIncrease;
    }
	private void OnDisable()
	{
        TimeController.OnHourChanged -= GenerateIncome;
        TimeController.OnHourChanged -= ExpendUranium;
        TimeController.OnHourChanged -= SpendHourlyResource;
        TimeController.OnDayChanged -= ResourceCostIncrease;
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

    // Called during OnDayChanged delegation
    private void ResourceCostIncrease()
	{
        GameState.UraniumTickRate = Mathf.Floor(GameState.UraniumTickRate * 1.3f);
        GameState.WoodTickRate = Mathf.Floor(GameState.WoodTickRate * 1.5f);
        GameState.WaterTickRate = Mathf.Floor(GameState.WaterTickRate * 1.7f);
    }


    private void SpendHourlyResource()
	{
        // Uranium
        GameState.UraniumMeter -= 5f;
        while (GameState.Uranium.Subtract((int)GameState.UraniumTickRate) && GameState.UraniumMeter < 100f )
            GameState.UraniumMeter++;

        // Wood
        GameState.WoodMeter -= 5f;
        while (GameState.Uranium.Subtract((int)GameState.UraniumTickRate) && GameState.UraniumMeter < 100f)
            GameState.UraniumMeter++;

        // Water
        GameState.WaterMeter -= 5f;
        while (GameState.Uranium.Subtract((int)GameState.UraniumTickRate) && GameState.UraniumMeter < 100f)
            GameState.UraniumMeter++;

        // Game Over conditional
        if (GameState.UraniumMeter <= 0 ||
            GameState.WoodMeter <= 0 ||
            GameState.WaterMeter <= 0)
            EndGame();

    }

}
