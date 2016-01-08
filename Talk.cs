using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Talk : Scenario {
	
	private bool dir;

	public bool Dir {
		get {
			return this.dir;
		}
		set {
			dir = value;
		}
	}

	public override void Active(bool isActive)
	{
		base.Active (isActive);
	}

	public IEnumerator Anim(float finalSize, string text)
	{
		if (this.gameObject != null) 
		{
			while (Mathf.Abs(this.gameObject.transform.localScale.y) <= Mathf.Abs(finalSize)) 
			{	
				this.gameObject.transform.localScale += new Vector3 (finalSize / Mathf.Abs (finalSize) * 0.1f, 0.1f, 0f);
				yield return null;
			}
			GameObject dialog = GameObject.FindGameObjectWithTag("Conversation");
			dialog.gameObject.GetComponent<Text>().text = text;
		}
	}


	public override void Put()
	{
		base.Put ();
		GameObject dialog = GameObject.FindGameObjectWithTag ("Conversation");
		this.tag = "Talk";
		sc.sortingLayerName = "Game";
		sc.sortingOrder = 30;
		dialog.gameObject.transform.localScale = new Vector3 (10f, 10f, 10f);
		dialog.gameObject.GetComponent<Text> ().fontSize = 2;
		gameObject.transform.localScale = new Vector3 (0.01f, 0.01f, 0f);
		if (this.dir) 
			dialog.gameObject.transform.position = new Vector3(this.PosX - this.imageSize.x / 100f, this.posY + this.imageSize.y * 0.6f, 0f);
		else
			dialog.gameObject.transform.position = new Vector3(this.PosX + this.imageSize.x / 100f, this.posY + this.imageSize.y * 0.6f, 0f);
		Instantiate (this, new Vector3 (this.posX, this.posY, 0f), Quaternion.identity);

	}
}
