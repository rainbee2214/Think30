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
		if(this.name == "StartButton") Application.LoadLevel("PlayMenu");
		if(this.name == "PlayButton") Application.LoadLevel(ChooseLevel());
		if(this.name == "ContinueButton") 
		{
			Application.LoadLevel(ChooseLevel());
			GameController.controller.CurrentStreak = 1;
		}
		if(this.name == "StatButton") 
		{
			GameController.controller.LastLoadedScene = Application.loadedLevelName;
			Application.LoadLevel("StatScreen");
		}
		if(this.name == "BackButton") Application.LoadLevel(GameController.controller.LastLoadedScene);
		if(this.name == "MainMenuButton") Application.LoadLevel("MainMenu");
		if(this.name == "PlayAgainButton") Application.LoadLevel("PlayMenu");
		
	}

	string ChooseLevel()
	{
		int temp = Random.Range(0,3);
		string randomLevel;
		switch(temp)
		{
		case 0: randomLevel = "LevelOne";break;
		case 1: randomLevel = "LevelTwo";break;
		case 2: randomLevel = "LevelThree";break;
		default: randomLevel = "PlayMenu";break;
		}
		return randomLevel;
	}
}
