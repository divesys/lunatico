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

public class freiarAntesParede : MonoBehaviour // classe para desacelarar antes da parede se estiver rapido demais
{
	float velocidadeFracao; // valor dae reducao proporcional da velocidade
	float fatorDeReducaoX; // quanto reduz a velocidade por frame em X
	float fatorDeReducaoY; // quanto reduz a velocidade por frame em Y
	float velocidadeX; // velocidade horizontal
	float velocidadeY; // velocidade vertical
	public float razaoReducao; // razao que gera o fator de reducao atraves da velocidade, quanto maior mais suave sera
	float direcaoCampoDeVisao; // direcao do campo de visao, negativo para esquerda e positivo para direita
	public float velocidadeMaxima ;// limite da velocidade nas proximadades de uma parede
	float centroCampoVisao;// centro do BoxCllider do campo de visao
	int valorHorizontal; //pega o valor da direcao, -1 pra esquerda e 1 para direita


	void Start ()
	{
		centroCampoVisao = 18.72f;
		razaoReducao = 50f;
		velocidadeMaxima = 6;
	}



	void OnTriggerEnter2D (Collider2D other)
	{
		velocidadeX = this.transform.parent.rigidbody2D.velocity.x; // pega velocidade horizontal atual do objeto
		velocidadeY = this.transform.parent.rigidbody2D.velocity.y; // pega velocidade horizontal atual do objeto
		
	}


	void OnTriggerStay2D (Collider2D other)
	{

		if((other.collider2D.name == "SuperficieLateralEsquerda" && velocidadeX > velocidadeMaxima ) ) // se detectar uma parede (a esquerda) a frente e se estiver rapido demais 
		{
			velocidadeY = this.transform.parent.rigidbody2D.velocity.y; // pega velocidade horizontal atual do objeto
			fatorDeReducaoX = (velocidadeX/razaoReducao)+1; // o quanto reduzir da velocidade atual em X
			//fatorDeReducaoY = (velocidadeY/razaoReducao)+1; // o quanto reduzir da velocidade atual em Y
			velocidadeX = velocidadeX/fatorDeReducaoX; // reduz a velocidade atual
			//velocidadeY = velocidadeY/fatorDeReducaoY;
			this.transform.parent.rigidbody2D.velocity = new Vector2(velocidadeX, velocidadeY); // aplica reduçao
		}

		if( (other.collider2D.name == "SuperficieLateralDireita" && velocidadeX < ( velocidadeMaxima * -1) ) ) // se detectar uma parede (a direita) frente e se estiver rapido demais
		{
			velocidadeY = this.transform.parent.rigidbody2D.velocity.y; // pega velocidade horizontal atual do objeto
			fatorDeReducaoX = (velocidadeX/razaoReducao)-1; // o quanto reduzir da velocidade atual em X
			//fatorDeReducaoY = (velocidadeY/razaoReducao)+1; // o quanto reduzir da velocidade atual em Y
			velocidadeX = (velocidadeX/(fatorDeReducaoX*-1));// reduz a velocidade atual (denominador negativo para manter valor negativo)
			//velocidadeY = velocidadeY/fatorDeReducaoY;
			this.transform.parent.rigidbody2D.velocity = new Vector2(velocidadeX, velocidadeY); // aplica reduçao
		}
	
		
	}

	void FixedUpdate()
	{

		valorHorizontal = SensoDeDirecao.ValorDirecaoHorizontal(); //pega o valor da direcao, -1 pra esquerda e 1 para direita
		BoxCollider2D b2d = this.GetComponent<BoxCollider2D>(); // captura o componente boxCollider2D
		b2d.center = new Vector2(centroCampoVisao * valorHorizontal,0); //posiciona o campo de visao
		
	}


}
