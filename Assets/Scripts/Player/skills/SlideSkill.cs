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

public class SlideSkill : BaseSkill {
	
	public float velocidadeSlide; // velocidade do slide
	private bool pisandoChao; // indica se o objeto esta no chao
	public Vector2 tamanhoSlideCollider; // tamanho padrao do collider do slide executando
	public Vector2 centroSlideCollider; // tamanho padrao do collider do slide executando
	private Vector2 tamanhoOriginalCollider; // tamanho do collider enquanto executa o slide
	private Vector2 centroOriginalCollider; // tamanho do collider enquanto executa o slide

	Animator anim;
	
	void Start () {
		this.tamanhoOriginalCollider = GetComponent<BoxCollider2D>().size;
		this.centroOriginalCollider = GetComponent<BoxCollider2D>().center;

		tamanhoSlideCollider = new Vector2(1.68f, 0.86f);
		centroSlideCollider = new Vector2(0f,-0.36f);

		anim = GetComponent<Animator>();
	}
	
	protected override void Execute()
	{
		Slide();
	}
	
	protected override bool ValidateStopExecution()
	{
		return IsStatic();
	}
	
	protected override bool ValidateExecution()
	{
		return base.ValidateExecution() && pisandoChao && !IsStatic();
	}
	

	private void Slide()
	{
		float direcao = Input.GetAxis ("Horizontal");
		rigidbody2D.AddForce(Vector2.right * velocidadeSlide * direcao);

		anim.SetBool("slide", true);

		//this.GetComponent<SpriteRenderer>().sprite = spriteSlide;
		GetComponent<BoxCollider2D>().size = tamanhoSlideCollider;
		GetComponent<BoxCollider2D>().center =centroSlideCollider;
	}
	
	protected override void PosExecute()
	{
		base.PosExecute();

		anim.SetBool("slide", false);

		GetComponent<BoxCollider2D>().size = tamanhoOriginalCollider;
		GetComponent<BoxCollider2D>().center = centroOriginalCollider;
	}
	
	private bool IsStatic()
	{
		return rigidbody2D.velocity == Vector2.zero;
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
