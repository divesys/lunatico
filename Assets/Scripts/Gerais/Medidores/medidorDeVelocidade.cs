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

public class medidorDeVelocidade : MonoBehaviour {

	/*// Use this for initialization
	void Start () {
	
	}*/
	
	// Update is called once per frame
	/*void Update () 
	{

	
	}*/


	void FixedUpdate()  // mede a velocidade do objeto
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		Vector2 velocidadeV2 = rb.velocity;
		Debug.Log (velocidadeV2);

	}
}
