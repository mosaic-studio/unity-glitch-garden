﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
{

	private Animator _animator;
	private Attacker _attacker;
	
	// Use this for initialization
	void Start ()
	{
		_animator = GetComponent<Animator>();
		_attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		GameObject obj = other.gameObject;
		// Leave the method if not colliding with the defender
		if (!obj.GetComponent<Defender>())
		{
			return;
		}
		if (obj.GetComponent<Stone>())
		{
			_animator.SetTrigger("jumpTrigger");
		}
		else
		{
			_animator.SetBool("isAttacking", true);
			_attacker.Attack(obj);
		}
		Debug.Log("FOX collide with " + other);
	}
}
