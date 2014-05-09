using UnityEngine;
using System.Collections;

public class PopUpController : MonoBehaviour 
{
	public bool show;

	public Color originalColor;
	public Color lerpColor;
	float timeLength = 0.01f;

	void FixedUpdate () 
	{
		lerpColor = Color.Lerp(originalColor, Camera.main.backgroundColor, timeLength);
		gameObject.guiText.color = lerpColor;
		timeLength += 0.02f;
		if (show) 
		{
			show = false;
			timeLength = 0.01f;
		}
	}


}
