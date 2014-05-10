using UnityEngine;
using System.Collections;

public class PowerupGenerator : MonoBehaviour 
{
	public GameObject powerup;
	int amountOfPowerups = 20;

	GameObject[] powerups;
	Vector3 location;

	float lower, higher;
	void Start () 
	{
		lower = -((Camera.main.orthographicSize/2)-1);
		higher = -lower;
		location = new Vector3(0f,0f,0f);
		powerups = new GameObject[amountOfPowerups];
		for (int i = 0; i < powerups.Length; i++)
		{
			powerups[i] = Instantiate(powerup,location, Quaternion.identity) as GameObject;
			location.x += 10;
			location.y = (Random.Range(lower, higher));
		}
	}

}
