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
		sc.color = new Color (255f, 255f, 255f, 0f);
	}

	public override void Put()
	{
		base.Put ();
		this.tag = this.strName;
		sc.sortingLayerName = "Game";
		sc.sortingOrder = 6;
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
			
				if (this.gameObject.tag == "Up" && GeneralGameManager.advance == 28)
				{
					GameObject.Find("Out").GetComponent<Inventory>().fadeoff();
					time2 = Time.time;
					togo = 9;
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

					if (this.gameObject.tag == "Up" && GeneralGameManager.advance == 28)
					{
						GameObject.Find("Out").GetComponent<Inventory>().fadeoff();
						time2 = Time.time;
						togo = 9;
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
		if (gameObject.tag == "Left")
			gameObject.transform.position = new Vector3 (Camera.main.transform.position.x - Camara.delayCamX + 0.4f + gameObject.GetComponent<Renderer> ().bounds.size.x / 2f, Camera.main.transform.position.y - Camara.delayCamY + 1.4f);
		else if (gameObject.tag == "Right")
			gameObject.transform.position = new Vector3 (Camera.main.transform.position.x - Camara.delayCamX + 1.2f + gameObject.GetComponent<Renderer> ().bounds.size.x * 1.5f, Camera.main.transform.position.y - Camara.delayCamY + 1.4f);
		else if (gameObject.tag == "A")
			gameObject.transform.position = new Vector3 (Camera.main.transform.position.x + Camara.delayCamX - 1.4f - gameObject.GetComponent<Renderer> ().bounds.size.x, Camera.main.transform.position.y - Camara.delayCamY + 0.93f);
		else if (gameObject.tag == "B")
			gameObject.transform.position = new Vector3 (Camera.main.transform.position.x + Camara.delayCamX + 0.7f - gameObject.GetComponent<Renderer> ().bounds.size.x * 2f, Camera.main.transform.position.y - Camara.delayCamY + 2.2f);

		this.posX = gameObject.transform.position.x;
		this.posY = gameObject.transform.position.y;
	}
}
