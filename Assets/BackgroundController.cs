using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour 
{
	public Color[] colors;

	int currentColor;
	SpriteRenderer spriteRenderer;

	void Start()
	{
		currentColor = Random.Range(0,colors.Length);
		spriteRenderer = GetComponent("SpriteRenderer") as SpriteRenderer;
		spriteRenderer.color = colors[currentColor]; 
	}

}
