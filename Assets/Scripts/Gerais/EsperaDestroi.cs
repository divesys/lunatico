using UnityEngine;
using System.Collections;

public class EsperaDestroi : MonoBehaviour {
	
	public float LifeTime;
	
	void Awake () {
		Destroy(gameObject, LifeTime);
	}
	
}
