using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
	[Range(-1f, 1.5f)]
	public float currentSpeed;

	// Use this for initialization
	void Start ()
	{
		Rigidbody2D myRigidbody2D = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody2D.isKinematic = true;
	}
	
	void Update () {
		// Walk 
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(name + " collide with " + other);
	}

	public void SetSpeed(float speed)
	{
		currentSpeed = speed;
	}

	public void StrikeCurrentTarget(float damage)
	{
		Debug.Log(name + " causade damage: " + damage);
	}
}
