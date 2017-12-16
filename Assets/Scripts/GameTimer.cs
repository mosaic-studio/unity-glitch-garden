using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

	public float levelSeconds = 100;
	public LevelManager levelManager;
	
	private Slider _slider;
	private AudioSource _audioSource;
	private bool isEndOfLevel = false;
	private GameObject _winLabel;

	// Use this for initialization
	void Start ()
	{
		_slider = GetComponent<Slider>();
		_audioSource = GetComponent<AudioSource>();
		FindYouWin();
		_winLabel.SetActive(false);
	}

	private void FindYouWin()
	{
		_winLabel = GameObject.Find("Win Text");
		if (!_winLabel)
		{
			Debug.LogWarning("Please create You Win object");
		}
	}

	// Update is called once per frame
	void Update ()
	{
		_slider.value = Time.timeSinceLevelLoad / levelSeconds;

		bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
		if (timeIsUp && !isEndOfLevel)
		{
			_audioSource.Play();
			_winLabel.SetActive(true);
			Invoke("LoadNextValue", _audioSource.clip.length);
			isEndOfLevel = true;
		}
	}

	void LoadNextValue()
	{
		levelManager.LoadNextLevel();
	}
}
