﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour
{
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator _animator;

	// Use this for initialization
	void Start ()
	{
		_animator = GetComponent<Animator>();
	}
	
	void Update () {
		// Walk 
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget)
		{
			_animator.SetBool("isAttacking", false);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		
	}

	public void SetSpeed(float speed)
	{
		currentSpeed = speed;
	}

	// Called from the animator at time of actual blow
	public void StrikeCurrentTarget(float damage)
	{
		Debug.Log(name + " causade damage: " + damage);
		if (currentTarget)
		{
			Health health = currentTarget.GetComponent<Health>();
			if (health)
			{
				health.DealDamage(damage);
			}
		}
	}

	public void Attack(GameObject obj)
	{
		currentTarget = obj;
	}
}
