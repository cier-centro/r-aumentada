using UnityEngine;
using System.Collections;

public class ButtonMv : Scenario {

	private string strName;
	private float time;

	public string StrName {
		get {
			return this.strName;
		}
		set {
			strName = value;
		}
	}

	void Start()
	{
		time = 0f;
		sc = gameObject.GetComponent<SpriteRenderer> ();
		Input.multiTouchEnabled = true;
	}

	public override void Put()
	{
		base.Put ();
		this.tag = this.strName;
		sc.sortingLayerName = "Game";
		sc.sortingOrder = 1;
		Instantiate (this, new Vector3 (this.posX, this.posY, 0f), Quaternion.identity);
	}

	void FixedUpdate()
	{
		if (Input.touchCount > 0)
		{
			Touch[] myTouches = Input.touches;
			for (int i = 0, k = Input.touchCount; i < k; i++)
			{
				if (this.ClickLimits(myTouches[i].position) && this.tag == "A")
					GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Player>().run = true;
			}
			for (int i = 0, k = Input.touchCount; i < k; i++)
			{
				if (this.ClickLimits (myTouches[i].position))
				{
					if (this.gameObject.tag == "B" && GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Player> ().isGround ())
						GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Player> ().Jump ();
					if (this.gameObject.tag == "Left")
						GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Player> ().Move ("Left");
					if (this.gameObject.tag == "Right")
						GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Player> ().Move ("Right");
				}
			}
		} 
		else 
			GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Player> ().StopWalk ();
	}

	void LateUpdate()
	{
		time += Time.deltaTime;
		if (time < 2f) 
			sc.color = new Color(0f, 0f, 0f, -0.47f * time + 1f);

		if (gameObject.tag == "Left")
			gameObject.transform.position = new Vector3 (Camera.main.transform.position.x - Camara.delayCamX + 0.1f + gameObject.GetComponent<Renderer> ().bounds.size.x / 2f, Camera.main.transform.position.y - Camara.delayCamY + 1.4f);
		else if (gameObject.tag == "Right")
			gameObject.transform.position = new Vector3 (Camera.main.transform.position.x - Camara.delayCamX + 0.6f + gameObject.GetComponent<Renderer> ().bounds.size.x * 1.5f, Camera.main.transform.position.y - Camara.delayCamY + 1.4f);
		else if (gameObject.tag == "Up")
			gameObject.transform.position = new Vector3 (Camera.main.transform.position.x - Camara.delayCamX + 0.35f + gameObject.GetComponent<Renderer> ().bounds.size.x, Camera.main.transform.position.y - Camara.delayCamY + 1.4f + gameObject.GetComponent<Renderer> ().bounds.size.y);
		else if (gameObject.tag == "A")
			gameObject.transform.position = new Vector3 (Camera.main.transform.position.x + Camara.delayCamX - 0.1f - gameObject.GetComponent<Renderer> ().bounds.size.x, Camera.main.transform.position.y - Camara.delayCamY + 1f);
		else if (gameObject.tag == "B")
			gameObject.transform.position = new Vector3 (Camera.main.transform.position.x + Camara.delayCamX - 0.1f - gameObject.GetComponent<Renderer> ().bounds.size.x * 2f, Camera.main.transform.position.y - Camara.delayCamY + 2f);

		this.posX = gameObject.transform.position.x;
		this.posY = gameObject.transform.position.y;
	}
}
