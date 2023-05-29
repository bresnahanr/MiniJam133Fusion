using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action OnGameOver;
    
    [SerializeField] private int hourlyIncome;

    [SerializeField] private float decayRate = 1;

    private void Start()
    {
        GameState.Money = new Resource(ResourceType.Money);
        GameState.Uranium = new Resource(ResourceType.Uranium);
        GameState.Wood = new Resource(ResourceType.Wood);
        GameState.Water = new Resource(ResourceType.Water);
        GameState.UraniumMeter = 100f;
        GameState.WoodMeter = 100f;
        GameState.WaterMeter = 100f;

        var workers = GameObject.FindGameObjectsWithTag("Worker");

        foreach (var worker in workers)
        {
            worker.GetComponent<Worker>().Init();
        }
    }

	private void OnEnable()
	{
        TimeController.OnHourChanged += GenerateIncome;
        TimeController.OnHourChanged += SpendHourlyResource;
        TimeController.OnDayChanged += ResourceCostIncrease;
    }
	private void OnDisable()
	{
        TimeController.OnHourChanged -= GenerateIncome;
        TimeController.OnHourChanged -= SpendHourlyResource;
        TimeController.OnDayChanged -= ResourceCostIncrease;
    }

	public void EndGame()
	{
        OnGameOver?.Invoke();
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
        GameState.UraniumMeter -= decayRate;
        while (GameState.Uranium.Subtract((int)GameState.UraniumTickRate) && GameState.UraniumMeter < 100f )
            GameState.UraniumMeter++;

        // Wood
        GameState.WoodMeter -= decayRate;
        while (GameState.Wood.Subtract((int)GameState.WoodTickRate) && GameState.WoodMeter < 100f)
            GameState.WoodMeter++;

        // Water
        GameState.WaterMeter -= decayRate;
        while (GameState.Water.Subtract((int)GameState.WaterTickRate) && GameState.WaterMeter < 100f)
            GameState.WaterMeter++;

        // Game Over conditional
        if (GameState.UraniumMeter <= 0 ||
            GameState.WoodMeter <= 0 ||
            GameState.WaterMeter <= 0)
            EndGame();

    }

}
