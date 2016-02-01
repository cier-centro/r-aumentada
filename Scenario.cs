using UnityEngine;
using System.Collections;

public class Scenario : MonoBehaviour {

	protected string image;
	protected float size;
	protected float posX;
	protected float posY;
	protected Vector2 imageSize;
	protected SpriteRenderer sc;

	public string Image {
		get {
			return this.image;
		}
		set {
			image = value;
		}
	}
	
	public float Size {
		get {
			return this.size;
		}
		set {
			size = value;
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
	
	public Vector2 ImageSize {
		get {
			return this.imageSize;
		}
	}

	public virtual void Active(bool isActive)
	{
		if (!isActive) 
			Destroy (this.gameObject);
	}

	public bool ClickLimits(Vector3 position)
	{
		if (Camera.main.ScreenToWorldPoint (position).x > gameObject.GetComponent<Renderer> ().bounds.min.x && 
		    Camera.main.ScreenToWorldPoint (position).x < gameObject.GetComponent<Renderer> ().bounds.max.x &&
		    Camera.main.ScreenToWorldPoint (position).y > gameObject.GetComponent<Renderer> ().bounds.min.y &&
		    Camera.main.ScreenToWorldPoint (position).y < gameObject.GetComponent<Renderer> ().bounds.max.y)
			return true;
		else
			return false;
	}

	public bool IsInside()
	{
		if (this.gameObject.GetComponent<SpriteRenderer> ().bounds.max.x <= Camera.main.transform.position.x + Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth, 0f)).x &&
		    this.gameObject.GetComponent<SpriteRenderer> ().bounds.min.x >= Camera.main.transform.position.x - Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth, 0f)).x)
			return true;
		else
			return false;
	}

	public IEnumerator Anim(float finalSize, float vel)
	{
		if (this.gameObject != null) 
		{
			while (Mathf.Abs(this.gameObject.transform.localScale.x) <= Mathf.Abs(finalSize)) 
			{	
				this.gameObject.transform.localScale += new Vector3 (0.1f * vel, 0.1f * vel, 1f);
				yield return null;
			}
		}
	}

	public virtual void Put()
	{
		sc = GetComponent<SpriteRenderer> ();
		sc.sprite = Resources.Load<Sprite> (this.image);
		sc.transform.localScale = new Vector3 (this.size, this.size, 0f);
		this.imageSize = sc.bounds.size;
	}
}
