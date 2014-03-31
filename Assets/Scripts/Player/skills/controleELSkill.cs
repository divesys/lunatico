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

public class controleELSkill : MonoBehaviour // uma skill que controla o fluxo de EL, podendo inserir e extrair EL
{ 
	// nota adicional, criar um sistema tipo mana, soh que o nome eh essencia lunar. Tal sistema fara que skills gastem energia
	// seja por uso unico, seja por  uso continuo. No caso da analise eh uma skill de uso continuo
	// ela deve ser ativada para funcionar.
	
	static public bool skillControleELAdquirida;  // verifica se a skill foi adiquirida
	static public bool faseCorretaControleEL; // caso tenha sido adiquirida, verifica se esta na fase correta
	static public bool skillControleELDisponivel; // verifica se a skill esta disponivel para utilizar
	static private string faseDaLuaAtual;
	
	void Start()
	{
		
		skillControleELAdquirida = true;
		skillControleELDisponivel = false;
		
	}
	
	void Update() 
	{
		
		faseDaLuaAtual = simuladorDaFaseDaLua.faseDaLuaSimulada;
		
		if(faseDaLuaAtual == "minguante") // se a lua eh minguante
		{
			
			faseCorretaControleEL = true;
			
		}
		
		else
		{
			
			faseCorretaControleEL = false;
			
		}
		
		if(faseCorretaControleEL == true && skillControleELAdquirida == true) // se estiver na fase da lua correta e a skill ja foi adiquirida
		{

			skillControleELDisponivel = true;

		}
		
		else
		{
			
			skillControleELDisponivel = false;
			
		}
		//Debug.Log (faseDaLuaAtual);
	}
	
	
	
}
