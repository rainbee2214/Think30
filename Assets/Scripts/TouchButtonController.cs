using UnityEngine;
using System.Collections;

/*
 * This class is used to check for touches on buttons/GUITextures.
 * Use public ovverride void to define the methods for each button.
 */
public class TouchButtonController : MonoBehaviour 
{

	public void CheckForTouches()
	{
		if (Input.touches.Length <= 0)
		{
			OnNoTouches();
		}
		else
		{
			for (int i = 0; i < Input.touches.Length; i++)
			{
				if(this.guiTexture != null  && (this.guiTexture.HitTest(Input.GetTouch(i).position)))
				{
					if (Input.GetTouch(i).phase == TouchPhase.Began){ OnTouchBegan(); }
					if (Input.GetTouch(i).phase == TouchPhase.Ended){ OnTouchEnded(); }
				}
			}
		}
	}

	public virtual void OnNoTouches(){}
	public virtual void OnTouchBegan(){}
	public virtual void OnTouchEnded(){}
}
