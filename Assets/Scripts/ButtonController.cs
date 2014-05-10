using UnityEngine;
using System.Collections;

public class ButtonController : TouchButtonController
{
	int x,y, width, height;

	void Start ()
	{
		width = Screen.width / 2;
		height = width / 4;
		x = -(width / 2);
		y = -(height / 2);
		gameObject.guiTexture.pixelInset = new Rect(x,y,width,height);
	}

	void Update () 
	{
		CheckForTouches();
	}

	public override void OnTouchEnded()
	{
		if(this.name == "QuitButton") Application.Quit();
		//if(this.name == "StartButton") Application.LoadLevel("PlayMenu");
		if(this.name == "PlayButton") Application.LoadLevel(ChooseLevel());
		if(this.name == "ContinueButton") 
		{
			GameController.controller.CurrentStreak += 1;
			Application.LoadLevel(ChooseLevel());
		}
		if(this.name == "StatButton") 
		{
			GameController.controller.LastLoadedScene = Application.loadedLevelName;
			Application.LoadLevel("StatScreen");
		}
		if(this.name == "BackButton") Application.LoadLevel(GameController.controller.LastLoadedScene);
		if(this.name == "MainMenuButton") 
		{
			Application.LoadLevel("MainMenu");
			GameController.controller.CurrentStreak = 0;
			GameController.controller.CurrentScore = 0;
		}
		//if(this.name == "PlayAgainButton") Application.LoadLevel("PlayMenu");

		
	}

	string ChooseLevel()
	{
		int temp = Random.Range(0,7);
		string randomLevel;
		switch(temp)
		{
		case 0:case 1: randomLevel = "LevelOne";break;
		case 2:case 3: randomLevel = "LevelTwo";break;
		case 4:case 5: randomLevel = "LevelThree";break;
		case 6: randomLevel = "Bonus";break;
		default: randomLevel = "PlayMenu";break;
		}
		return randomLevel;
	}
}
