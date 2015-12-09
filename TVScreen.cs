/*using UnityEngine;
using System.Collections;

public class TVScreen : MonoBehaviour {
	
	private Renderer tvImage;

	public void TurnOn()
	{	
		tvImage = GetComponent<Renderer> ();
		tvImage.sortingLayerName = "Game";
		tvImage.sortingOrder = 3;
		((MovieTexture)tvImage.sharedMaterial.mainTexture).loop = true;
		((MovieTexture)tvImage.sharedMaterial.mainTexture).Play ();
	}
}*/