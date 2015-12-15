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
		if (Input.GetMouseButton (0)) 
		{
			if (this.ClickLimits(Input.mousePosition))
			{
				if (this.gameObject.tag == "Left")
					GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Player>().Move("left");
				else if (this.gameObject.tag == "Right")
					GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Player>().Move("right");
				else if (this.gameObject.tag == "Up" && GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Player>().isGround())
				    GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Player>().Jump();
			}
		}
		else
			GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Player>().StopWalk();
	}

	void LateUpdate()
	{
		time += Time.deltaTime;
		if (time < 2f) 
			sc.color = new Color(0f, 0f, 0f, -0.45f * time + 1f);

		if (gameObject.tag == "Left")
			gameObject.transform.position = new Vector3 (Camera.main.transform.position.x - Camara.delayCamX + 0.1f + gameObject.GetComponent<Renderer>().bounds.size.x / 2f, Camera.main.transform.position.y - Camara.delayCamY + 1.4f);
		else if (gameObject.tag == "Right")
			gameObject.transform.position = new Vector3 (Camera.main.transform.position.x - Camara.delayCamX + 0.4f + gameObject.GetComponent<Renderer>().bounds.size.x * 1.5f, Camera.main.transform.position.y - Camara.delayCamY + 1.4f);
		else if (gameObject.tag == "Up")
			gameObject.transform.position = new Vector3 (Camera.main.transform.position.x - Camara.delayCamX + 0.25f + gameObject.GetComponent<Renderer>().bounds.size.x, Camera.main.transform.position.y - Camara.delayCamY + 1.2f + gameObject.GetComponent<Renderer>().bounds.size.y);


		this.posX = gameObject.transform.position.x;
		this.posY = gameObject.transform.position.y;
	}
}
