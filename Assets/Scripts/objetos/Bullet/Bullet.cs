using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public float Speed;
	
	private GameObject player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("player");
		transform.LookAt(player.transform);
	}
	
	// Update is called once per frame
	void Update () {
		float adjustedSpeed = Speed * Time.deltaTime;
		transform.Translate (0, 0, adjustedSpeed);
	}
	
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.Equals(player))
		{
			//Destroy(player);
		}
	}
	
}
