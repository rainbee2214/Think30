using UnityEngine;
using System.Collections;

public class LevelTwoController : LevelController
{
	GameObject[] popups = new GameObject[2];
	public GameObject goodJob, sorry;
	public static LevelTwoController levelTwoController;
	public GameObject calculatorButton;
	public GameObject cursor;
	public Sprite[] numbers;
	
	public bool changeOne = true;
	GameObject targetCursor;

	Vector3 startingLocation;
	GameObject[] calculatorButtons = new GameObject[9];
	GameObject[] calculatorNumbers = new GameObject[9];

	GUIText number;
	int x,y, width, height;

	string currentOperator;

	int currentNumberOne; 

	int answer;
	int currentNumberTwo;

	string operatorText, numberOne, numberTwo, answerText;
	GameObject OperatorText, NumberOne, NumberTwo, AnswerText;

	enum Popup {GoodJob, Sorry};

	void Start()
	{
		
		popups[0] = Instantiate(goodJob, new Vector3(0.5f, 0.7f,1f), Quaternion.identity) as GameObject;
		popups[1] = Instantiate(sorry, new Vector3(0.5f, 0.7f,1f), Quaternion.identity) as GameObject;
		popups[0].name = "GoodJobPopup";
		popups[1].name = "SorryPopup";
		targetCursor = Instantiate(cursor, new Vector3(0.3f,0.9f,1f),Quaternion.identity) as GameObject;
		targetCursor.name = "TargetCursor";

		answer = Random.Range(2,10);
		//Debug.Log(answer);
		levelTwoController = this;
		OperatorText = new GameObject();
		NumberOne = new GameObject();
		NumberTwo = new GameObject();
		AnswerText = new GameObject();

		currentOperator = "+";
		currentNumberOne = 0;
		currentNumberTwo = 0;
		OperatorText =  CreateGUITextObject(OperatorText, "OperatorText", new Vector3(0.5f,0.9f,1));
		NumberOne =  CreateGUITextObject(NumberOne, "NumberOne", new Vector3(0.3f,0.9f,1));
		NumberTwo =  CreateGUITextObject(NumberTwo, "NumberTwo", new Vector3(0.7f,0.9f,1));
		AnswerText = CreateGUITextObject(AnswerText, "AnswerText", new Vector3(0.5f,0.8f,1));
		GenerateCalculator();
	}

	void Update () 
	{


		OperatorText.gameObject.guiText.text = currentOperator;

		if (currentNumberOne != 0)
			NumberOne.gameObject.guiText.text = currentNumberOne.ToString();
		else
			NumberOne.gameObject.guiText.text = "";
		if (currentNumberTwo != 0)
			NumberTwo.gameObject.guiText.text = currentNumberTwo.ToString();
		else
			NumberTwo.gameObject.guiText.text = "";
		AnswerText.gameObject.guiText.text = ( "= " + answer.ToString());
	}


	public void changeNumber(int newNumber)
	{
		Vector3 newPosition = new Vector3(0f,0.9f,1f);
		if (changeOne)
		{
			newPosition.x = 0.7f;
			changeOne = false;
			currentNumberOne = newNumber;
		}
		else // change two
		{
			newPosition.x = 0.3f;
			changeOne = true;
			currentNumberTwo = newNumber;
			if (CheckAnswer(currentOperator, currentNumberOne, currentNumberTwo, answer))
			{
				answer = Random.Range(2,10);
				popups[0].gameObject.GetComponent<PopUpController>().show = true;
			}
			else
			{
				popups[1].gameObject.GetComponent<PopUpController>().show = true;
			}
			currentNumberOne = 0;
			currentNumberTwo = 0;

		}
		targetCursor.gameObject.transform.position = newPosition;
	}

	bool CheckAnswer(string curOperator, int numOne, int numTwo, int ans)
	{
		bool yes = false;
		switch(curOperator)
		{
		case "+":
			if ((numOne + numTwo) == ans) yes = true;
			break;
		case "-":
			if ((numOne - numTwo) == ans) yes = true;
			break;
		case "*":
			if ((numOne * numTwo) == ans) yes = true;
			break;
		case "/":
			if ((numOne / numTwo) == ans) yes = true;
			break;
		}
		return yes;
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
			calculatorButtons[i] = Instantiate(calculatorButton, startingLocation, Quaternion.identity) as GameObject;
			calculatorButtons[i].gameObject.guiTexture.pixelInset = new Rect(x,y,width,height);
			calculatorButtons[i].name = (i+1).ToString();
			
			calculatorNumbers[i] = new GameObject();
			calculatorNumbers[i] = CreateGUITextObject(calculatorNumbers[i], (i+1).ToString(), startingLocation);
			calculatorNumbers[i].guiText.text = (i+1).ToString();
			calculatorNumbers[i].guiText.color = Color.black;
		}
	}


}
