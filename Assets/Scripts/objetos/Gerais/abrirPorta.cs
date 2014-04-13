using UnityEngine;
using System.Collections;

public class abrirPorta : MonoBehaviour 
{

	public bool podeAbrirPorta;
	public bool portaAberta;
	public Animator anim;

	// Use this for initialization
	void Start () 
	{
	
		anim = GetComponent<Animator>();
		portaAberta = false;

	}
	
	// Update is called once per frame
	void Update () 
	{

		podeAbrirPorta = tabuaDeSimbolosTeste.comprendeeuTexto;

		if(podeAbrirPorta == true)
		{

			anim.SetBool ("portaDestravada", true);

		}

	}
}
