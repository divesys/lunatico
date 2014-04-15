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

public class analiseSkill : MonoBehaviour // uma skill que consegue extrair informacoes adicionais das coisas
{ 
	// nota adicional, criar um sistema tipo mana, soh que o nome eh essencia lunar. Tal sistema fara que skills gastem energia
	// seja por uso unico, seja por  uso continuo. No caso da analise eh uma skill de uso continuo
	// ela deve ser ativada para funcionar.

	static public bool skillAnaliseAdquirida;  // verifica se a skill foi adiquirida
	static public bool faseCorretaAnalise; // caso tenha sido adiquirida, verifica se festa na fase correta
	static public bool skillAnaliseAtivada; // verifica se a skillAnalis esta sendo utilizada
	public bool animacaoAnalise;
	static private string faseDaLuaAtual;

	Animator anim;

	void Start()
	{

		skillAnaliseAdquirida = true;
		skillAnaliseAtivada = false;

		anim = GetComponent<Animator>();

	}
	
	void Update() 
	{


		faseDaLuaAtual = simuladorDaFaseDaLua.faseDaLuaSimulada;

		if(faseDaLuaAtual == "crescente") // se a analise foi adquirida e eh lua cheia
		{

			faseCorretaAnalise = true; // skill de analise esta ativada

		}

		else
		{

			faseCorretaAnalise = false; // skill de analise esta desativada

		}

		if(faseCorretaAnalise == true && skillAnaliseAdquirida == true &&  Input.GetButtonDown("skill")) // se estiver na fase da lua correta, a skill ja foi adiquirida e o botao de skill for precionado
		{

			if(skillAnaliseAtivada == false) // se estiver desativada, ativa
			{

				skillAnaliseAtivada = true;
				animacaoAnalise = true;

			}

			else // caso contrario, desativa
			{

				skillAnaliseAtivada = false;
				animacaoAnalise = false;

			}

		}

		else if(faseCorretaAnalise == false || skillAnaliseAdquirida == false)
		{

			skillAnaliseAtivada = false;

		}

		anim.SetBool("analise", animacaoAnalise);

	}



}
