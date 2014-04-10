/* Copyright 2014 Dive Sistemas
 *  
    Este arquivo é parte do programa Lunatico



    Lunatico é um software livre; você pode redistribuí-lo e/ou 

    modificá-lo dentro dos termos da Licença Pública Geral GNU como 

    publicada pela Fundação do Software Livre (FSF); na versão 3 da 

    Licença, ou (na sua opinião) qualquer versão.



    Este programa é distribuído na esperança de que possa ser  útil, 

    mas SEM NENHUMA GARANTIA; sem uma garantia implícita de ADEQUAÇÃO a qualquer

    MERCADO ou APLICAÇÃO EM PARTICULAR. Veja a

    Licença Pública Geral GNU para maiores detalhes.



    Você deve ter recebido uma cópia da Licença Pública Geral GNU

    junto com este programa, se não, escreva para a Fundação do Software

    Livre(FSF) Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA */

using UnityEngine;
using System.Collections;

public class tabuaDeSimbolosTeste : MonoBehaviour 
{
	public string menssagemCriptografada; // conteudo da menssagem criptografado
	public string menssagemDecifrada; // conteudo da menssagem legivel
	public bool consegueLer; // verifica se consegue ler
	public bool dentroDaRegiao; // verifica se esta dentro da regiao do objeto
	public bool lendoTexto; // uma alavanca que muda o estado da janela, ao apertar o botao de acao ira invocar o texto, ao apertar nivamente ira dispensar o texto
	public float larguraDaCaixa; // largura da caixa de texto
	public float alturaCaixa; // altura da caixa de texto
	public float posicaoXCaixa; // posicao da caixa, em x
	public float posicaoYCaixa; // posicao da caixa, em y
	
	void Start() //incializa valores
	{

		menssagemCriptografada = "shaksaksjkah";
		menssagemDecifrada = "nossa! voce pode ler!";
		lendoTexto = false;
	}

	void Update() // invoca ou dispensa a caixa de menssagem
	{

		if(Input.GetButtonDown("acao") && lendoTexto == false)
		{
			
			lendoTexto = true;
			
		}
		
		else if(Input.GetButtonDown("acao") && lendoTexto == true)
		{
			
			lendoTexto = false;
			
		}

	}

	// verifica se esta proximo do objeto que deseja ler

	void OnTriggerEnter2D(Collider2D other) 
	{

		if(other.CompareTag("Player"))
		{

			dentroDaRegiao = true;

		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		
		if(other.CompareTag("Player"))
		{
			
			dentroDaRegiao = false;
			lendoTexto = false; // ao sair do objeto, para de ler o texto
			
		}
		
	}

	void OnTriggerStay2D(Collider2D other)
	{

		if(other.CompareTag("Player")) //verifica se consegue ler o texto criptografado
		{

			if(analiseSkill.skillAnaliseAtivada == false)
			{

				consegueLer = false;

			}

			else if(analiseSkill.skillAnaliseAtivada == true )
			{

				consegueLer = true;

			}

		}

	}

	void OnGUI()
	{
		if(dentroDaRegiao == true)
		{

			if(consegueLer == true && lendoTexto ==  true)
			{

				// da os dados da caixa de texto, e depois constroi uma
				larguraDaCaixa = 150;
				alturaCaixa = 25;
				posicaoXCaixa = Screen.width/2-larguraDaCaixa;
				posicaoYCaixa = Screen.height/2-alturaCaixa;
				GUI.Box(new Rect(posicaoXCaixa,posicaoYCaixa,larguraDaCaixa,alturaCaixa), menssagemDecifrada);

			}

			else if(consegueLer == false && lendoTexto ==  true)
			{

				// da os dados da caixa de texto, e depois constroi uma
				larguraDaCaixa = 100;
				alturaCaixa = 25;
				posicaoXCaixa = Screen.width/2-larguraDaCaixa;
				posicaoYCaixa = Screen.height/2-alturaCaixa;
				GUI.Box(new Rect(posicaoXCaixa,posicaoYCaixa,larguraDaCaixa,alturaCaixa), menssagemCriptografada);

			}
		}

	}
}
