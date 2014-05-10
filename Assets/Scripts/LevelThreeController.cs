using UnityEngine;
using System.Collections;

public class LevelThreeController : LevelController
{
	public static LevelThreeController levelThreeController;
	
	GameObject[] popups = new GameObject[2];
	enum Popup {GoodJob, Sorry};
	public GameObject goodJob, sorry;
	
	public GameObject levelThreeButton;
	public GameObject cursor;
	public Sprite[] numbers;
	public bool changeOne = true;
	
	GameObject targetCursor;
	Vector3 startingLocation;
	GameObject[] calculatorButtons = new GameObject[9];
	GameObject[] calculatorNumbers = new GameObject[9];
	
	int x,y, width, height;
	string currentOperator;
	public int currentNumberOne, currentNumberTwo, answer, realAnswer = -1; 
	
	string operatorText, numberOne, numberTwo, answerText;
	GameObject OperatorText, NumberOne, NumberTwo, AnswerText;
	
	
	void Start()
	{
		levelThreeController = this;
		OperatorText = new GameObject();
		NumberOne = new GameObject();
		NumberTwo = new GameObject();
		AnswerText = new GameObject();
		OperatorText =  CreateGUITextObject(OperatorText, "OperatorText", new Vector3(0.5f,0.9f,1),60);
		NumberOne =  CreateGUITextObject(NumberOne, "NumberOne", new Vector3(0.3f,0.9f,1),60);
		NumberTwo =  CreateGUITextObject(NumberTwo, "NumberTwo", new Vector3(0.7f,0.9f,1),60);
		AnswerText = CreateGUITextObject(AnswerText, "AnswerText", new Vector3(0.5f,0.8f,1),60);
		
		CreatePopups();
		targetCursor = Instantiate(cursor, new Vector3(0.5f,0.8f,1f),Quaternion.identity) as GameObject;
		targetCursor.name = "TargetCursor";
		
		currentOperator = GetOperator();
		currentNumberOne = Random.Range(0,4);
		currentNumberTwo = Random.Range(0,5);
		realAnswer = GetRealAnswer();
		
		GenerateCalculator();
	}
	
	float delay = 0.5f;
	float currentTime, targetTime;
	void Update () 
	{
		for (int i = 0; i < 300;i++)
		{
			Debug.Log(i);
			if(Time.time > 6)
				break;
		}
		OperatorText.gameObject.guiText.text = currentOperator;
		NumberOne.gameObject.guiText.text = currentNumberOne.ToString();
		NumberTwo.gameObject.guiText.text = currentNumberTwo.ToString();

		if (answer > 0)
			AnswerText.gameObject.guiText.text = ( "= " + answer.ToString() + " ?");
		else
			AnswerText.gameObject.guiText.text = "=        ?";
	
		if (answer == realAnswer)
		{
			GameController.controller.CurrentScore += 1;
			currentTime = Time.time;
			targetTime = currentTime + delay;
			popups[0].gameObject.GetComponent<PopUpController>().show = true;
			answer = 0;

			currentNumberOne = Random.Range(0,4);
			currentNumberTwo = Random.Range(0,5);
			realAnswer = GetRealAnswer();
				
		}
		popups[0].gameObject.GetComponent<PopUpController>().show = false;

	}
	

	
	public void GenerateCalculator ()
	{
		width = Screen.width / 4;
		height = width;
		x = -(width / 2);
		y = -(height / 2);
		
		startingLocation = new Vector3(0.2f, 0.5f, 0f);
		int k = 0;
		int l = 0;
		for (int i = 0; i < calculatorButtons.Length; i++)
		{
			startingLocation.x = 0.2f + (0.3f * k);
			k++;
			if (k == 3) k = 0;
			if (i == 0 || i == 3 || i == 6)
			{
				startingLocation.y = 0.5f - (0.2f * l);
				l++;
			}
			calculatorButtons[i] = Instantiate(levelThreeButton, startingLocation, Quaternion.identity) as GameObject;
			calculatorButtons[i].gameObject.guiTexture.pixelInset = new Rect(x,y,width,height);
			calculatorButtons[i].name = (i+1).ToString();
			
			calculatorNumbers[i] = new GameObject();
			calculatorNumbers[i] = CreateGUITextObject(calculatorNumbers[i], (i+1).ToString(), startingLocation);
			calculatorNumbers[i].guiText.text = (i+1).ToString();
			calculatorNumbers[i].guiText.color = Color.black;
		}
	}

	int GetRealAnswer()
	{
		int temp = 0;
		switch(currentOperator)
		{
		case "+":
			temp = (currentNumberOne + currentNumberTwo);
			break;
		case "-":
			temp = (currentNumberOne - currentNumberTwo);
			break;
		case "*":
			temp = (currentNumberOne * currentNumberTwo);
			break;
		case "/":
			temp = (currentNumberOne / currentNumberTwo);
			break;
		}
		return temp;
	}

	public string GetOperator()
	{
		string op = "+";
		return op;
	}
	
	void CreatePopups()
	{
		popups[0] = Instantiate(goodJob, new Vector3(0.5f, 0.65f,1f), Quaternion.identity) as GameObject;
		popups[1] = Instantiate(sorry, new Vector3(0.5f, 0.75f,1f), Quaternion.identity) as GameObject;
		popups[0].name = "GoodJobPopup";
		popups[1].name = "SorryPopup";
	}
}
