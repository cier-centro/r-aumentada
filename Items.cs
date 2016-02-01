using UnityEngine;
using System.Collections;

public class Items : Scenario {

	public override void Put()
	{
		base.Put ();
		sc.sortingLayerName = "Game";
		sc.sortingOrder = 2;
		this.tag = "Item";
		Instantiate (this, new Vector3 (this.posX, this.posY, 0f), Quaternion.identity);
	}

	void LateUpdate()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			if (this.ClickLimits(Input.mousePosition))
			{
				if (this.name == "Organic(Clone)")
					GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Orgánico");
				else if (this.name == "Paper(Clone)")
					GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Papel");
				else if (this.name == "Super(Clone)")
				{
					StartCoroutine(GameObject.Find("Encapuchado(Clone)").gameObject.GetComponent<OtherChar>().Anim(0.5f, 1f));
					GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Superhéroes");
				}
				else if (this.name == "Padlock(Clone)")
				{
					if (GeneralGameManager.key)
					{
						if (GeneralGameManager.advance == 12)
						{
							GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().PutNew("Personero", "office", true, 34.9f, 0f, 2f);
							this.gameObject.GetComponent<Items>().Active(false);
							GeneralGameManager.advance++;
						}
						else
							GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Estoy ocupado,vuelve luego.");
					}
					else
						GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("No tienes la llave para abrirlo.");
				}
			}
		}
	}
}
