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

public class sugarBarreiraEL : MonoBehaviour 
{
	public bool dentroDaRegiao; // verifica se esta dentro da regiao do objeto
	public Collider2D colisorPlayer;
	public float vitalidadeBarreiraEL; // o quanto de EL tem na barreira
	public float decaimentoBarreiraEl; // o quanto de EL e retirado da barreira por frame
	public float constanteDesaparecimento;

	public Animator anim;
	public Color cor;

	static public bool barreiraSugada;


	void Start()
	{

		vitalidadeBarreiraEL = 100f;
		decaimentoBarreiraEl = 1f;
		cor = this.transform.parent.GetComponent<SpriteRenderer>().color;
		constanteDesaparecimento = 1/(vitalidadeBarreiraEL/decaimentoBarreiraEl);

	}
	void OnTriggerEnter2D(Collider2D other) 
	{
		
		if(other.CompareTag("Player"))
		{
			
			dentroDaRegiao = true;
			colisorPlayer = other;
			
		}
		
	}

	// Update is called once per frame
	void Update () 
	{

		if(dentroDaRegiao == true)
		{
			
			if(colisorPlayer.CompareTag("Player")) //verifica se consegue ler o texto criptografado
			{

				if(controleELSkill.skillControleELDisponivel == true && Input.GetButton("skill"))
				{

					if(controleELSkill.getPuxandoEL() == true)
					{

						if( vitalidadeBarreiraEL <= 0)
						{

							Destroy(transform.parent.gameObject);
							controleELSkill.setPuxandoEL(false);
							barreiraSugada = true;

						}

						else
						{
							Debug.Log (constanteDesaparecimento);
							vitalidadeBarreiraEL -= decaimentoBarreiraEl;
							cor = this.transform.parent.GetComponent<SpriteRenderer>().color;
							cor.a -= constanteDesaparecimento;
							this.transform.parent.GetComponent<SpriteRenderer>().color = cor;

						}

					}

					else
					{

						controleELSkill.setIniciarPuxandoELInicio(true);

					}
					
				}

				else
				{

					controleELSkill.setPuxandoEL(false);
					controleELSkill.setIniciarPuxandoELInicio(false);

				}

			}
			
		}
	
	}

	void OnTriggerExit2D(Collider2D other)
	{
		
		
		if(other.CompareTag("Player"))
		{
			
			dentroDaRegiao = false;
			colisorPlayer = null;
			
		}
		
	}

	void OnTriggerStay2D(Collider2D other) 
	{
		

		
	}
}
