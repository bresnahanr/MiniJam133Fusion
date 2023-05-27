using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
	public GameObject gameOverUI;
	public TMP_Text scoreText;

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

	public void ShowUI()
	{
		Time.timeScale = 0f;
		scoreText.text = $"You lasted {TimeController.Day} Days!";
		gameOverUI.SetActive(true);
	}

	public void Restart()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void QuitGame()
	{
		Debug.Log("Quitting Game");
		Application.Quit();
	}

}
