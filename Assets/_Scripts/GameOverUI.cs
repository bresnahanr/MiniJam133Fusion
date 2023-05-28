using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/**
 * GameOverUI
 * 
 * A Unity class that handles the display and functionality of the Game Over UI panel.
 * 
 * Panel is disabled at scene launch and is enabled by the Game Manager's "OnGameOver" event.
 * Provides user with a sessional score and ability to replay or exit the game.
 * 
 * Example Usage:
 * 1. Attach this script to a GameObject such as the canvas in your Unity scene.
 * 2. Drag corresponding menu panel GameObject and "Score" TextMeshPro object to the inspector.
**/

public class GameOverUI : MonoBehaviour
{
	public GameObject gameOverUI;
	public TMP_Text scoreText;

	// Ensures that menu is initially disabled on scene load
	private void Awake()
	{
		gameOverUI.SetActive(false);
	}

	private void OnEnable()
	{
		GameManager.OnGameOver += ShowUI;
	}

	private void OnDisable()
	{
		GameManager.OnGameOver -= ShowUI;
	}

	// Freezes in-game time and displays menu UI
	public void ShowUI()
	{
		Time.timeScale = 0f;
		scoreText.text = $"You lasted {TimeController.Day} Days!";
		gameOverUI.SetActive(true);
	}

	// Unfreezes in-game time and reloads current scene
	public void Restart()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	// Closes application
	public void QuitGame()
	{
		Debug.Log("Quitting Game");
		Application.Quit();
	}

}
