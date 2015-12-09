using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
	
	private float width;
	private float height;
	private float rotation;
	private float posX;
	private float posY;
	private string tagStr;
	private BoxCollider2D coll;

	public Floor (float width, float height, float rotation, float posX, float posY, string tagStr)
	{
		this.width = width;
		this.height = height;
		this.rotation = rotation;
		this.posX = posX;
		this.posY = posY;
		this.tagStr = tagStr;
	}
	

	public float Width {
		get {
			return this.width;
		}
		set {
			width = value;
		}
	}

	public float Height {
		get {
			return this.height;
		}
		set {
			height = value;
		}
	}

	public float Rotation {
		get {
			return this.rotation;
		}
		set {
			rotation = value;
		}
	}

	public float PosX {
		get {
			return this.posX;
		}
		set {
			posX = value;
		}
	}

	public float PosY {
		get {
			return this.posY;
		}
		set {
			posY = value;
		}
	}

	public string TagStr {
		get {
			return this.tagStr;
		}
		set {
			tagStr = value;
		}
	}

	public void PutFloor()
	{
		this.tag = tagStr;
		coll = GetComponent<BoxCollider2D> ();
		coll.size = new Vector2 (width, height);
		Instantiate (this, new Vector3 (posX, posY, 0f), Quaternion.AngleAxis(rotation, Vector3.forward));
	}
}
