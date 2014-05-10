using UnityEngine;
using System.Collections;

public class GridButton : TouchButtonController
{
	public bool achieved = false;

	void Start () 
	{
		if (!achieved) gameObject.guiTexture.enabled = false;
	}

	void Update()
	{
		if (achieved)
		{
			gameObject.guiTexture.enabled = true;
			CheckForTouches();
		}
	}
}
