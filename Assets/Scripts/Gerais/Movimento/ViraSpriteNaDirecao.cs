using UnityEngine;
using System.Collections;

public class ViraSpriteNaDirecao : MonoBehaviour 
{
public float scaleSpriteX;
public float scaleSpriteY;
public float scaleSpriteZ;

	// Use this for initialization
	void Start () 
	{
		scaleSpriteX = this.transform.localScale.x;
		scaleSpriteY = this.transform.localScale.y;
		scaleSpriteZ = this.transform.localScale.z;
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		scaleSpriteX = this.transform.localScale.x;
		scaleSpriteY = this.transform.localScale.y;
		scaleSpriteZ = this.transform.localScale.z;

		if(SensoDeDirecao.VerificaDirecaoHorizontal() == "direita")
		{

			if(scaleSpriteX < 0)
			{

				scaleSpriteX = scaleSpriteX*-1;

			}

		}

		else if(SensoDeDirecao.VerificaDirecaoHorizontal() == "esquerda")
		{

			if(scaleSpriteX > 0)
			{
				
				scaleSpriteX = scaleSpriteX*-1;
				
			}

		}

		this.transform.localScale = new Vector3 (scaleSpriteX,scaleSpriteY,scaleSpriteZ);
	
	}
}
