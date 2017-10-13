using UnityEngine;
using System.Collections;

public class OtherChar : Character {

	private bool solid = false;
	private float time2 = -10f;
	private int togo = 4;

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
			this.gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 4;
		if (this.name == "Personero(Clone)")
			this.gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 5;
	}
	
	public override void Put()
	{
		base.Put ();
		rigidPlayer = gameObject.GetComponent<Rigidbody2D> ();
		sc.gameObject.layer = 9;
		sc.sortingOrder = 6;
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

	public IEnumerator AnimEnc()
	{
		float i = 0f;
		float inicX = this.gameObject.transform.position.x;
		float inicY = this.gameObject.transform.position.y;

		while (i <= 4.3f) 
		{
			this.gameObject.transform.position = new Vector3(inicX + i, inicY - Mathf.Pow(i - 2f, 2f) + 4f);
			i += 0.015f;
			yield return new WaitForSeconds(0.001f);
		}
	}

	void FixedUpdate()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			if (this.ClickLimits (Input.mousePosition) && this.name == "Personero(Clone)" && GeneralGameManager.advance == 17) 
			{
				GameObject.Find ("Out").GetComponent<Inventory> ().fadeoff ();
				time2 = Time.time;
				togo = 10;//5
			}
		}
	}
	
	void LateUpdate()
	{
		if (this.name != "Personero(Clone)") 
		{
			if (GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.x <= this.gameObject.transform.position.x)
				this.gameObject.transform.localScale = new Vector3 (-Mathf.Abs (this.transform.localScale.x), this.transform.localScale.y, 1);
			else
				this.gameObject.transform.localScale = new Vector3 (Mathf.Abs (this.transform.localScale.x), this.transform.localScale.y, 1);
		}

		if (Time.time >= time2 + 1.5f && Time.time <= time2 + 2f)
			Application.LoadLevel (togo);
	}
}
