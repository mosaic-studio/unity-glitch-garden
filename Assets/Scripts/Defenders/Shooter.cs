using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator _animator;
	private AttackerSpawner myLaneSpawner;


	private void Start()
	{
		_animator = GameObject.FindObjectOfType<Animator>();
		
		projectileParent = GameObject.Find("Projectiles");
		if (!projectileParent)
		{
			projectileParent = new GameObject("Projectiles");
		}
		SetMyLaneSpawner();
//		print(myLaneSpawner);
	}

	private void Update()
	{
		if (IsAttackerAheadInLane())
		{
			_animator.SetBool("isAttacking", true);
		}
		else
		{
			_animator.SetBool("isAttacking", false);
		}
	}

	void SetMyLaneSpawner()
	{
		AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
		foreach (AttackerSpawner spawner in attackerSpawners)
		{
			if (spawner.transform.position.y == transform.position.y)
			{
				myLaneSpawner = spawner;
				return;
			} 
		}
		
		Debug.LogError(name + " can't find the spawner");
	}

	bool IsAttackerAheadInLane()
	{
		if (myLaneSpawner.transform.childCount <= 0)
		{
			return false;
		}
		foreach (Transform attacker in myLaneSpawner.transform)
		{
			if (attacker.transform.position.x > transform.position.x)
			{
				return true;
			}
		}

		return false;
	}

	private void Fire()
	{
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
