/*using UnityEngine;
using System.Collections;

public class TV : Scenario {

	public GameObject tvScreen;
	private TVScreen tvscrn;

	public void PutTV()
	{
		sc = GetComponent<SpriteRenderer> ();
		sc.sortingLayerName = "Game";
		sc.sortingOrder = 2;
		string path = "file://" + System.IO.Directory.GetCurrentDirectory () + "\\Assets\\Sprite\\" + this.image + ".png";
		WWW www = new WWW (path);
		sc.sprite = Sprite.Create (www.texture, new Rect (0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 100f);
		imageSize = new Vector2 (www.texture.width / 100f, www.texture.height / 100f);
		sc.transform.localScale = new Vector3 (width, height, 0f);
		Instantiate (this, new Vector3 (posX, posY, 0f), Quaternion.identity);
		Instantiate (tvScreen, new Vector3 (posX + imageSize.x / 2f, posY + imageSize.y / 2f + 0.352f, 0f), Quaternion.identity);
	}

	public void TurnOn()
	{
		tvscrn = tvScreen.GetComponent<TVScreen> ();
		tvscrn.TurnOn ();
	}
}*/
