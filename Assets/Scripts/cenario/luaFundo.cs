using UnityEngine;
using System.Collections;

public class luaFundo : MonoBehaviour 
{

	public GameObject referenciaLuna;
	private float posicaoLunaAtualX;
	private float posicaoLunaAnteriorX;
	private float diferencaPosicaoLunaX;
	public float fatorAjusteParallax;
	private float posicaoAjusteX;
	private float posicaoFinalX;
	public float posicaoY;

	// Use this for initialization
	void Start () 
	{

		referenciaLuna = GameObject.FindWithTag("Player");
		posicaoLunaAnteriorX = referenciaLuna.transform.position.x;
//		posicaoAjusteX = -5;
//		fatorAjusteParallax = 2;
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		posicaoLunaAtualX = referenciaLuna.transform.position.x;
		posicaoY = this.transform.position.y;

		if(posicaoLunaAtualX != posicaoLunaAnteriorX)
		{
			diferencaPosicaoLunaX = posicaoLunaAtualX - posicaoLunaAnteriorX;

			posicaoAjusteX = posicaoAjusteX + (diferencaPosicaoLunaX  / fatorAjusteParallax);
		
		}

		posicaoFinalX = posicaoLunaAtualX + posicaoAjusteX;

		this.transform.position = new Vector3( posicaoFinalX, posicaoY, 0);

		posicaoLunaAnteriorX = referenciaLuna.transform.position.x;
	
	}
}
