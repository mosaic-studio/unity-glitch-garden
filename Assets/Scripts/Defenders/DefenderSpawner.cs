using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DefenderSpawner : MonoBehaviour
{

	public Camera myCamera;

	private GameObject _parent;
	private StarsDisplay _starsDisplay;

	private void Start()
	{
		_parent = GameObject.Find("Defenders");
		_starsDisplay = GameObject.FindObjectOfType<StarsDisplay>();

		if (!_parent)
		{
			_parent = new GameObject("Defenders");
		}
	}

	void OnMouseDown()
	{
		Vector2 rawPos = CalculateWorldPointOfMouseClick();
		Vector2 roundedPos = SnapToGrid(rawPos);
		GameObject goDefender = Button.selectedDefender;
		Quaternion zeroRotation = Quaternion.identity;
		if (goDefender)
		{
			Defender defender = goDefender.GetComponent<Defender>();
			if (_starsDisplay.UseStars(defender.startCost) == StarsDisplay.Status.SUCCESS)
			{
				// Spawn Defender
				GameObject newDef = Instantiate(goDefender, roundedPos, zeroRotation) as GameObject;
				newDef.transform.parent = _parent.transform;
			}
			else
			{
				Debug.Log("Insufficient stars");
			}
		}
	}

	Vector2 SnapToGrid(Vector2 rawWorld)
	{
		float newX = Mathf.RoundToInt(rawWorld.x);
		float newY = Mathf.RoundToInt(rawWorld.y);
		
		return new Vector2(newX, newY);
	}

	Vector2 CalculateWorldPointOfMouseClick()
	{
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

		return worldPos;

	}
}
