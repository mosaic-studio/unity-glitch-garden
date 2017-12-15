using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {
	
	private MusicManager _musicManager;
	

	// Use this for initialization
	void Start () {
		_musicManager = FindObjectOfType<MusicManager>();
		if (_musicManager)
		{
			_musicManager.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
		}
		else
		{
			Debug.LogWarning("Music Manager not found");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
