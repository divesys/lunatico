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

public class Pulo : MonoBehaviour  // classe geral de pulos
{
	
	public float forcaPulo = 16f; //determina a força do pulo, quanto maior mais alto sera o pulo
	public int limiteDePulos = 2;//um limitador de pulos, basicamente o numero maximo de pulos
	private int contadorDePulos;
	float velocidadeHorizontal;

	void start()
	{

		contadorDePulos = limiteDePulos;

	}


	void Update()
	{
		
		
		if (Input.GetButtonDown("Pulo") && contadorDePulos > 0) // pula ao apertar o botao de pulo se tiver pulos disponiveis
		{

			velocidadeHorizontal = rigidbody2D.velocity.x;
			rigidbody2D.AddForce(Vector2.up * forcaPulo); // movimenta para cima usando a forca do pulo
			contadorDePulos -= 1; // reduz um pulo
			rigidbody2D.velocity = new Vector3(velocidadeHorizontal, 0); // zera a velocidade para o proximo pulo ter a mesma altura
		}


	}

	void OnCollisionEnter2D (Collision2D other)
	{

		if(other.collider.name == "SuperficieSuperior") // se pisar no chao
		{
			contadorDePulos = limiteDePulos; // reseta o contador de pulos
		}



	}
}
