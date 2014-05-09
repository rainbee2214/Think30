using UnityEngine;
using System.Collections;

public class CalculatorButton : TouchButtonController
{
	void Update()
	{
		CheckForTouches();
	}

	public override void OnTouchEnded()
	{
		LevelTwoController.levelTwoController.changeNumber(int.Parse(this.name));
	}
}
