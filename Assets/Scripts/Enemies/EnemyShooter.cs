using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {
	
	public GameObject bullet;
	public float FireRate;
	public float CollisionRadius;
	public GameObject Alvo;
	
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
		return (Time.time > nextFire) && (PlayerIsVisible());
	}
	
	private bool HasCollidedOnPlayer()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, CollisionRadius);
		
		foreach (Collider2D collider in colliders)
		{
			if (collider.gameObject.Equals(Alvo))
			{
				return true;
			}
		}
		
		return false;
	}

	private void Fire()
	{
		GameObject bala = (GameObject) Instantiate(bullet, transform.position, transform.rotation);
		bala.GetComponent<Bullet>().Alvo = Alvo;
		nextFire = Time.time + FireRate;
	}
	
	private bool PlayerIsVisible()
	{

		GameObject player = GameObject.FindGameObjectWithTag("Player");
		return !player.GetComponent<InvisibilitySkill>().IsExecuting();

	}
	
}
