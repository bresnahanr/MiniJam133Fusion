using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action OnGameOver;

    private void Start()
    {
        GameState.Money = new Resource(ResourceType.Money);
        GameState.Uranium = new Resource(ResourceType.Uranium);
    }

    public void EndGame()
	{
        OnGameOver?.Invoke();
	}
}
