using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Wait5Seconds());
	}
	
	IEnumerator Wait5Seconds()
	{
		Debug.Log(Time.time);
		yield return new WaitForSeconds(5);
		Debug.Log(Time.time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
