using UnityEngine;
using System.Collections;

public class LevelThreeButton : TouchButtonController
{
	void Update()
	{
		CheckForTouches();
	}
	
	public override void OnTouchEnded()
	{
		LevelThreeController.levelThreeController.answer = (int.Parse(this.name));
	}
}
