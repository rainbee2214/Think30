using UnityEngine;
using System.Collections;

public class PowerupController : MonoBehaviour 
{
	void OnTriggerEnter2D()
	{
		gameObject.guiTexture.enabled = false;
	}
}
