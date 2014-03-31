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

public class simuladorDaFaseDaLua : MonoBehaviour 
{

	public static string faseDaLuaSimulada; // resulta em uma fase da lua, simulada ou real
	public static bool simulacaoIniciada; // verifica se o botao de simulacao foi apertado ao menos uma vez

	void Start()
	{

		simulacaoIniciada = false;

	}

	void Update()
	{

		if(simulacaoIniciada == false)
		{

			faseDaLuaSimulada = DetectarFaseDaLua.faseDaLua;

		}

		if(Input.GetButton("luaSimulada") && Input.GetAxis ("Vertical") < 0)
		{

			faseDaLuaSimulada = "nova";
			simulacaoIniciada = true;

		}

		else if(Input.GetButton("luaSimulada") && Input.GetAxis ("Horizontal") < 0)
		{
			
			faseDaLuaSimulada = "crescente";
			simulacaoIniciada = true;
			
		}

		else if(Input.GetButton("luaSimulada") && Input.GetAxis ("Vertical") > 0)
		{
			
			faseDaLuaSimulada = "cheia";
			simulacaoIniciada = true;
			
		}

		else if(Input.GetButton("luaSimulada") && Input.GetAxis ("Horizontal") > 0)
		{
			
			faseDaLuaSimulada = "minguante";
			simulacaoIniciada = true;
			
		}

		else if(Input.GetButton("luaSimulada"))
		{
			
			faseDaLuaSimulada = DetectarFaseDaLua.faseDaLua;
			simulacaoIniciada = true;

		}

	}
}
