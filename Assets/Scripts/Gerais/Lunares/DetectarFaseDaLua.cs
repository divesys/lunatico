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
using System;
using System.Collections;

public class DetectarFaseDaLua : MonoBehaviour // detecta a fase da lua. POdendo ser lua nova, crescente, cheia ou minguante
{

	static public DateTime dataAtual;
	static public int anoAtual;
	static public int mesAtual;
	static public int diaAtual;
	static public float dezenaDoAno; // os ultimos dois digitos do ano atual
	static public float restoDezenaDoAno; // resto da divisao da dezena do ano por 19
	static public float restoVezesOnze; // o restoDezenaDoAno vezes onze
	static public float moduloResto; // modulo 30 do restoVezesOnze, ate atingir um valor entre -29 e 29
	static public float somandoMesDia; // soma ao moduloResto valor de mesAtual e diaAtual
	static public float idadeDaLua; // a idade da lua, um numero entre 0 e 29. a idade da lua zera a cada lua nova
	static public string faseDaLua; // a fase da lua em string.

	static public string AtualizarFaseDaLuaSimulada()
	{

		dataAtual = DateTime.Now; // pega o valor da data atual usando o relogio do sistema
		anoAtual = dataAtual.Year; // extrai o ano da data atual
		mesAtual = dataAtual.Month; // extrai o mes da data atual
		diaAtual = dataAtual.Day; // extrai o dia da data atual
		dezenaDoAno = anoAtual - 2000; // extrai a dezena do ano atual
		restoDezenaDoAno = dezenaDoAno % 19; // tira o resto da dezena do ano ao dividir por 19
		if(restoDezenaDoAno > 9) // caso o resto seja maior que nove
		{
			
			restoDezenaDoAno -= 19; // subtrai 19
			
		}
		restoVezesOnze = restoDezenaDoAno * 11; // multiplica o valor do resto por 11
		moduloResto = restoVezesOnze;
		while(moduloResto < -29 || moduloResto > 29) // faz modulo 30 com o valor do resto ate ficar entre - 29 e 29
		{
			if(moduloResto > 0) // se for positivo reduz 30
			{
				
				moduloResto -= 30;
				
			}
			
			else // se for negativo aumenta 30
			{
				
				moduloResto += 30;
				
			}
			
		}
		
		somandoMesDia = moduloResto + mesAtual + diaAtual; //adicona valor do dia e do mes
		idadeDaLua = somandoMesDia - 8; // subtrai 8
		
		while(idadeDaLua < 0 || moduloResto > 29) // faz modulo 30 para ajustar a idadade da lua ficar entre 0 e 29
		{
			if(idadeDaLua > 0)
			{
				
				idadeDaLua -= 30;
				
			}
			
			else
			{
				
				idadeDaLua += 30;
				
			}
			
		}
		// atribui string para uma faixa de idades, as fases da lua
		if(idadeDaLua >=0 && idadeDaLua < 7.5)
		{
			
			faseDaLua = "nova";
			
		}
		
		else if(idadeDaLua >=7.5 && idadeDaLua < 15)
		{
			
			faseDaLua = "crescente";
			
		}
		
		else if(idadeDaLua >=15 && idadeDaLua < 22.5)
		{
			
			faseDaLua = "cheia";
			
		}
		
		else if(idadeDaLua >=22.5 && idadeDaLua < 28.5)
		{
			
			faseDaLua = "minguante";
			
		}

		return faseDaLua;

	}
	
	void Update () 
	{

		dataAtual = DateTime.Now; // pega o valor da data atual usando o relogio do sistema
		anoAtual = dataAtual.Year; // extrai o ano da data atual
		mesAtual = dataAtual.Month; // extrai o mes da data atual
		diaAtual = dataAtual.Day; // extrai o dia da data atual
		dezenaDoAno = anoAtual - 2000; // extrai a dezena do ano atual
		restoDezenaDoAno = dezenaDoAno % 19; // tira o resto da dezena do ano ao dividir por 19
		if(restoDezenaDoAno > 9) // caso o resto seja maior que nove
		{

			restoDezenaDoAno -= 19; // subtrai 19

		}
		restoVezesOnze = restoDezenaDoAno * 11; // multiplica o valor do resto por 11
		moduloResto = restoVezesOnze;
		while(moduloResto < -29 || moduloResto > 29) // faz modulo 30 com o valor do resto ate ficar entre - 29 e 29
		{
			if(moduloResto > 0) // se for positivo reduz 30
			{

				moduloResto -= 30;

			}

			else // se for negativo aumenta 30
			{

				moduloResto += 30;

			}

		}

		somandoMesDia = moduloResto + mesAtual + diaAtual; //adicona valor do dia e do mes
		idadeDaLua = somandoMesDia - 8; // subtrai 8

		while(idadeDaLua < 0 || moduloResto > 29) // faz modulo 30 para ajustar a idadade da lua ficar entre 0 e 29
		{

			if(idadeDaLua > 0)
			{
				
				idadeDaLua -= 30;
				
			}
			
			else
			{
				
				idadeDaLua += 30;
				
			}
			
		}
		// atribui string para uma faixa de idades, as fases da lua
		if(idadeDaLua >=0 && idadeDaLua < 7.5)
		{

			faseDaLua = "nova";

		}

		else if(idadeDaLua >=7.5 && idadeDaLua < 15)
		{
			
			faseDaLua = "crescente";
			
		}

		else if(idadeDaLua >=15 && idadeDaLua < 22.5)
		{
			
			faseDaLua = "cheia";
			
		}

		else if(idadeDaLua >=22.5 && idadeDaLua <= 29)
		{
			
			faseDaLua = "minguante";
			
		}

	}

}
