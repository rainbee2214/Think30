using UnityEngine;
using System.Collections;

public class NumberButton : TouchButtonController
{

	string lastNumberTouched;
	bool loseHealth;

	public void Update()
	{
		CheckForTouches();
	}

	public override void OnTouchBegan()
	{
		if ((LevelOneController.levelOneController.currentTarget == "Even") && (int.Parse(this.name)%2 == 0))
		{
			if (Application.loadedLevelName == "LevelOne")GameController.controller.CurrentScore += 1;
			gameObject.guiTexture.enabled = false;
		}
		if ((LevelOneController.levelOneController.currentTarget == "Odd") && (int.Parse(this.name)%2 != 0))
		{
			if (Application.loadedLevelName == "LevelOne")GameController.controller.CurrentScore += 1;
			gameObject.guiTexture.enabled = false;
		}
		if ((LevelOneController.levelOneController.currentTarget == "Even") && (int.Parse(this.name)%2 != 0))
		{
			loseHealth = true;
		}
		if ((LevelOneController.levelOneController.currentTarget == "Odd") && (int.Parse(this.name)%2 == 0))
		{
			loseHealth = true;
		}
		if (loseHealth) LoseHealth();
	}

	public override void OnTouchEnded()
	{
		if (((LevelOneController.levelOneController.currentTarget == "Even") && (int.Parse(this.name)%2 == 0)) ||
			((LevelOneController.levelOneController.currentTarget == "Odd") && (int.Parse(this.name)%2 != 0)))
		{
			GameController.controller.CurrentScore += 1;
		}
		else
			GameController.controller.CurrentScore -= 1;
	}
	void LoseHealth()
	{
		GameController.controller.CurrentHealth = -1;
		loseHealth = false;
	}

}
