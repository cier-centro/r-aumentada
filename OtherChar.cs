using UnityEngine;
using System.Collections;

public class OtherChar : Character {

	private bool solid = false;

	public bool Solid {
		get {
			return this.solid;
		}
		set {
			solid = value;
		}
	}

	public override void Start () 
	{
		base.Start ();
		coll.isTrigger = rigidPlayer.isKinematic;
		if (this.name == "Encapuchado(Clone)")
			this.gameObject.transform.localScale = new Vector3 (0.01f, 0.01f);
	}
	
	public override void Put()
	{
		base.Put ();
		rigidPlayer = gameObject.GetComponent<Rigidbody2D> ();
		sc.gameObject.layer = 9;
		sc.sortingOrder = 2;
		this.tag = "Other";
		rigidPlayer.isKinematic = !this.solid;
		rigidPlayer.mass = 100f;
		Instantiate (this, new Vector3 (this.posX, this.posY, 0f), Quaternion.identity);
	}

	public IEnumerator Move(float posFinal)
	{
		float speed;
		if (GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Player> ().run)
			speed = 300f;
		else
			speed = 150f;
#if UNITY_EDITOR
		speed *= 5;
#endif
		float distance = Mathf.Abs(posFinal - rigidPlayer.position.x);
		coll.isTrigger = false;
		rigidPlayer.isKinematic = false;
		while (distance > 0.5f) 
		{
			//animator.SetTrigger("BeginWalk");
			if (posFinal > rigidPlayer.position.x)
			{
				this.gameObject.transform.localScale = new Vector3 (Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, 1);
				speed = Mathf.Abs(speed);
			}
			else
			{
				this.gameObject.transform.localScale = new Vector3 (-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, 1);
				speed = -Mathf.Abs(speed);
			}
			rigidPlayer.velocity = new Vector2(speed * Time.deltaTime, rigidPlayer.velocity.y);
			distance = Mathf.Abs(posFinal - rigidPlayer.position.x);
			yield return true;
		}
		coll.isTrigger = true;
		rigidPlayer.isKinematic = true;
	}

	void LateUpdate()
	{
		if (GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.x <= this.gameObject.transform.position.x)
			this.gameObject.transform.localScale = new Vector3 (-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, 1);
		else
			this.gameObject.transform.localScale = new Vector3 (Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, 1);
	}
}
