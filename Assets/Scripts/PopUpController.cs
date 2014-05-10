using UnityEngine;
using System.Collections;

public class PopUpController : MonoBehaviour 
{
	public bool show;


	void Start ()
	{
		gameObject.guiText.text = "";
	}

	void Update () 
	{
	

		if (show) 
		{
			if (gameObject.name == "SorryPopup")
				gameObject.guiText.text = "Sorry!";
			if (gameObject.name == "GoodJobPopup")
				gameObject.guiText.text = "Good Job!";
		}
		else //(!show)
		{
			if (gameObject.name == "SorryPopup")
				gameObject.guiText.text = "";
			if (gameObject.name == "GoodJobPopup")
				gameObject.guiText.text = "";
		}
		
	}


}
