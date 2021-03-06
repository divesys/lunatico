﻿/* Copyright 2014 Dive Sistemas
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

public class mudarAparenciaLunar : MonoBehaviour // script de teste para mudar o srpite baseado na fase da lua
{
	public string faseDaLuaAtual;
	public string faseDaLuaSimulada;
	public Animator anim;

	void Start()
	{

		anim = GetComponent<Animator>();

	}
	// Update is called once per frame
	void FixedUpdate () 
	{

		faseDaLuaAtual = simuladorDaFaseDaLua.faseDaLuaSimulada;

		if(faseDaLuaAtual == "nova")
		{

			/*SpriteRenderer spriteRender = this.GetComponent<SpriteRenderer>();
			Sprite spriteLua = new Sprite();
			spriteLua = Resources.Load<Sprite>("sprites/luaNovaParada");
			spriteRender.sprite = spriteLua;*/
			anim.SetInteger("faseDaLua", 0);

		}

		if(faseDaLuaAtual == "crescente")
		{
			
			/*SpriteRenderer spriteRender = this.GetComponent<SpriteRenderer>();
			Sprite spriteLua = new Sprite();
			spriteLua = Resources.Load<Sprite>("sprites/luaCrescenteParada");
			spriteRender.sprite = spriteLua;*/
			anim.SetInteger("faseDaLua", 1);
			
		}

		if(faseDaLuaAtual == "cheia")
		{
			
			/*SpriteRenderer spriteRender = this.GetComponent<SpriteRenderer>();
			Sprite spriteLua = new Sprite();
			spriteLua = Resources.Load<Sprite>("sprites/luaCheiaParada");
			spriteRender.sprite = spriteLua;*/
			anim.SetInteger("faseDaLua", 2);
			
		}

		if(faseDaLuaAtual == "minguante")
		{
			
			/*SpriteRenderer spriteRender = this.GetComponent<SpriteRenderer>();
			Sprite spriteLua = new Sprite();
			spriteLua = Resources.Load<Sprite>("sprites/luaMinguanteParada");
			spriteRender.sprite = spriteLua;*/
			anim.SetInteger("faseDaLua", 3);
			
		}

	}
}
