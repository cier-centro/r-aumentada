using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
	
	public string scenarioName;
	public GameObject bonus;
	public GameObject player;
	public GameObject item;
	public GameObject background;
	public GameObject floor;
	public GameObject button;
	public GameObject balloon;
	public GameObject otherCharac;
	public GameObject askChar;
	public GameObject feedBack;

	public static float xMax;
	public static float xMin;

	private Talk bln;
	private Ask askAsker;
	private Background bg;
	private Columns clm;
	private Floor fl;
	private Floor bnd;
	private Bonus bns;
	private Player ply;
	private OtherChar other;
	private ButtonMv btn;
	private Items itm;
	private Real fb;

	private AudioSource backSound;
	private AudioSource globoSound;

	private string[] history;
	private bool put;
	private static int line = 0;
	private string[] conv;
	private string[] boys;
	private GameObject[] objects;
	private bool isTalking;
	private bool dirTalk = true;
	private bool encap = false;
	private float time;
	private float time2;

	void PutBackground()
	{
		bg = background.GetComponent<Background> ();
		bg.Image = "escenario_colegio";
		bg.PosX = 0;
		bg.PosY = 0;
		bg.Size = 1.5f;
		bg.Put ();
		PutColumns ();
	}

	void PutColumns()
	{
		clm = background.GetComponent<Columns> ();
		clm.Image = "escenario_colegio_columnas";
		clm.PosX = 0;
		clm.PosY = 0;
		clm.Size = 1.40625f;
		clm.Put ();
	}

	void PutFloor()
	{
		fl = floor.GetComponent<Floor> ();
		fl.Width = bg.ImageSize.x + 1f;
		fl.Height = 0.5f;
		fl.PosX = bg.PosX;
		fl.PosY = -5.5f;
		fl.Rotation = 0f;
		fl.TagStr = "Floor";
		fl.PutFloor ();
	}

	void PutBounds()
	{
		bnd = floor.GetComponent<Floor> ();
		for (int i = 0; i < 2; i++) 
		{
			bnd.TagStr = "Finish";
			bnd.Width = 0.5f;
			bnd.Height = bg.ImageSize.y;
			if (i == 0)
				bnd.PosX = -bg.ImageSize.x / 2 + 1f;
			else
				bnd.PosX = 4.5f;
			bnd.PosY = 0f;
			bnd.Rotation = 0f;
			bnd.PutFloor();
		}
	}

	public void PutMove()
	{
		string[] names = {"Left", "Right", "A", "B"};
		btn = button.GetComponent<ButtonMv> ();

		for (int i = 0, k = names.Length; i < k; i++) 
		{
			btn.Image = "manzana";
			btn.Size = 1.3f;
			btn.StrName = names[i];
			btn.Put();
		}
	}

	void PutPlayer()
	{
		ply = player.GetComponent<Player> ();
		ply.Image = "PrincipalMan";
		ply.Size = 1f;
		ply.PosX = -xMax + 2f;
		ply.PosY = fl.PosY + fl.Height / 2 + ply.ImageSize.y / 2f;
		ply.Put ();
	}
	
	void PutCharacters()
	{
		string[] names = {"Maria", "Camilo", "Nicky", "Ronaldo", "Felipe", "Profesor", "Chepe", "Laura"};
		string[] assets = {
			"chica-2", //0
			"Camilo", //1
			"bravucon-bully-mosntruo", //2
			"bravucon-1-monstruo", //3
			"bravucon-2-mosntruo", //4
			"profesor2", //5
			"chico-2", //6
			"chica-1" //8
		};
		float[] positions = {-50f, -52f, -33f, -30.5f, -29f, 4.5f, 19.3f, 32.2f};
		other = otherCharac.GetComponent<OtherChar> ();

		for (int i = 0, k = names.Length; i < k; i++) 
		{
			other.name = names[i];
			if (i ==1 || i == 5 || i == 6 || i == 7)
				other.Size = 0.8f;
			else
				other.Size = 0.5f;
			other.Image = assets[i];
			other.PosX = positions[i];
			other.PosY = -2.6f;
			other.Solid = false;
			other.Put();
		}
	}

	void PutItems()
	{
		string[] images = {
			"lockerIzq",
			"lockerabiertoDer",
			"manzana",
			"caneca cerrada",
			"tablones",
			"personerocerrado",
			"candado",
			"lockerDer",
			"lockerabiertoIz",
			"encapuchado_total",
			"encapuchado_total",
			"encapuchado_total",
			"tablones",
			"Control_Blanco_IZQ",
			"Control_Blanco_DER",
			"globo 02"
		};
		string[] names = {
			"Locker",
			"LockerabiertoDer",
			"Manzana",
			"CanecaAbierta",
			"Tablones",
			"Personerocerrado",
			"Candado",
			"Locker",
			"LockerabiertoIzq",
			"Organico",
			"Papel",
			"Plastico",
			"ClassRoomClose",
			"Control_Blanco_IZQ",
			"Control_Blanco_DER",
			"Patio"
		};
		float[] positionX = {-19f, -17.194f, -17.441f, 20.9f, 25.3f, 34f, 34f, 44.7f, 44.003f, 54f, 55.5f, 57f, 50.76f, 0f, 0f, 9.6f};
		float[] positionY = {-0.56f, -0.324f, -0.037f, -1.37f, 0.63f, 0f, -1.18f, -0.56f, -0.33f, -1.84f, -1.84f, -1.84f, 0.63f, 0f, 0f, 1.3f};
		int[] lay = {2, 3, 4, 5, 2, 2, 3, 2, 3, 2, 2, 2, 2, 7, 7, 2};
		bool[] visible = {true, false, false, true, true, true, true, true, false, false, false, false, false, true, true, false};
		float[] sizes = {1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 0.35f, 0.35f, 0.35f, 1f, 1f, 1f, 3.8f};
		itm = item.GetComponent<Items> ();

		for (int i = 0, k = names.Length; i < k; i++) 
		{
			itm.name = names[i];
			itm.Image = images[i];
			itm.Size = sizes[i];
			itm.PosX = positionX[i];
			itm.PosY = positionY[i];
			itm.Lay = lay[i];
			itm.IsVisible = visible[i];
			itm.Put();
		}
	}

	void PutBonus(float min, float max)
	{
		bns = bonus.GetComponent<Bonus> ();
		bns.Image = "empanada";
		bns.Size = 1f;

		for (int i = 0; i < 10; i++) 
		{
			bns.PosX = Random.Range (min, max);
			bns.PosY = Random.Range (0f, 2.6f);
			bns.Put ();
		}
	}

	void PutSound()
	{
		backSound = gameObject.AddComponent<AudioSource> ();
		backSound.clip = Resources.Load ("incidental01") as AudioClip;
		backSound.loop = true;
		backSound.Play ();
	}

	public void PutNew(string name1, string asset, bool talk, float posx, float posy, float size = 1f)
	{
		if (talk) 
		{
			other = otherCharac.GetComponent<OtherChar> ();
			other.name = name1;
			other.Size = size;
			other.Image = asset;
			other.PosX = posx;
			other.PosY = posy;
			other.Solid = false;
			other.Put ();
			objects = GameObject.FindGameObjectsWithTag("Other");
		} 
		else 
		{
			itm = item.GetComponent<Items> ();
			itm.name = name1;
			itm.Image = asset;
			itm.Size = size;
			itm.PosX = posx;
			itm.PosY = posy;
			itm.IsVisible = true;
			if (name1 == "CanecaAbierta2")
				itm.Lay = 5;
			itm.Put();
		}
	}

	void LoadSavedGame()
	{
		if (GeneralGameManager.advance >= 4) 
		{
			if (line >= 2)
				GameObject.Find ("Camilo(Clone)").gameObject.transform.position = new Vector3 (-1f, GameObject.Find ("Camilo(Clone)").gameObject.transform.position.y);
		}
		if (GeneralGameManager.advance >= 6) 
		{
			GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position = new Vector3 (2f, GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.y);
			GameObject[] finish = GameObject.FindGameObjectsWithTag("Finish");
			for (int i = 0, k = finish.Length; i < k; i++)
			{
				if (finish[i].gameObject.transform.position.x >= 0f)
					finish[i].gameObject.transform.position = new Vector3(xMax + 0.25f, 0f);
			}
		}
		if (GeneralGameManager.advance >= 10) 
		{
			GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position = new Vector3 (25f, GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.y);
			GameObject.Find ("Maria(Clone)").gameObject.transform.position = new Vector3 (42f, GameObject.Find ("Maria(Clone)").gameObject.transform.position.y);
			GameObject.Find ("Camilo(Clone)").gameObject.transform.position = new Vector3 (44f, GameObject.Find ("Camilo(Clone)").gameObject.transform.position.y);
			GameObject.Find ("Chepe(Clone)").gameObject.transform.position = new Vector3 (46f, GameObject.Find ("Chepe(Clone)").gameObject.transform.position.y);
			GameObject.Find ("Laura(Clone)").gameObject.transform.position = new Vector3 (48f, GameObject.Find ("Laura(Clone)").gameObject.transform.position.y);
			GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().PutNew("DoorPacman", "puertaPacman", false, 25.05f, 1.09f);
			GameObject.Find ("Tablones(Clone)").gameObject.GetComponent<Items>().Active(false);
			GameObject.Find ("CanecaAbierta(Clone)").gameObject.GetComponent<Items>().Active(false);
			PutNew("Encapuchado", "caneca medio abierta", true, 20.9f, -1.3f);
		}

		if (GeneralGameManager.advance >= 18) 
		{
			GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position = new Vector3 (35f, GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.y);
			PutNew("Personero", "PersoneroAbierto", true, 34f, 0f);
			GameObject.Find("Candado(Clone)").gameObject.GetComponent<Items>().Active(false);
			GameObject.Find("Personerocerrado(Clone)").gameObject.GetComponent<Items>().Active(false);
		}
	}

	void Load()
	{
		PutBackground ();
		xMin = bg.PosX - bg.ImageSize.x / 2f;
		xMax = bg.PosX + bg.ImageSize.x / 2f;
		PutBounds ();
		PutFloor ();
		PutMove ();
		PutPlayer ();
		PutCharacters ();
		PutItems ();
		PutBonus (xMin, xMax);
		PutSound ();
		time2 = 10f;
		if (line == 0)
			time = 0f;
		else
			time = 2f;
	}

	void Awake () 
	{
		Load ();
		LoadSavedGame ();
		history = new string[] {
			"Maria",
			"Nicky",
			"Profesor",
			"Chepe",
			"Encapuchado",
			"Encapuchado",
			"Camilo",
			"Camilo",
			"Personero",
			"Laura",
			"Personero"
		};
		objects = GameObject.FindGameObjectsWithTag("Other");
		globoSound = gameObject.AddComponent<AudioSource> ();
		globoSound.clip = Resources.Load ("aparece_globo") as AudioClip;
	}

	public void RemoveButtons()
	{
		if (GameObject.FindWithTag ("Left") != null) 
		{
			GameObject.FindGameObjectWithTag ("Left").gameObject.GetComponent<ButtonMv> ().Active (false);
			GameObject.FindGameObjectWithTag ("Right").gameObject.GetComponent<ButtonMv> ().Active (false);
			GameObject.FindGameObjectWithTag("A").gameObject.GetComponent<ButtonMv> ().Active (false);
			GameObject.FindGameObjectWithTag("B").gameObject.GetComponent<ButtonMv> ().Active (false);
		}
	}

	IEnumerator Conversation(string[] P, string [] text, bool direction, string top, bool plus)
	{
		bln = balloon.GetComponent<Talk> ();
		put = true;
		isTalking = true;
		int i = 0;
		
		while (i < text.Length)
		{	
			if (put)
			{
				bln.Image = "globo 01";
				bln.PosX = GameObject.Find(P[i] + "(Clone)").gameObject.transform.position.x;
				if (P[i] == "Player")
					bln.PosY = -2f;
				else if (P[i] == "Personero")
					bln.PosY = 1f;
				else
					bln.PosY = -1f;
				bln.Size = 1.7f;
				bln.Dir = direction;
				bln.Put();
				globoSound.Play();
				if (direction)
					StartCoroutine(GameObject.FindGameObjectWithTag("Talk").gameObject.GetComponent<Talk>().Anim(-1.5f, text[i]));
				else
					StartCoroutine(GameObject.FindGameObjectWithTag("Talk").gameObject.GetComponent<Talk>().Anim(1.5f, text[i]));
				put = false;
				i++;
			}
			yield return null;
		}
		if (top != "") 
		{
			while (!put)
				yield return null;
			StartCoroutine(TopBall (top));
		}
		if (plus)
			GeneralGameManager.advance++;
		time2 = 0f;
		PutMove();
		isTalking = false;
	}
	
	public IEnumerator TopBall(string textTop)
	{
		bool topActive = false;

		while (!topActive) 
		{
			if (GameObject.FindWithTag ("Dog") != null) 
				GameObject.FindGameObjectWithTag ("Dog").gameObject.GetComponent<Ask> ().Active (false);
			else
			{
				RemoveButtons ();
				askAsker = askChar.GetComponent<Ask> ();
				askAsker.Image = "globo 02";
				askAsker.Put ();
				globoSound.Play ();
				StartCoroutine (GameObject.Find ("Ask(Clone)").gameObject.GetComponent<Ask> ().Anim (2f, textTop));
				topActive = true;
			}

			yield return null;
		}
	}

	public void FeedBack(string textFB)
	{
		RemoveButtons ();
		fb = feedBack.GetComponent<Real>();
		fb.Image = "globo 02";
		fb.Put ();
		globoSound.Play ();
		StartCoroutine (GameObject.Find ("FeedBack(Clone)").gameObject.GetComponent<Real> ().Anim (4.5f, textFB));
	}

	void ConversationSeq (int i)
	{
		string top = "";
		bool plus = false;
		if (GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.x <= objects [i].gameObject.transform.position.x)
			dirTalk = true;
		else
			dirTalk = false;
		RemoveButtons();
		if (objects [i].gameObject.name == history [line] + "(Clone)") 
		{
			switch (line)
			{
			case 0:
				conv = new string[]{
					"Últimamente profesores que tratan mal a sus estudiantes",
					"Aparecen amarrados dentro de los salones.",
					"Esto debe ser obra del encapuchado. Nunca nadie lo ha visto.",
					"El personero debería hacer algo ante esta situación, pero no hace nada. ",
					"No digas nada pero me dijeron que hay un lugar custodiado y escondido en el colegio, repleto de libros.", 
				};
				boys = new string[]{"Maria", "Maria", "Maria", "Camilo", "Maria"};
				break;
				
			case 1:
				conv = new string[]{
					"Já, Niño, con verte una vez por día me sobra. Si te vuelvo a ver…"
				};
				boys = new string[]{"Nicky"};
				break;

			case 2:
				conv = new string[]{
					"¿QUÉ SIGUEN HACIENDO AQUÍ NIÑOS?",
					"¡VAYAN A HACER LA FORMACIÓN YA!",
					"Cada día que pasa los profesores nos tratan peor.",
					"No hay nada que diga que lo que hace es incorrecto.",
					"Ojalá el Encapuchado haga algo. Mejor vamos a formar."
				};
				boys = new string[]{"Profesor", "Profesor", "Camilo", "Camilo", "Camilo"};
				top = "Toca el patio para ir a formar.";
				plus = true;
				break;

			case 3:
				conv = new string[]{
					"Ey mi vale, no te creo que acá nos traten así..."
				};
				boys = new string[]{"Chepe"};
				break;

			case 4:
				conv = new string[]{
					"Quién eres tu?",
					"Hola. No importa quién soy.",
					"Lo importante ahora es detener lo que está pasando.",
					"Me gusta tu disfraz",
					"¡No es un disfraz! Es mi traje de superhéroe vigilante",
					"Con un pasado oscuro que lucha por la-verdad y la justicia.",
					"Y ¿contra quién luchas?",
					"Contra mi peor enemigo.",
					"...",
					"Okey, no sé quién es pero quiero descubrirlo.",
					"¿No ves como se comporta la gente? ¿y esas sustancias verdes que parecen mocos?",
					"Algo muy raro pasa.",
					"Eres chistoso, te ayudaré. ¿Tienes alguna pista?",
					"No, o sí. No lo sé, no puedo pensar con el estómago vacío."
				};
				boys = new string[]{"Player", "Encapuchado", "Encapuchado", "Player", "Encapuchado", "Encapuchado", "Player", "Encapuchado", "Player", "Encapuchado", "Encapuchado", "Encapuchado", "Player", "Encapuchado"};
				break;

			case 5:
				if (GeneralGameManager.advance == 8)
				{
					conv = new string[]{
						"No tires porquerías a mi guarida… Momento… ¡Es una manzana!",
						"Encontré este martillo al fondo de la caneca, quizá pueda servirte."
					};
					boys = new string[]{"Encapuchado", "Encapuchado"};
					top = "Martillo agregado a tu inventario";
				}
				else
				{
					conv = new string[]{
						"Tengo mucha hambre para hablar"
					};
					boys = new string[]{"Encapuchado"};
					line--;
				}
				break;

			case 6:
				if (GeneralGameManager.advance == 10)
				{
					conv = new string[]{
						"JUGADOR, Hablamos con Chepe y pensamos que las sanciones públicas no deberían ser permitidas",
						"Sí, como le pasó a Pablo hace unas horas en el patio.",
						"Pero ¿cómo confirmarlo? Si sólo tuviéramos algún manual o reglamento.",
						"Encontré estos papeles regados por la biblioteca. Nicky y su parche estaban escondiéndolos. ¡Leámoslos!",
						"\"Los estudiantes serán sancionados sin atentar contra su dignidad\".",
						"\"Los estudiantes serán sancionados en público si la falta atentó contra los valores de la institución\".",
						"\"Los estudiantes serán sancionados sin atentar contra sus derechos\".",
						"\"Los estudiantes serán sancionados frente a otros si la falta atentó contra el director\"."
					};
					boys = new string[]{"Camilo", "Laura", "Chepe", "Player", "Chepe", "Maria", "Camilo", "Laura"};
					plus = true;
				}
				else
				{
					conv = new string[]{"No quiero hablar!"};
					boys = new string[]{"Camilo"};
					line--;
				}
				break;

			case 7:
				conv = new string[]{
					"Deberíamos decirle la queja a alguien.",
					"En mi colegio había un personero ¿aquí no, qué?",
					"Sí, pero nadie lo ha visto en mucho tiempo.",
					"¿Y qué hace un personero?",
					"Ey mi vale, ya que encontraste la biblioteca deberías hacer algo con el Personero?"
				};
				boys = new string[]{"Camilo", "Chepe", "Maria", "Laura", "Chepe"};
				plus = true;
				break;

			case 8:
				conv = new string[]{
					"Soy Pedro, el personero del colegio.",
					"O sea ¿No crees que soy genial por ser el Personero? Tengo mi oficina y todo.",
					"¿Qué necesitas? O sea ¿Quieres que te enseñe a ser genial verdad?",
					"No no, los profesores andan raros. Nos castigan de una forma poco \"elegante\", me parece.",
					"¿No deberías hacer algo?",
					"No sabría qué hacer, nunca me han dicho mis funciones.",
					"O sea pregunté a todos pero nunca me dijeron. ¿Necesitas algo más?"
				};
				boys = new string[]{"Personero", "Personero", "Personero", "Player", "Player", "Personero", "Personero"};
				plus = true;
				break;

			case 9:
				conv = new string[]{
					"¡Vaya, lo encontraste!",
					"O sea, hablaré con mi amiga la Rectora ¿okey?",
					"No, tienes que pasar una queja formal.",
					"Pero… ¿a dónde?"
				};
				boys = new string[]{"Laura", "Personero", "Laura", "Personero"};
				plus = true;
				break;

			case 10:
				conv = new string[]{
					"Tendremos que ir al Consejo Directivo, conozco una ruta fácil. ¡Vamos!"
				};
				boys = new string[]{"Personero"};
				break;

			default:
				conv = new string[]{
					"¡No quiero hablar ahora!"
				};
				boys = new string[]{objects [i].gameObject.name.Substring(0, objects[i].gameObject.name.Length -7)};
				break;
			}
			StartCoroutine (Conversation (boys, conv, dirTalk, top, plus));
			if (line < history.Length -1)
				line++;
		} 
		else 
		{
			string [] conv = {"¡No tengo nada que decirte! Mejor busca a " + history [line]};
			string [] boys = {objects [i].gameObject.name.Substring(0, objects[i].gameObject.name.Length -7)};
			StartCoroutine (Conversation (boys, conv, dirTalk, top, plus));
		}
	}

	void FixedUpdate () 
	{
		time += Time.deltaTime;
		time2 += Time.deltaTime;
		if (Input.GetMouseButtonDown (0)) 
		{
			if (!put && GameObject.FindWithTag ("Talk") != null) 
			{
				put = true;
				GameObject.FindGameObjectWithTag ("Talk").gameObject.GetComponent<Talk> ().Active (false);
				GameObject.FindGameObjectWithTag ("Conversation").gameObject.GetComponent<Text> ().text = "";
			} 
			else if (!isTalking) 
			{
				for (int i = 0, k = objects.Length; i <k; i++) 
				{
					if (objects [i].gameObject.GetComponent<OtherChar> ().ClickLimits (Input.mousePosition) && !GameObject.FindGameObjectWithTag ("Left").gameObject.GetComponent<ButtonMv> ().ClickLimits (Input.mousePosition) &&
						!GameObject.FindGameObjectWithTag ("Right").gameObject.GetComponent<ButtonMv> ().ClickLimits (Input.mousePosition) && !GameObject.FindGameObjectWithTag ("A").gameObject.GetComponent<ButtonMv> ().ClickLimits (Input.mousePosition) && 
						!GameObject.FindGameObjectWithTag ("B").gameObject.GetComponent<ButtonMv> ().ClickLimits (Input.mousePosition))
						ConversationSeq (i);
				}
			}

			if (GameObject.FindWithTag ("Dog") != null) 
			{
				if (GameObject.FindGameObjectWithTag ("Dog").gameObject.GetComponent<Ask> () != null) 
				{
					GameObject.FindGameObjectWithTag ("Dog").gameObject.GetComponent<Ask> ().Active (false);
					GameObject.FindGameObjectWithTag ("Top").gameObject.GetComponent<Text> ().text = "";
				} 
				else 
				{
					GameObject.FindGameObjectWithTag ("Dog").gameObject.GetComponent<Real> ().Active (false);
					GameObject.Find ("TextReal").gameObject.GetComponent<Text> ().text = "";
				}

				if (GameObject.Find ("Button(Clone)") == null) 
				{
					time2 = 0f;
					ButtonQuest.put = true;
					PutMove ();
				}
			}
		}

		if (time > 1f && time < 1f + Time.fixedDeltaTime)
			StartCoroutine (TopBall ("Mh.. el colegio también está extraño.. ¿que será esa cosa verde?"));

		if (line == 2 && GeneralGameManager.advance == 4) 
			GameObject.Find ("Camilo(Clone)").gameObject.transform.position = new Vector3 (-1f, GameObject.Find ("Camilo(Clone)").gameObject.transform.position.y);

		if (GeneralGameManager.advance == 6) 
		{
			GameObject[] finish = GameObject.FindGameObjectsWithTag ("Finish");
			for (int i = 0, k = finish.Length; i < k; i++) 
			{
				if (finish [i].gameObject.transform.position.x >= 6.5f)
					finish [i].gameObject.transform.position = new Vector3 (xMax + 0.25f, finish [i].gameObject.transform.position.y);
			}
			if (line == 4 && ButtonQuest.put && time2 >= 0.3f && time2 <= 0.3f + Time.deltaTime)
				GameObject.FindGameObjectWithTag ("General").gameObject.GetComponent<GeneralGameManager> ().PutQuestion ();
		}

		if (GeneralGameManager.advance == 7 && line == 5) 
			GeneralGameManager.apple = true;

		if (GeneralGameManager.advance == 8) 
		{
			if (GameObject.Find("Encapuchado(Clone)") != null && !encap)
			{
				GameObject.Find("Encapuchado(Clone)").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("caneca medio abierta");
				GameObject.Find("Encapuchado(Clone)").gameObject.transform.position = new Vector3(20.9f, -1.3f);
				GameObject.Find("Encapuchado(Clone)").gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
				encap = true;
			}
			if (GameObject.Find("CanecaAbierta2(Clone)") != null)
				GameObject.Find("CanecaAbierta2(Clone)").gameObject.GetComponent<Items>().Active(false);
			if (line == 6)
				GeneralGameManager.hammer = true;
		}

		if (GeneralGameManager.advance == 10) 
		{
			GeneralGameManager.paper = true;
			GeneralGameManager.key = true;
		}

		if (GeneralGameManager.advance == 11 && ButtonQuest.put && time2 >= 0.3f & time2 <= 0.3f + Time.deltaTime)
			GameObject.FindGameObjectWithTag("General").gameObject.GetComponent<GeneralGameManager>().PutQuestion();

		if (GeneralGameManager.advance == 14 && ButtonQuest.put && time2 >= 0.3f & time2 <= 0.3f + Time.deltaTime)
			GameObject.FindGameObjectWithTag("General").gameObject.GetComponent<GeneralGameManager>().PutQuestion();

		if (GeneralGameManager.advance == 15)
			StartCoroutine(GameObject.Find ("Laura(Clone)").gameObject.GetComponent<OtherChar> ().Move (34f));

		if (GeneralGameManager.advance == 16 && ButtonQuest.put && time2 >= 0.3f & time2 <= 0.3f + Time.deltaTime)
			GameObject.FindGameObjectWithTag("General").gameObject.GetComponent<GeneralGameManager>().PutQuestion();

		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();
	}
}
