using UnityEngine;
using System.Collections;

public class Background : Scenario {

	private bool repeat;

	public Background (string image, float size, float posX, float posY, bool repeat)
	{
		this.image = image;
		this.size = size;
		this.posX = posX;
		this.posY = posY;
		this.repeat = repeat;
	}

	public bool Repeat {
		get {
			return this.repeat;
		}
		set {
			repeat = value;
		}
	}

	public override void Put()
	{
		base.Put ();
		this.tag = "Background";
		sc.sortingLayerName = "Background";
		Instantiate (this, new Vector3 (this.posX, this.posY, 0f), Quaternion.identity);
	}
}
