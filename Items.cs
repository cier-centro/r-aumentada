using UnityEngine;
using System.Collections;

public class Items : Scenario {

	private GameObject[] other;
	private int lay = 2;
	private bool isVisible = true;
	private bool clickOt = false;
	private float time2 = -10f;
	private int togo = 5;

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
				{
					clickOt = true;
					break;
				}
			}

			if (this.ClickLimits(Input.mousePosition) && !clickOt)
			{
				if (this.name == "Locker(Clone)")
				{
					if (GameObject.Find("Manzana(Clone)") != null)
					{
						if (!GameObject.Find("Manzana(Clone)").gameObject.GetComponent<Items>().ClickLimits(Input.mousePosition))
							StartCoroutine(GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Esto es un locker"));
					}
					else
						StartCoroutine(GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Esto es un locker"));
				}

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
					StartCoroutine(GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("¡Has conseguido una manzana!"));
					GeneralGameManager.advance++;
					this.Active(false);
				}

				else if (this.name == "Tablones(Clone)")
				{
					if (GeneralGameManager.hammer)
					{
						StartCoroutine(GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("¡Pudiste desbloquear la puerta!"));
						GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().PutNew("DoorPacman", "puertaPacman", false, 25.05f, 1.09f);
						this.Active(false);
					}
					else
						StartCoroutine(GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Parece que la puerta esta bloqueada. Con la herramienta adecuada se puede abrir."));
				}

				else if (this.name == "Personerocerrado(Clone)")
					StartCoroutine(GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Parece que esta oficina esta bloqueada. Pero se escuchan ruidos."));

				else if (this.name == "Organico(Clone)")
					StartCoroutine(GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Orgánico"));

				else if (this.name == "Papel(Clone)")
					StartCoroutine(GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Papel"));

				else if (this.name == "Plastico(Clone)")
					StartCoroutine(GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Plástico"));

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
							StartCoroutine(GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("Estoy ocupado,vuelve luego."));
					}
					else
						StartCoroutine(GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().TopBall("No tienes la llave para abrirlo."));
				}

				else if (this.name == "CanecaAbierta(Clone)")
				{
					GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().PutNew("CanecaAbierta2", "canecaAbierta", false, 20.9f, -0.63f);
					this.gameObject.GetComponent<Items>().Active(false);
				}

				else if (this.name == "CanecaAbierta2(Clone)")
				{
					GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().PutNew("Encapuchado", "encapuchado_total", true, 20.8f, -1.39f, 0.5f);
					StartCoroutine(GameObject.Find("Encapuchado(Clone)").gameObject.GetComponent<OtherChar>().AnimEnc());
				}

				else if (this.name == "Patio(Clone)" && GeneralGameManager.advance == 5)
				{
					GameObject.Find("Out").GetComponent<Inventory>().fadeoff();
					time2 = Time.time;
					togo = 6;//1
				}

				else if (this.name == "DoorPacman(Clone)" && GeneralGameManager.hammer && GeneralGameManager.advance == 8)
				{
					GameObject.Find("Out").GetComponent<Inventory>().fadeoff();
					time2 = Time.time;
					togo = 7;//2
				}

				else if (this.name == "ClassRoomClose(Clone)" && GeneralGameManager.advance == 18)
				{
					GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().PutNew("ClassroomOpen", "PuertaColegioFinal", false, 50.4f, 1.09f);
					this.Active(false);
				}

				else if (this.name == "ClassroomOpen(Clone)" && GeneralGameManager.advance == 18)
				{
					GameObject.Find("Out").GetComponent<Inventory>().fadeoff();
					time2 = Time.time;
					togo = 12;//7
				}

				//----------------------------------------------------------------------------------------------------------

				else if (this.name == "Cartel1(Clone)")
				{
					this.gameObject.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y);
					this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;
					this.gameObject.transform.localScale = new Vector3 (1.5f, 1.5f, 0f);
				}

				else if (this.name == "Cartel2(Clone)")
				{
					this.gameObject.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y);
					this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;
					this.gameObject.transform.localScale = new Vector3 (1.5f, 1.5f, 0f);
				}

				else if (this.name == "CartelSebusca(Clone)")
				{
					this.gameObject.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y);
					this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;
					this.gameObject.transform.localScale = new Vector3 (0.55f, 0.55f, 0f);
				}

				else if (this.name == "Skatepark(Clone)")
				{
					if (GeneralGameManager.advance == 29)
					{
						GameObject.Find("Out").GetComponent<Inventory>().fadeoff();
						time2 = Time.time;
						togo = 14;//7
					}
					else
						StartCoroutine(GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager_City>().TopBall("¡Aún no ha abierto!"));
				}

				else if (this.name == "EncapuchadoBols(Clone)")
				{
					this.Active(false);
					GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager_City>().PutNew("Encapuchado", "encapuchado_total", true, 50f, -2.6f, 0.5f);
					GameObject.Find("Encapuchado(Clone)").gameObject.GetComponent<OtherChar>().AnimEnc();
				}

				else if (this.name == "Intercom(Clone)" && GeneralGameManager.advance == 35)
				{
					this.gameObject.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y);
					this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;
					this.gameObject.transform.localScale = new Vector3 (1.5f, 1.5f, 0f);
				}
			}
			else
			{
				if (this.name == "Cartel1(Clone)" && this.gameObject.transform.localScale.x >= 1f)
				{
					GameObject.Find("Cartel1(Clone)").gameObject.transform.position = new Vector3(-48.259f, 0.076f);
					GameObject.Find("Cartel1(Clone)").gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
					GameObject.Find("Cartel1(Clone)").gameObject.transform.localScale = new Vector3(0.313f, 0.313f, 0f);
				}

				else if (this.name == "Cartel2(Clone)" && this.gameObject.transform.localScale.x >= 1f)
				{
					GameObject.Find("Cartel2(Clone)").gameObject.transform.position = new Vector3(-39.477f, -0.821f);
					GameObject.Find("Cartel2(Clone)").gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
					GameObject.Find("Cartel2(Clone)").gameObject.transform.localScale = new Vector3(0.313f, 0.313f, 0f);
				}

				else if (this.name == "CartelSebusca(Clone)" && this.gameObject.transform.localScale.x >= 0.5f)
				{
					GameObject.Find("CartelSebusca(Clone)").gameObject.transform.position = new Vector3(-46.25f, -0.53f);
					GameObject.Find("CartelSebusca(Clone)").gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
					GameObject.Find("CartelSebusca(Clone)").gameObject.transform.localScale = new Vector3(0.071f, 0.071f, 0f);
				}

				else if (this.name == "Intercom(Clone)" && this.gameObject.transform.localScale.x >= 1.3f)
				{
					GameObject.Find("Intercom(Clone)").gameObject.transform.position = new Vector3(65.93f, 0.87f);
					GameObject.Find("Intercom(Clone)").gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
					GameObject.Find("Intercom(Clone)").gameObject.transform.localScale = new Vector3(0.366f, 0.366f, 0f);
                    Application.LoadLevel(17);
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
