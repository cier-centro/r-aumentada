using UnityEngine;
using System.Collections;

public class Door : Scenario {
	
	private string origin;
	private string destination;

	public Door (string image, string origin, string destination, float posX, float posY, float size)
	{
		this.image = image;
		this.origin = origin;
		this.destination = destination;
		this.posX = posX;
		this.posY = posY;
		this.size = size;
	}

	public string Origin {
		get {
			return this.origin;
		}
		set {
			origin = value;
		}
	}

	public string Destination {
		get {
			return this.destination;
		}
		set {
			destination = value;
		}
	}

	public override void Put()
	{
		base.Put ();
		this.tag = "Door";
		sc.sortingLayerName = "Game";
		sc.sortingOrder = 0;
		Instantiate (this, new Vector3 (this.posX, this.posY, 0f), Quaternion.identity);
	}
}
