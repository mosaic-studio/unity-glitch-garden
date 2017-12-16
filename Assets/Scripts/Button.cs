using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;
	
	private Button[] _buttons;

	// Use this for initialization
	void Start ()
	{
		_buttons = FindObjectsOfType<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
//		Debug.Log(name + " Clicked!");
		foreach (Button thisButton in _buttons)
		{
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}

	
}
