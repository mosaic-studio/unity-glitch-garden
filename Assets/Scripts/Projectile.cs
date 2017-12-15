﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

	public float speed, damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		GameObject obj = other.gameObject;
		if (!obj.GetComponent<Attacker>())
		{
			return;
		}
		
		Health health = obj.GetComponent<Health>();
		if (health)
		{
			health.DealDamage(damage);
			Destroy(gameObject);
		}
	}
}
