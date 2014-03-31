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

public class SlideSkill : MonoBehaviour {
	
	public float velocidadeSlide; // velocidade do slide
	public MonoBehaviour[] componentesDesabilitar; // desabilita componentes enquanto executa o slide
	private bool pisandoChao; // indica se o objeto esta no chao
	private bool sliding; // slide em execuçao
	public Sprite spriteSlide; // sprite do slide
	public Vector2 tamanhoSlideCollider; // tamanho padrao do collider
	private Vector2 tamanhoOriginalCollider; // tamanho do collider enquanto executa o slide

	// variaveis adicionadas 30/03/2014 >> utilizadas para verificar e aplicar a fase da lua correta
	static public bool skillSlideAdquirida;  // verifica se a skill foi adiquirida
	static public bool faseCorretaSlide; // caso tenha sido adiquirida, verifica se esta na fase correta
	static private string faseDaLuaAtual;
	// variaveis adicionadas 30/03/2014 >> utilizadas para verificar e aplicar a fase da lua correta
		
	void Start () {
		this.tamanhoOriginalCollider = GetComponent<BoxCollider2D>().size;
		skillSlideAdquirida = true ;// adicionado 30/03/2014
	}
	
	void Update () {

		faseDaLuaAtual = simuladorDaFaseDaLua.faseDaLuaSimulada;
		
		if(faseDaLuaAtual == "nova") // se a lua eh minguante
		{
			
			faseCorretaSlide= true;
			
		}
		
		else
		{
			
			faseCorretaSlide = false;
			
		}

		if (sliding && rigidbody2D.velocity == Vector2.zero)
		{
			StopSlide();
		}
		
		if (pisandoChao && !sliding && rigidbody2D.velocity != Vector2.zero && Input.GetButtonDown("skill") && faseCorretaSlide == true) // modifiquei 30/03/2014 >>> troquei o botao de acao pelo botao de skill
		{
			Slide();
		}
		
	}

	private void Slide()
	{
		sliding = true;

		float direcao = Input.GetAxis ("Horizontal");
		rigidbody2D.AddForce(Vector2.right * velocidadeSlide * direcao);
		
		this.GetComponent<SpriteRenderer>().sprite = spriteSlide;		
		AlterarAtividadeComponentes(false);		
		GetComponent<BoxCollider2D>().size = tamanhoSlideCollider;	
	}

	private void StopSlide()
	{
		sliding = false;
		
		AlterarAtividadeComponentes(true);
		GetComponent<BoxCollider2D>().size = tamanhoOriginalCollider;
	}

	private void AlterarAtividadeComponentes(bool ativo)
	{
		foreach (MonoBehaviour componente in componentesDesabilitar)
		{
			componente.enabled = ativo;
		}
	}
	
	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.collider.name == "SuperficieSuperior")
		{
			pisandoChao = true;
		}
	}
	
	void OnCollisionExit2D (Collision2D other)
	{
		if(other.collider.name == "SuperficieSuperior")
		{
			pisandoChao = false;
		}
	}
	
}
