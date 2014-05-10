using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
	public Font font;

	public GameObject CreateGUITextObject(GameObject newObject, string name, Vector3 position)
	{
		position.z = 1;
		newObject.gameObject.transform.position = position;
		newObject.name = name;
		newObject.AddComponent("GUIText");
		newObject.gameObject.guiText.anchor = TextAnchor.MiddleCenter;
		newObject.gameObject.guiText.alignment = TextAlignment.Center;
		newObject.gameObject.guiText.fontSize = 30;
		newObject.gameObject.guiText.font = font;
		
		return newObject;
	}
	public GameObject CreateGUITextObject(GameObject newObject, string name, Vector3 position, int newFontSize)
	{
		position.z = 1;
		newObject.gameObject.transform.position = position;
		newObject.name = name;
		newObject.AddComponent("GUIText");
		newObject.gameObject.guiText.anchor = TextAnchor.MiddleCenter;
		newObject.gameObject.guiText.alignment = TextAlignment.Center;
		newObject.gameObject.guiText.fontSize = newFontSize;
		newObject.gameObject.guiText.font = font;
		
		return newObject;
	}
	public GameObject CreateGUITextObject(GameObject newObject, string name, Vector3 position, int newFontSize, Color newColor)
	{
		position.z = 1;
		newObject.gameObject.transform.position = position;
		newObject.name = name;
		newObject.AddComponent("GUIText");
		newObject.gameObject.guiText.anchor = TextAnchor.MiddleCenter;
		newObject.gameObject.guiText.alignment = TextAlignment.Center;
		newObject.gameObject.guiText.fontSize = newFontSize;
		newObject.gameObject.guiText.color = newColor;
		newObject.gameObject.guiText.font = font;
		
		return newObject;
	}
}
