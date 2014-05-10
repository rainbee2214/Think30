using UnityEngine;
using System.Collections;

public class ScoreTextController : MonoBehaviour 
{

	void Start () 
	{
		gameObject.guiText.text = GameController.controller.CurrentStreak.ToString();
	}
}
