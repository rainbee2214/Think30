using UnityEngine;
using System.Collections;

public class GUITextController : MonoBehaviour 
{
		
	void Update () 
	{
		if (this.name == "BestStreakText") 
			gameObject.guiText.text = GameController.controller.BestStreak.ToString();
		if (this.name == "CurrentStreakText")
			gameObject.guiText.text = GameController.controller.CurrentStreak.ToString();
		if (this.name == "HighScoreText")
			gameObject.guiText.text = GameController.controller.HighScore.ToString();
		if (this.name == "CurrentScoreText")
			gameObject.guiText.text = GameController.controller.CurrentScore.ToString();
	}
}
