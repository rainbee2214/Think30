using UnityEngine;
using System.Collections;

public class LevelOneController : LevelController 
{
	public static LevelOneController levelOneController;

	public string currentTarget;
	string targetText;
	GameObject TargetText;

	void Start () 
	{
		levelOneController = this;
		TargetText = new GameObject();
		currentTarget = ChangeTarget();
		targetText = ("Target Numbers: " + currentTarget);
		SetUpScore();
		TargetText = CreateGUITextObject(TargetText, "TargetText", new Vector3(0.5f,0.9f,1));
		ScoreText = CreateGUITextObject(ScoreText, "ScoreText", new Vector3(0.5f,0.1f,1));
	}

	void Update () 
	{
		currentLevelScore++;
		TargetText.gameObject.guiText.text = targetText;
		ScoreText.gameObject.guiText.text = scoreText;
	}

	string ChangeTarget()
	{
		string target = "";
		switch(Random.Range(0,2))
		{
		case 0: target = "Even"; break;
		case 1: target = "Odd"; break;
		//case 2: target = "Prime"; break;
		}
		return target;
	}

}
