﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ask : Scenario {

	void Start()
	{
		this.gameObject.transform.localScale = new Vector3 (0.01f, 0.01f);
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
			GameObject dialog = GameObject.FindGameObjectWithTag("Top");
			dialog.gameObject.GetComponent<Text>().text = text;
		}
	}

	public override void Put ()
	{
		base.Put ();
		sc.sortingLayerName = "Game";
		sc.sortingOrder = 2;
		this.tag = "Dog";
		this.gameObject.transform.localScale = new Vector3 (1.5f, 1.5f);
		this.imageSize = sc.bounds.size;
		GameObject dialog = GameObject.FindGameObjectWithTag ("Top");
		dialog.gameObject.transform.localScale = new Vector3 (2.2f, 2.2f, 0f);
		dialog.gameObject.GetComponent<Text> ().fontSize = 2;
		dialog.gameObject.transform.position = new Vector3 (Camera.main.transform.position.x - Camara.delayCamX + this.imageSize.x * 2f / 3f, Camera.main.transform.position.y + Camara.delayCamY - this.imageSize.y / 2);
		Instantiate (this, new Vector3 (Camera.main.transform.position.x - Camara.delayCamX + this.imageSize.x / 2, Camera.main.transform.position.y + Camara.delayCamY - this.imageSize.y / 2), Quaternion.identity);
	}
}