using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public static GameController controller;

	private bool isGameOver;
	public bool IsGameOver
	{
		get{return isGameOver;}
		set{isGameOver = value;}
	}
	private string lastLoadedScene;
	public string LastLoadedScene
	{
		get{return lastLoadedScene;}
		set{lastLoadedScene = value;}
	}

	private float currentScore;
	public float CurrentScore
	{
		get{return currentScore;}
		set{currentScore = value;}
	}

	private float highScore;
	public float HighScore
	{
		get{return highScore;}
		set{highScore = value;}
	}

	private int currentStreak;
	public int CurrentStreak
	{
		get{return currentStreak;}
		set{currentStreak = value;}
	}

	private int bestStreak;
	public int BestStreak
	{
		get{return bestStreak;}
		set{bestStreak = value;}
	}

	private int currentHealth;
	public int CurrentHealth
	{
		get{return currentHealth;}
		set{currentHealth += value;}
	}

	private int maxHealth;
	public int MaxHealth
	{
		get{return maxHealth;}
		set{maxHealth = value;}
	}
	
	void Start () 
	{
		controller = this;
		MaxHealth = 3;
		CurrentHealth = MaxHealth;
	}

	void Update () 
	{
		if (CurrentHealth == 0) isGameOver = true;
		if (isGameOver) GameOver();
		if (CurrentScore > HighScore) HighScore = CurrentScore;
		if (CurrentStreak > BestStreak) BestStreak = CurrentStreak;
	}

	void Awake () 
	{
		if (controller == null)
		{
			DontDestroyOnLoad(gameObject);
			controller = this;
		}
		else if(controller != this)
		{
			Destroy (gameObject);
		}
	}

	void GameOver()
	{
		currentScore = 0;
		isGameOver = false;
		CurrentHealth = MaxHealth;
		Application.LoadLevel("MainMenu");
	}
}
