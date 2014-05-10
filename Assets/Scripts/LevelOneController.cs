using UnityEngine;
using System.Collections;

public class LevelOneController : LevelController 
{
	public static LevelOneController levelOneController;

	public string currentTarget;
	string targetText;
	GameObject TargetText;
	bool reversed = false;

	
	public GameObject number;
	public float numberFallSpeed;
	public int numberPoolAmount;
	public Color[] colours;
	public Texture[] numbersTextures;
	
	GameObject[] numbers;
	Vector2 startingLocation, startingLocationReversed;
	float startingY = 1f;

	void Start () 
	{
		levelOneController = this;
		TargetText = new GameObject();
		currentTarget = ChangeTarget();
		targetText = ("Target Numbers: " + currentTarget);
		SetUpScore();
		TargetText = CreateGUITextObject(TargetText, "TargetText", new Vector3(0.5f,0.9f,1));

		numbers = new GameObject[numberPoolAmount];
		for(int i = 0; i < numbers.Length; i++)
		{
			GetPosition(i);
			
			numbers[i] = Instantiate(number, startingLocation, Quaternion.identity) as GameObject;
			numbers[i].rigidbody2D.velocity = new Vector2(0f, -numberFallSpeed);
			
			SetNumbers(i);
		}
	}

	void Update () 
	{
		currentLevelScore++;
		TargetText.gameObject.guiText.text = targetText;

		for (int i = 0; i < numbers.Length; i++)
		{
			if (numbers[i].gameObject.transform.position.y <= 0)
			{
				GetPosition(i);
				SetNumbers(i);
				numbers[i].gameObject.transform.position = startingLocation;
				numbers[i].gameObject.guiTexture.enabled = true;
			}
		}
	}

	string ChangeTarget()
	{
		string target = "";
		switch(Random.Range(0,2))
		{
		case 0: target = "Even"; break;
		case 1: target = "Odd"; break;
		//case 2: target = "Prime"; break;
		}
		return target;
	}

	void SetNumbers(int i)
	{
		numbers[i].guiTexture.color = colours[Random.Range(0, colours.Length)];
		int tempNumber = Random.Range(1,numbersTextures.Length);
		numbers[i].gameObject.guiTexture.texture = numbersTextures[tempNumber];
		numbers[i].name = (tempNumber.ToString());
	}
	
	void GetPosition(int i)
	{
		startingLocation.y = startingY;
		switch(i)
		{
		case 0:startingLocation.x = 0.15f;break;
		case 1:startingLocation.x = 0.45f;break;
		case 2:startingLocation.x = 0.75f;break;
		default:startingLocation.x = 0.45f;break;
		}
	}

}
