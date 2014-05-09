using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
	public int currentLevelScore;
	public int highLevelScore;

	public GameObject ScoreText;
	public string scoreText;
	

	public void SetUpScore()
	{
		ScoreText = new GameObject();
		scoreText = ("Score: " + currentLevelScore);
	}

	public GameObject CreateGUITextObject(GameObject newObject, string name, Vector3 position)
	{
		position.z = 1;
		newObject.gameObject.transform.position = position;
		newObject.name = name;
		newObject.AddComponent("GUIText");
		newObject.gameObject.guiText.anchor = TextAnchor.MiddleCenter;
		newObject.gameObject.guiText.alignment = TextAlignment.Center;
		newObject.gameObject.guiText.fontSize = 30;
		
		return newObject;
	}
}
