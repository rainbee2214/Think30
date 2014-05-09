using UnityEngine;
using System.Collections;

public class AchievementController : MonoBehaviour 
{
	int achievementsAmount = 5;
	int levelAmount = 6;

	public static AchievementController achievementController;
	public static GameObject[][] achievements;

	public GameObject gridButton;
	public Color[] colours;

	void Start()
	{
		achievementController = this;

		achievements = new GameObject[levelAmount][];
		for (int k = 0; k < levelAmount; k++)
		{
			achievements[k] = new GameObject[achievementsAmount];
		}

		Vector2 location = new Vector2(0.3f, 0.7f);
		for (int x = 0; x < levelAmount; x++)
		{
			for (int y = 0; y < achievementsAmount; y++)
			{
				location.x = (0.12f)*y + 0.3f;
				achievements[x][y] = Instantiate(gridButton, location, Quaternion.identity ) as GameObject;
				achievements[x][y].guiTexture.color = colours[x+1];
				achievements[x][y].name = ("Level" + (x+1) + "Achievement" + (y+1));

			}
			location.y -= 0.1f;
		}
	}

	public static void SetAchieved(int x, int y)
	{
		AchievementController.achievements[x][y].GetComponent<GridButton>().achieved = true;
	}
}
