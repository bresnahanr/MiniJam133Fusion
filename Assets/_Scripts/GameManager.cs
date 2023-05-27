using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        GameState.Money = new Resource(ResourceType.Money);
        GameState.Uranium = new Resource(ResourceType.Uranium);
    }

    public void Restart()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    public void QuitGame()
	{
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
