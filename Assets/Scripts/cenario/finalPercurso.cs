using UnityEngine;
using System.Collections;

public class finalPercurso : MonoBehaviour 
{
	public string menssagem;
	public bool dentroDaRegiao; // verifica se esta dentro da regiao do objeto
	public float larguraDaCaixa; // largura da caixa de texto
	public float alturaCaixa; // altura da caixa de texto
	public float posicaoXCaixa; // posicao da caixa, em x
	public float posicaoYCaixa; // posicao da caixa, em y
	public Collider2D colisorPlayer;
	
	void Start() //incializa valores
	{

		menssagem = "Parabens! Voce chegou ao final do percurso, espero que tenha gostado e obrigado por testar!";
		
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		
		if(other.CompareTag("Player"))
		{
			
			dentroDaRegiao = true;
			colisorPlayer = other;

		}
		
	}

	
	void OnTriggerExit2D(Collider2D other)
	{
		
		
		if(other.CompareTag("Player"))
		{
			
			dentroDaRegiao = false;
			
		}
		
	}
	
	void OnGUI()
	{
		if(dentroDaRegiao == true)
		{

			// da os dados da caixa de texto, e depois constroi uma
			larguraDaCaixa = 700;
			alturaCaixa = 25;
			posicaoXCaixa = (Screen.width/2) - (larguraDaCaixa/2);
			posicaoYCaixa = (Screen.height/2) - (alturaCaixa/2);
			GUI.Box(new Rect(posicaoXCaixa,posicaoYCaixa,larguraDaCaixa,alturaCaixa), menssagem);

		}
		
	}
}
