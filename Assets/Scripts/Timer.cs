using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	public float gameLength = 1;
	private float targetTime;
	void Start () 
	{
		targetTime = gameLength + Time.time;
	}

	void Update () 
	{
		if (Time.time > targetTime) EndLevel();
	}

	void EndLevel ()
	{
		Application.LoadLevel("GameMenu");
	}
}
