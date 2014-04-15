using UnityEngine;
using System.Collections;

public class luaFundo : MonoBehaviour 
{

	public GameObject referenciaLuna;
	private float posicaoLunaAtualX;
	public float fatorAjusteParallax;
	public float posicaoAjusteX;
	private float posicaoFinalX;
	public float posicaoY;

	// Use this for initialization
	void Start () 
	{

		referenciaLuna = GameObject.FindWithTag("Player");
//		posicaoAjusteX = -5;
//		fatorAjusteParallax = 2;
		posicaoY = this.transform.position.y;
		posicaoLunaAtualX = referenciaLuna.transform.position.x;
		posicaoFinalX = posicaoLunaAtualX + posicaoAjusteX;

		this.transform.position = new Vector2( posicaoFinalX, posicaoY );
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		posicaoLunaAtualX = referenciaLuna.transform.position.x;
		posicaoY = this.transform.position.y;

		if(referenciaLuna.transform.rigidbody2D.velocity.x > 0.01)
		{

			posicaoAjusteX = posicaoAjusteX + (referenciaLuna.transform.rigidbody2D.velocity.x / fatorAjusteParallax);

			posicaoFinalX = posicaoLunaAtualX + posicaoAjusteX;

		
		}

		if(referenciaLuna.transform.rigidbody2D.velocity.x < 0.01)
		{
			
			posicaoAjusteX = posicaoAjusteX + (referenciaLuna.transform.rigidbody2D.velocity.x / fatorAjusteParallax);
			
			posicaoFinalX = posicaoLunaAtualX + posicaoAjusteX;
		
			
		}

		this.transform.position = new Vector2( posicaoFinalX, posicaoY );

		//posicaoAjusteX = posicaoAjusteX - fatorAjusteParallax;
	
	}
}
