using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    // Only begin used for tag

    private StarsDisplay _starsDisplay;

    private void Start()
    {
        _starsDisplay = GameObject.FindObjectOfType<StarsDisplay>();
    }

    public void AddStars(int amout)
    {
        _starsDisplay.AddStars(amout);
    }
}
