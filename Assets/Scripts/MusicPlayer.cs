﻿using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	public static MusicPlayer instance = null;


	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			Debug.Log("Duplicate music player self-destructing!");
		}
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
