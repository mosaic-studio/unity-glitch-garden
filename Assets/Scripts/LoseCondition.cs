using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{

	public GameObject _LevelManagerGameObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		LevelManager levelManager = _LevelManagerGameObject.GetComponent<LevelManager>();
		levelManager.LoadLevel("03b Lose Scene");
	}
}
