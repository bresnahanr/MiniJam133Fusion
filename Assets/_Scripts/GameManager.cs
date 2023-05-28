using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action OnGameOver;

    [SerializeField] private Lab lab;
    [SerializeField] private ResourceBed uraniumBed;

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
