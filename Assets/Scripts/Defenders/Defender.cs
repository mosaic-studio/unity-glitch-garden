using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{

    public int startCost = 100;
    
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
