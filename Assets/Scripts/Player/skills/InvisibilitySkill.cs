using UnityEngine;
using System.Collections;

public class InvisibilitySkill : BaseSkill {
	
	//Tempo decorrido apos ativacao da skill
	private float tempoDecorrido;
	
	private float alphaMinimo;
	
	//Duracao do efeito de invisibilidade
	[Range(0.1f, 3)]
	public float duracaoEfeito;
	
	//Forca do efeito de invisibilidade
	[Range(0, 1)]
	public float forcaEfeito;
	
	public override void Update ()
	{
		base.Update();
		
		if (IsExecuting)
		{
			this.alphaMinimo = Mathf.Lerp(1, 0, forcaEfeito);
			
			tempoDecorrido += Time.deltaTime;
			
			if (tempoDecorrido < duracaoEfeito)
			{
				float lerp = tempoDecorrido / duracaoEfeito;
				float alpha = Mathf.Lerp(1, alphaMinimo, lerp);
				ChangeAlphaColorSprite(alpha);
			}
		}
	}
	
	protected override void Execute()
	{
		tempoDecorrido = 0;
	}
	
	protected override void PosExecute()
	{
		base.PosExecute();	
		ChangeAlphaColorSprite(1f);
	}
	
	private void ChangeAlphaColorSprite(float alphaValue)
	{
		Color color = this.GetComponent<SpriteRenderer>().color;
		color.a = alphaValue;
		this.GetComponent<SpriteRenderer>().color = color;
	}
}
