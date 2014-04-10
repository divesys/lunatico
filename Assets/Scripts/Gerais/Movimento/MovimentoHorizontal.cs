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

public class MovimentoHorizontal : MonoBehaviour // classe geral de movimento horizontal
{
	public float forcaHorizontal = 0.45f; // forca que move o objeto horizontalmente

	public Animator anim;
	public float velocidadeXFloat;
	public int velocidadeXInt;

	void Start()
	{

		anim = GetComponent<Animator>();

	}

	void FixedUpdate()
	{
		if(Input.GetButton("Sprint")) // se o botao de sprint for apertado
		{
			//forcaHorizontal = 0.6f; // forca para velocidade do sprint, aproximadamente 10 m/s
		}

		else //velocidade normal
		{
			forcaHorizontal = 0.40f; // forca para velocidade do sprint, aproximadamente 6 m/s
		}
		float direcao = Input.GetAxis ("Horizontal"); // pega o eixo horizontal de movimento
		rigidbody2D.AddForce(Vector2.right * forcaHorizontal * direcao); // aplica forca na direcao apertada, movendo o objeto

		velocidadeXFloat = this.transform.rigidbody2D.velocity.x;
		velocidadeXInt = (int) velocidadeXFloat;

		anim.SetInteger("velocidade", velocidadeXInt);

	}
}
