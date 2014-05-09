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
			gameObject.guiTexture.enabled = false;
		}
		if ((LevelOneController.levelOneController.currentTarget == "Odd") && (int.Parse(this.name)%2 != 0))
		{
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

	void LoseHealth()
	{
		GameController.controller.CurrentHealth = -1;
		loseHealth = false;
	}

}
