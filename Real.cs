using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Real : Scenario {

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
				this.gameObject.transform.localScale += new Vector3 (0.32f, 0.4f, 0f);
				yield return null;
			}
			GameObject dialog = GameObject.Find("TextReal");
			dialog.gameObject.GetComponent<Text>().text = text;
		}
	}
	
	public override void Put ()
	{
		base.Put ();
		sc.sortingLayerName = "Game";
		sc.sortingOrder = 30;
		this.tag = "Dog";
		this.gameObject.transform.localScale = new Vector3 (4f, 3f);
		this.imageSize = sc.bounds.size;
		GameObject dialog = GameObject.Find ("TextReal");
		Instantiate (this, new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y), Quaternion.identity);
	}
}
