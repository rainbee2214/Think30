using UnityEngine;
using System.Collections;

public class MathFunctions : MonoBehaviour 
{
	public float x,y;
	public float a = 1f, b = 1f, c = 0f;
	public bool reset = false;
	public bool stop = false;

	void Update () 
	{
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
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (gameObject.tag == "SinWave")
		{
			Application.LoadLevel("GameOverMenu");
		}
	}


}
