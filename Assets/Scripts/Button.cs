using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

	public GameObject defenderPrefab;
	
	private Button[] _buttons;
	private static GameObject selectedDefender;

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
