using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic; //PI
using Random = UnityEngine.Random;

public class GameManager_City : MonoBehaviour {
	
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
	//private GameObject[] objects;
	private List <GameObject> objects = new List<GameObject> ();
	private bool isTalking;
	private bool dirTalk = true;
	private float time;
	private float time2;
	
	void PutBackground()
	{
		bg = background.GetComponent<Background> ();
		bg.Image = "Ciudad";
		bg.PosX = 0;
		bg.PosY = 0;
		bg.Size = 1f;
		bg.Put ();
	}
	
	void PutFloor()
	{
		fl = floor.GetComponent<Floor> ();
		fl.Width = bg.ImageSize.x * bg.Size + 1f;
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
				bnd.PosX = -bg.ImageSize.x * bg.Size / 2 - 0.25f;
			else
				bnd.PosX = bg.ImageSize.x * bg.Size / 2 - 3f;
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
		string[] names = {"Laura", "Camilo", "Maria", "Adan", "Señora", "Chepe", "Nicky", "Ronaldo", "Felipe"};
		string[] assets = {
			"chica-1", //0
			"Camilo", //1
			"chica-2", //2
			"perso_adulto", //3
			"vecina", //5
			"chico-2", //6
			"bravucon-bully-mosntruo", //7
			"bravucon-2-mosntruo", //8
			"bravucon-1-monstruo" //9
		};
		float[] positions = {-64.5f, -60.5f, -66f, -48f, -16.5f, -62.5f, 40f, 42f, 44f};
		other = otherCharac.GetComponent<OtherChar> ();
		
		for (int i = 0, k = names.Length; i < k; i++) 
		{
			other.name = names[i];
			if (i == 0 || i == 1 || i == 4 || i == 5)
				other.Size = 0.8f;
			else
				other.Size = 0.5f;
			other.Image = assets[i];
			other.PosX = positions[i];
			other.PosY = -2.6f;
			other.Solid = false;
			other.Put();
			objects.Add(GameObject.Find(names[i] + "(Clone)"));
		}
	}

