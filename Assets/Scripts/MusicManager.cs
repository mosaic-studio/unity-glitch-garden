using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
	public AudioClip[] levelMusicChangeArray;
	public static MusicManager instance = null;

	private AudioSource _audioSource;

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
			DontDestroyOnLoad(gameObject);
		}
	}

	private void Start()
	{
		if (!_audioSource)
		{
			_audioSource = GetComponent<AudioSource>();
		}

	}

	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}
	
	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}
	
	private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		if (!_audioSource)
		{
			_audioSource = GetComponent<AudioSource>();
		}
		
		AudioClip thisLevelMusic = levelMusicChangeArray[positionArrayMusic(scene.name)];
		Debug.Log("Level Loaded: " + scene.name + " - Mode: " + mode + " - Music: "+
		          thisLevelMusic);
		
		if (thisLevelMusic)
		{
			_audioSource.clip = thisLevelMusic;
			_audioSource.loop = true;
			_audioSource.Play();
		}
	}

	private int positionArrayMusic(string name)
	{
		int position;
		switch (name)
		{
			case "00 Splash Screen":
				position = 0;
				break;
			case "01 Start Menu":
				position = 1;
				break;
			default:
				position = 0;
				break;
		}
		return position;
	}

	public void ChangeVolume(float volume)
	{
		_audioSource.volume = volume;
	}
}
