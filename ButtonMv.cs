using UnityEngine;
using System.Collections;

public class ButtonMv : Scenario {

	private string strName;
	private float time;
	private float time2;
	private int togo = 0;

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
		time2 = -10f;
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
#if UNITY_EDITOR
		if (Input.GetMouseButton(0)) 
		{
			if (this.ClickLimits(Input.mousePosition))
			{
				if (this.gameObject.tag == "B" && GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Player> ().isGround ())
					GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Player> ().Jump ();
				if (this.gameObject.tag == "Left")
					GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Player> ().Move ("Left");
				if (this.gameObject.tag == "Right")
					GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Player> ().Move ("Right");
				if (this.gameObject.tag == "Up" && GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.x <= 19f &&
				    GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.x >= 0.4f && GeneralGameManager.advance == 6)
				{
					GameObject.Find("Out").GetComponent<Inventory>().fadeoff();
					time2 = Time.time;
					togo = 1;
				}
				if (this.gameObject.tag == "Up" && GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.x <= 26.1f &&
				    GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.x >= 23.1f && GeneralGameManager.hammer && GeneralGameManager.key)
				{
					GameObject.Find("Out").GetComponent<Inventory>().fadeoff();
					time2 = Time.time;
					togo = 2;
				}
			}
		}
#else
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
					if (this.gameObject.tag == "Up" && GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.x <= 19f &&
					    GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.x >= 0.4f && GeneralGameManager.advance == 6)
					{
						GameObject.Find("Out").GetComponent<Inventory>().fadeoff();
						time2 = Time.time;
						togo = 1;
					}
					if (this.gameObject.tag == "Up" && GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.x <= 26.1f &&
					    GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.x >= 23.1f && GeneralGameManager.hammer && GeneralGameManager.key)
					{
						GameObject.Find("Out").GetComponent<Inventory>().fadeoff();
						time2 = Time.time;
						togo = 2;
					}
				}
			}
		}
#endif
		else 
			GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Player> ().StopWalk ();
	}

	void LateUpdate()
	{
		time += Time.deltaTime;
		if (time < 2f) 
			sc.color = new Color(0f, 0f, 0f, -0.47f * time + 1f);
		if (Time.time >= time2 + 1.5f && Time.time <= time2 + 2f)
			Application.LoadLevel (togo);

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
