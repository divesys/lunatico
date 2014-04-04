using UnityEngine;
using System.Collections;

public class InvisibilitySkill : BaseSkill {
	
	protected override void Execute()
	{
		ChangeAlphaColorSprite(.5f);
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
