using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {
	
	public GameObject bullet;
	public float FireRate;
	public float CollisionRadius;
	
	private float nextFire;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (CanFire())
		{
			Fire();
		}
	}
	
	private bool CanFire()
	{
		return (Time.time > nextFire) && (HasCollidedOnPlayer()) && (PlayerIsVisible());
	}
	
	private bool HasCollidedOnPlayer()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, CollisionRadius);
		
		foreach (Collider2D collider in colliders)
		{
			if (collider.tag.Equals("Player"))
			{
				return true;
			}
		}
		
		return false;
	}
	
	private void Fire()
	{
		Instantiate(bullet, transform.position, transform.rotation);
		nextFire = Time.time + FireRate;
	}
	
	private bool PlayerIsVisible()
	{

		GameObject player = GameObject.FindGameObjectWithTag("Player");
		return !player.GetComponent<InvisibilitySkill>().IsExecuting();

	}
	
}
