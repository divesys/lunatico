using UnityEngine;
using System.Collections;

public class luaFundo : MonoBehaviour 
{

	public GameObject referenciaLuna;
	private float posicaoLunaX;
	public float posicaoAjusteX;
	public float posicaoFinalX;
	public float posicaoY;

	// Use this for initialization
	void Start () 
	{

		referenciaLuna = GameObject.FindWithTag("Player");
		posicaoAjusteX = 3;
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		posicaoLunaX = referenciaLuna.transform.position.x;
		posicaoFinalX = posicaoLunaX + posicaoAjusteX;
		posicaoY = this.transform.position.y;

		this.transform.position = new Vector3( posicaoFinalX, posicaoY, 0);
	
	}
}