	void PutItems()
	{
		string[] images = {"cartel 01 ciudad", "cartel 02 ciudad", "Se_busca", "globo 02", "Control_Blanco_IZQ", "Control_Blanco_DER", "intercom"};
		string[] names = {"Cartel1", "Cartel2", "CartelSebusca", "Skatepark", "Control_Blanco_IZQ", "Control_Blanco_DER", "Intercom"};
		float[] positionX = {-48.259f, -39.477f, -46.25f, 33.56f, 0f, 0f, 65.93f};
		float[] positionY = {0.076f, -0.821f, -0.53f, -0.62f, 0f, 0f, 0.87f};
		int[] lay = {2, 2, 2, 2, 7, 7, 2};
		bool[] visible = {true, true, true, false, true, true, true};
		float[] sizes = {0.313f, 0.313f, 0.071f, 2.12f, 1f, 1f, 0.366f};
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
			objects.Add(GameObject.Find(name1 + "(Clone)"));
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
			itm.Put();
		}
	}
	
	void LoadSavedGame()
	{
		if (GeneralGameManager.advance >= 30) 
		{
			GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position = new Vector3 (34f, GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.y);
			GameObject.Find ("Maria(Clone)").gameObject.transform.position = new Vector3 (-18.4f, GameObject.Find ("Maria(Clone)").gameObject.transform.position.y);
			GameObject.Find ("Laura(Clone)").gameObject.transform.position = new Vector3 (10.3f, GameObject.Find ("Laura(Clone)").gameObject.transform.position.y);
			GameObject.Find ("Chepe(Clone)").gameObject.transform.position = new Vector3 (8.1f, GameObject.Find ("Chepe(Clone)").gameObject.transform.position.y);
			GameObject.Find ("Adan(Clone)").gameObject.transform.position = new Vector3 (12.4f, GameObject.Find ("Adan(Clone)").gameObject.transform.position.y);
			GameObject.Find ("Camilo(Clone)").gameObject.transform.position = new Vector3 (-42f, GameObject.Find ("Chepe(Clone)").gameObject.transform.position.y);
			objects.Remove(GameObject.Find ("Nicky(Clone)"));
			GameObject.Find ("Nicky(Clone)").gameObject.GetComponent<OtherChar>().Active(false);
			GameObject.Find ("Ronaldo(Clone)").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("bravucon-2-transicion");
			GameObject.Find ("Felipe(Clone)").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("bravucon-1-transicion");
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
		objects.Clear ();
		Load ();
		LoadSavedGame ();
		history = new string[]{"Laura", "Adan", "Camilo", "Maria", "Chepe", "Chepe", "Adan", "Felipe", "Ronaldo", "Adan", "Adan", "Encapuchado"};
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
				else if (P[i] == "Adan" || P[i] == "Señora")
					bln.PosY = 0f;
				else
					bln.PosY = -1f;
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
					"¿Qué? ¿vamos a jugar hoy?",
					"¡En la cancha está el equipo ARDIDOS y Julieta juega con ellos!",
					"¡Vamos a jugar!",
					"Yo no soy bueno en fútbol y ARDIDOS ganó el torneo pasado",
					"Yo tengo que entrenar para el campeonato de micro del colegio.",
					"Mi hermana me ha dicho  que ARDIDOS es un equipo tramposo y rencoroso.",
					"A mí no me gusta jugar solo con hombres, si puedo marcar una niña me siento más cómoda."
				};
				boys = new string[]{"Laura", "Laura", "Laura", "Camilo", "Laura", "Chepe", "Maria"};
				plus = true;
				break;
			
			case 1:
				conv = new string[]{
					"Muchachos soy el líder local. Deben irse hoy temprano a sus casas.",
					"No quiero alarmarlos pero un chico desapareció en el barrio y es mejor que no estén en la calle.",
					"En la pared hay un volante con información donde dice la hora y los lugares donde no pueden estar.",
					"Échenle un vistazo."
				};
				boys = new string[]{"Adan", "Adan", "Adan", "Adan"};
				top	= "Haz click en los carteles para verlos mejor";
				break;
				
			case 2:
				conv = new string[]{
					"¡O sea que no podemos hacer nada! ¡Ya no podremos divertinos!",
					"¡No es cierto!"
				};
				boys = new string[]{"Camilo", "Maria"};
				plus = true;
				break;
				
			case 3:
				conv = new string[]{
					"Es complicado lo que pasó con la chica. La última vez que la vieron estaba en el colegio.",
					"El barrio va de mal en peor.",
					"Sigan las instrucciones que dice el Líder Local. Nosotros estamos pensando qué hacer, no hay ninguna pista."
				};
				boys = new string[]{"Maria", "Maria", "Señora"};
				break;
				
			case 4:
				conv = new string[]{
					"¿La gente del barrio sabe lo que está pasando, ah?",
					"Hablamos con el edil...y...",
					"¿Tú sabes que hace un edil?"
				};
				boys = new string[]{"Chepe", "Adan", "Laura"};
				plus = true;
				break;
				
			case 5:
				conv = new string[]{
					"Ajá, y que vieron al pelao a la salida del colegio pero no asiste a ninguna clase.",
					"El edil dice que no debe alertarse a la comunidad. El Alcalde ordenó no hacer nada.",
					"Y parece que nadie lo está buscando tampoco.",
					"Ey, y si hacemos volantes? De pronto alguien sepa algo y nos pueda contar.",
					"No creo que el edil nos deje hacer eso."
				};
				boys = new string[]{"Chepe", "Adan", "Laura", "Chepe", "Adan"};
				plus = true;
				break;
			
			case 6:
				conv = new string[]{
					"Está bien. Hagan los volantes, yo los acompaño a repartirlos"
				};
				boys = new string[]{"Adan"};
				plus = true;
				break;
				
			case 7:
				if (GeneralGameManager.advance == 30)
				{
					conv = new string[]{
						"Ey jugador, después de hablar contigo nos sentimos mal",
						"y queremos contarte algo sin que se entere Nicky.",
						"Nuestro padre fue el que raptó al niño. Lo vimos en la mansión el día que lo llevó."
					};
					boys = new string[]{"Felipe", "Felipe", "Ronaldo"};
					plus = true;
				}
				else
				{
					conv = new string[]{
						"No quiero hablar ahora."
					};
					boys = new string[]{"Felipe"};
					line--;
				}
				break;

			case 8:
				conv = new string[]{
					"Pero no le digas a nadie que te contamos.",
					"Sabemos que puedes hacer algo."
				};
				boys = new string[]{"Ronaldo", "Felipe"};
				break;

			case 9:
				conv = new string[]{
					"¡El alcalde tiene al niño! Los hermanos de Nicky me lo contaron.",
					"¿Y qué quiere hacer con él?",
					"Ni idea, pero sé dónde está.",
					"¡Es una acusación muy peligrosa!",
					"Tiene que dejar de ser Alcalde.",
					"Pero ¿qué podemos hacer?"
				};
				boys = new string[]{"Player", "Adan", "Player", "Adan", "Player", "Laura"};
				plus = true;
				break;
				
			case 10:
				conv = new string[]{
					"Tenemos dos formas de acción contra el Alcalde:",
					"La protesta pública y la revocatoria de mandato.",
					"Dada la situación en la que nos encontramos",
					"Es mejor que primero nos manifestemos públicamente contra él.",
					"¡Bien! Organicen  la protesta! Todos deben saberlo!",
					"Por favor JUGADOR no te metas en problemas!",
					"Buscaré la forma de entrar a la Mansión."
				};
				boys = new string[]{"Adan", "Adan", "Adan", "Adan", "Player", "Adan", "Player"};
				plus = true;
				break;
			
			case 11:
				conv = new string[]{
					"Esto podría ser útil. Nos veremos en la casa del Alcalde!"
				};
				boys = new string[]{"Encapuchado"};
				top = "Te han dado un papel con tre digitos";
				plus = true;
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
		Debug.Log (GeneralGameManager.advance);
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
				for (int i = 0, k = objects.Count; i <k; i++) 
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
			StartCoroutine (TopBall ("Mh.. la ciudad también está extraña"));

		if (GeneralGameManager.advance == 21 && ButtonQuest.put && time2 >= 0.3f && time2 <= 0.3f + Time.deltaTime)
			GameObject.FindGameObjectWithTag ("General").gameObject.GetComponent<GeneralGameManager> ().PutQuestion ();

		if (GeneralGameManager.advance == 22) 
		{
			GameObject.Find ("Maria(Clone)").gameObject.transform.position = new Vector3 (-51.8f, GameObject.Find ("Maria(Clone)").gameObject.transform.position.y);
			GameObject.Find ("Laura(Clone)").gameObject.transform.position = new Vector3 (-49.8f, GameObject.Find ("Laura(Clone)").gameObject.transform.position.y);
			GameObject.Find ("Chepe(Clone)").gameObject.transform.position = new Vector3 (-45f, GameObject.Find ("Chepe(Clone)").gameObject.transform.position.y);
			GameObject.Find ("Camilo(Clone)").gameObject.transform.position = new Vector3 (-42f, GameObject.Find ("Chepe(Clone)").gameObject.transform.position.y);
		}

		if (GeneralGameManager.advance == 23 && ButtonQuest.put && time2 >= 0.3f && time2 <= 0.3f + Time.deltaTime)
			GameObject.FindGameObjectWithTag ("General").gameObject.GetComponent<GeneralGameManager> ().PutQuestion ();

		if (GeneralGameManager.advance == 24) 
		{
			GameObject.Find ("Maria(Clone)").gameObject.transform.position = new Vector3 (-18.4f, GameObject.Find ("Maria(Clone)").gameObject.transform.position.y);
			GameObject.Find ("Laura(Clone)").gameObject.transform.position = new Vector3 (10.3f, GameObject.Find ("Laura(Clone)").gameObject.transform.position.y);
			GameObject.Find ("Chepe(Clone)").gameObject.transform.position = new Vector3 (8.1f, GameObject.Find ("Chepe(Clone)").gameObject.transform.position.y);
			GameObject.Find ("Adan(Clone)").gameObject.transform.position = new Vector3 (12.4f, GameObject.Find ("Adan(Clone)").gameObject.transform.position.y);
		}

		if (GeneralGameManager.advance == 25 && ButtonQuest.put && time2 >= 0.3f && time2 <= 0.3f + Time.deltaTime)
			GameObject.FindGameObjectWithTag ("General").gameObject.GetComponent<GeneralGameManager> ().PutQuestion ();

		if (GeneralGameManager.advance == 27 && ButtonQuest.put && time2 >= 0.3f && time2 <= 0.3f + Time.deltaTime)
			GameObject.FindGameObjectWithTag ("General").gameObject.GetComponent<GeneralGameManager> ().PutQuestion ();

		if (GeneralGameManager.advance == 31) 
		{
			GameObject.Find ("Ronaldo(Clone)").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("bravucon-2-normal");
			GameObject.Find ("Felipe(Clone)").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("bravucon-1-normal");
		}

		if (GeneralGameManager.advance == 32 && ButtonQuest.put && time2 >= 0.3f && time2 <= 0.3f + Time.deltaTime)
			GameObject.FindGameObjectWithTag ("General").gameObject.GetComponent<GeneralGameManager> ().PutQuestion ();

		if (GeneralGameManager.advance == 34 && GameObject.Find("EncapuchadoBols(Clone)") == null)
			PutNew ("EncapuchadoBols", "bolsasMor", false, 50f, -2.6f);
		
		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();
	}
}
