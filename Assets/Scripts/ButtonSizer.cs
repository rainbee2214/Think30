using UnityEngine;
using System.Collections;

public class ButtonSizer : MonoBehaviour 
{
	int x,y, width, height;

	void SizeButtons ()
	{
		width = Screen.width / 2;
		height = width / 3;
		x = -(width / 2);
		y = -(height / 2);
		gameObject.guiTexture.pixelInset = new Rect(x,y,width,height);
	}

}
