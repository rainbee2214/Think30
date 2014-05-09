using UnityEngine;
using System.Collections;

public class NumberGenerator : MonoBehaviour 
{
	bool reversed = false;
	string currentTarget;

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
		currentTarget = LevelOneController.levelOneController.currentTarget;
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
			case 0:startingLocation.x = 0.05f;break;
			case 1:startingLocation.x = 0.45f;break;
			case 2:startingLocation.x = 0.85f;break;
			default:startingLocation.x = 0.45f;break;
		}
	}

}
