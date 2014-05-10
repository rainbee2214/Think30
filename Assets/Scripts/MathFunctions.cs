using UnityEngine;
using System.Collections;

public class MathFunctions : LevelController
{
	public float x,y;
	public float a = 1f, b = 1f, c = 0f;
	public bool reset = false;
	public bool stop = false;

	string functionText;
	GameObject FunctionText;

	void Start ()
	{
		if (gameObject.name == "SinWave")
		{
			FunctionText = new GameObject();
			FunctionText = CreateGUITextObject(FunctionText, "FunctionText", new Vector3(0.5f,0.95f,1), 30, Color.white);
			functionText = (a + "sin(" + b + "x) + " + c);
		}

	}
	         
	void Update () 
	{
		functionText = ("y = " + a + " sin (" + b + " x) + " + c);
		if (reset) resetGrid();
		if (!stop)drawSin(a,b,c);
	}

	void resetGrid()
	{
		x = 0;
		y = 0;
		reset = false;
	}

	void drawSin(float a = 1f, float b = 1f, float c = 0f)
	{
		x += 0.1f;
		y = a * (Mathf.Sin(b * (rigidbody2D.transform.position.x)) + c);
		rigidbody2D.transform.position = new Vector2(x,y);

		if (gameObject.name == "SinWave")FunctionText.guiText.text = functionText;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (gameObject.tag == "SinWave")
		{
			if (other.tag == "Powerup")
			{
				GetComponent<TrailController>().ChangeTail(0.1f);
			}
			else if (other.tag == "Wall")
			{
				Application.LoadLevel("GameOverMenu");
			}

		}
	}


}
