using UnityEngine;
using System.Collections;

public class TrailController : MonoBehaviour 
{
	TrailRenderer trail;
	float tailLength = 0.1f;

	void Start()
	{
		trail = (TrailRenderer)GetComponent("TrailRenderer");
		trail.time = tailLength;
	}

	void Update ()
	{
		trail.time = tailLength;
	}

	public void ChangeTail(float change)
	{
		tailLength += change;
		if (tailLength < 0.1f) tailLength = 0.1f;
		if (tailLength > 2f) tailLength = 2f;
	}
}
