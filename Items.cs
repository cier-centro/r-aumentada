using UnityEngine;
using System.Collections;

public class Items : Scenario {

	private GameObject[] other;
	private int lay = 2;
	private bool isVisible = true;
	private bool clickOt = false;
	private float time2 = -10f;
	private int togo = 0;

	public int Lay {
		get {
			return this.lay;
		}
		set {
			lay = value;
		}
	}

	public bool IsVisible {
		get {
			return this.isVisible;
		}
		set {
			isVisible = value;
		}
	}

	public override void Put()
	{
		base.Put ();
		sc.sortingLayerName = "Game";
		sc.sortingOrder = this.Lay;
		this.tag = "Item";
		if (!this.IsVisible)
			sc.color = new Color (255f, 255f, 255f, 0f);
		else
			sc.color = new Color (255f, 255f, 255f, 1f);
		Instantiate (this, new Vector3 (this.posX, this.posY, 0f), Quaternion.identity);
	}

	void Start()
	{
		if (this.name == "Control_Blanco_IZQ(Clone)" || this.name == "Control_Blanco_DER(Clone)")
			this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (255f, 255f, 255f, 0.1f);
	}

	void FixedUpdate()
	{
		clickOt = false;
		if (this.name == "Control_Blanco_IZQ(Clone)")
			this.gameObject.transform.position = new Vector3 (Camera.main.transform.position.x - Camara.delayCamX + 0.3f + gameObject.GetComponent<Renderer> ().bounds.size.x / 2f, Camera.main.transform.position.y - Camara.delayCamY + 1.4f);
		if (this.name == "Control_Blanco_DER(Clone)")
			gameObject.transform.position = new Vector3 (Camera.main.transform.position.x + Camara.delayCamX + 0.8f - gameObject.GetComponent<Renderer> ().bounds.size.x, Camera.main.transform.position.y - Camara.delayCamY + 1.5f);

		if (Input.GetMouseButtonDown (0)) 
		{
			other = GameObject.FindGameObjectsWithTag("Other");

			for (int i = 0, k = other.Length; i < k; i++)
			{
				if (other[i].gameObject.GetComponent<OtherChar>().ClickLimits(Input.mousePosition))
					clickOt = true;
			}

			if (this.ClickLimits(Input.mousePosition) && !clickOt)
			{
				if (this.name == "Locker(Clone)")
					GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Esto es un locker");

				else if (this.name == "LockerabiertoDer(Clone)" && this.gameObject.GetComponent<SpriteRenderer>().color.a == 0f)
				{
					this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 1f);
					if (GeneralGameManager.apple)
						GameObject.Find("Manzana(Clone)").gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 1f);
				}

				else if (this.name == "LockerabiertoIzq(Clone)" && this.gameObject.GetComponent<SpriteRenderer>().color.a == 0f)
					this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 1f);

				else if (this.name == "Manzana(Clone)" && this.gameObject.GetComponent<SpriteRenderer>().color.a == 1f)
				{
					GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("¡Has conseguido una manzana!");
					GeneralGameManager.advance++;
					this.Active(false);
				}

				else if (this.name == "Tablones(Clone)")
				{
					if (GeneralGameManager.hammer)
					{
						GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("¡Pudiste desbloquear la puerta!");
						GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().PutNew("DoorPacman", "puertaPacman", false, 25.05f, 1.09f);
						this.Active(false);
					}
					else
						GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Parece que la puerta esta bloqueada. Con la herramienta adecuada se puede abrir.");
				}

				else if (this.name == "Personerocerrado(Clone)")
					GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Parece que esta oficina esta bloqueada. Pero se escuchan ruidos.");

				else if (this.name == "Organico(Clone)")
					GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Orgánico");

				else if (this.name == "Papel(Clone)")
					GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Papel");

				else if (this.name == "Plastico(Clone)")
					GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Plástico");

				else if (this.name == "Candado(Clone)")
				{
					if (GeneralGameManager.key)
					{
						if (GeneralGameManager.advance == 13)
						{
							GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().PutNew("Personero", "PersoneroAbierto", true, 34f, 0f);
							this.gameObject.GetComponent<Items>().Active(false);
							GameObject.Find("Personerocerrado(Clone)").gameObject.GetComponent<Items>().Active(false);
						}
						else
							GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Estoy ocupado,vuelve luego.");
					}
					else
						GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("No tienes la llave para abrirlo.");
				}

				else if (this.name == "CanecaAbierta(Clone)")
					StartCoroutine(GameObject.Find("Encapuchado(Clone)").gameObject.GetComponent<OtherChar>().Anim(0.5f, 1f));

				else if (this.name == "Patio(Clone)" && GeneralGameManager.advance == 5)
				{
					GameObject.Find("Out").GetComponent<Inventory>().fadeoff();
					time2 = Time.time;
					togo = 1;
				}

				else if (this.name == "DoorPacman(Clone)" && GeneralGameManager.hammer && GeneralGameManager.advance == 8)
				{
					GameObject.Find("Out").GetComponent<Inventory>().fadeoff();
					time2 = Time.time;
					togo = 2;
				}

				else if (this.name == "Personero(Clone)" && GeneralGameManager.advance == 17)
				{
					GameObject.Find("Out").GetComponent<Inventory>().fadeoff();
					time2 = Time.time;
					togo = 5;
				}

				else if (this.name == "ClassroomDoor(Clone)" && GeneralGameManager.advance == 18)
				{
					GameObject.Find("Out").GetComponent<Inventory>().fadeoff();
					time2 = Time.time;
					togo = 7;
				}
			}
		}
	}

	void LateUpdate()
	{
		if (Time.time >= time2 + 1.5f && Time.time <= time2 + 2f)
			Application.LoadLevel (togo);
	}
}
