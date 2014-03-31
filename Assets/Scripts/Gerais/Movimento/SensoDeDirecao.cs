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

public class SensoDeDirecao : MonoBehaviour {

	public static string direcaoHorizontal;// direcao horzionatl do personagem (na forma de string)
	public static int valorHorizontal;// direcao horzionatl do personagem (na forma de int)

	public static string VerificaDirecaoHorizontal() // retorna a direcao horizontal na forma esquerda ou direita
	{
		if(Input.GetAxis ("Horizontal") < 0) // se o botao pra esquerda for apertado
		{
			
			direcaoHorizontal = "esquerda";
			
		}
		
		else if (Input.GetAxis ("Horizontal") > 0) // se o botao pra direita for apertado
		{
			
			direcaoHorizontal = "direita";
			
		}

		return direcaoHorizontal;
	}

	public static int ValorDirecaoHorizontal() // retorna a direcao horizontal na forma de -1 ou 1
	{

		if(Input.GetAxis ("Horizontal") < 0) // se o botao pra esquerda for apertado
		{
			
			valorHorizontal = -1;
			
		}
		
		else if (Input.GetAxis ("Horizontal") > 0) // se o botao pra direita for apertado
		{
			
			valorHorizontal = 1;
			
		}
		
		return valorHorizontal;

	}

}
