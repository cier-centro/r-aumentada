using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
	
	public string scenarioName;
	public GameObject bonus;
	public GameObject player;
	public GameObject door;
	public GameObject background;
	public GameObject floor;
	public GameObject button;
	public GameObject balloon;
	public GameObject otherCharac;
	public GameObject askChar;

	public static float xMax;
	public static float xMin;

	private Talk bln;
	private Ask askAsker;
	private Background bg;
	private Columns clm;
	private Floor fl;
	private Floor bnd;
	private Door dr;
	private Bonus bns;
	private Player ply;
	private OtherChar other;
	private ButtonMv btn;
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

	void PutBackground()
	{
		bg = background.GetComponent<Background> ();
		bg.Image = "escenario_colegio";
		bg.PosX = 0;
		bg.PosY = 0;
		bg.Size = 1f;
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
				bnd.PosX = 7f;
			bnd.PosY = 0f;
			bnd.Rotation = 0f;
			bnd.PutFloor();
		}
	}

	void PutDoor()
	{
		dr = door.GetComponent<Door> ();
		dr.Image = "door";
		dr.Origin = scenarioName;
		dr.Size = 1f;
		dr.PosY = -2.955f;
		for (int i = 0; i < 2; i++) 
		{
			if (i == 0)
			{
				dr.Destination = "Scene2";
				dr.PosX = -bg.ImageSize.x / 2f + dr.ImageSize.x / 2f + 1f;
			}
			else
			{
				dr.Destination = "Scene3";
				dr.PosX = bg.ImageSize.x / 2f - dr.ImageSize.x / 2f - 1f;
			}
			dr.Put ();
		}
	}

	public void PutMove()
	{
		string[] names = {"Left", "Right", "Up", "A", "B"};
		btn = button.GetComponent<ButtonMv> ();

		for (int i = 0, k = names.Length; i < k; i++) 
		{
			btn.Image = "Arrows-" + names[i];
			btn.Size = 0.2f;
			btn.StrName = names[i];
			btn.Put();
		}
	}

	void PutPlayer()
	{
		ply = player.GetComponent<Player> ();
		ply.Image = "PrincipalMan";
		ply.Size = 1f;
		ply.PosX = -dr.PosX;
		ply.PosY = fl.PosY + fl.Height / 2 + ply.ImageSize.y / 2f;
		ply.Put ();
	}
	
	void PutCharacters()
	{
		string[] names = {"Josefa", "Camilo", "Nicky", "Nicky2", "Nicky3", "Profesor", "Encapuchado"};//, "Antonio", "Andrea"};
		string[] assets = {
			"chica-1",
			"chico-2",
			"bravucon-bully-mosntruo",
			"bravucon-1-monstruo",
			"bravucon-2-mosntruo",
			"profesor2",
			"encapuchado_total"
		};//, "chico-3", "chica-2"};
		float[] positions = {-50f, -52f, -38f, -36f, -34f, 7f, 45f};//, 44f, 46f};
		other = otherCharac.GetComponent<OtherChar> ();

		for (int i = 0, k = names.Length; i < k; i++) 
		{
			other.name = names[i];
			if (i <= 1 || i == 5)
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

	void PutBonus(float min, float max)
	{
		bns = bonus.GetComponent<Bonus> ();
		bns.Image = "empanada";
		bns.Size = 1f;

		for (int i = 0; i < 20; i++) 
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

	void LoadSavedGame()
	{
		if (GeneralGameManager.advance >= 5) 
		{
			GameObject.Find ("Camilo(Clone)").gameObject.transform.position = new Vector3 (0f, GameObject.Find ("Camilo(Clone)").gameObject.transform.position.y);
			GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position = new Vector3 (-40f, GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.y);
		}
		if (GeneralGameManager.advance >= 6 && GeneralGameManager.advance < 8)
			GameObject.FindGameObjectWithTag("Player").gameObject.transform.position = new Vector3(2f, GameObject.FindGameObjectWithTag("Player").gameObject.transform.position.y);
		else if (GeneralGameManager.advance >=8)
			GameObject.FindGameObjectWithTag("Player").gameObject.transform.position = new Vector3(43f, GameObject.FindGameObjectWithTag("Player").gameObject.transform.position.y);
	}

	void Load()
	{
		PutBackground ();
		xMin = bg.PosX - bg.ImageSize.x / 2f;
		xMax = bg.PosX + bg.ImageSize.x / 2f;
		PutBounds ();
		PutFloor ();
		PutDoor ();
		PutMove ();
		PutPlayer ();
		PutCharacters ();
		PutBonus (xMin, xMax);
		PutSound ();
	}

	void Awake () 
	{
		Load ();
		LoadSavedGame ();
		history = new string[]{"Josefa", "Nicky", "Profesor", "Camilo", "Camilo", "Encapuchado", "Antonio"};
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
			GameObject.FindGameObjectWithTag ("Up").gameObject.GetComponent<ButtonMv> ().Active (false);
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
			TopBall (top);
		}
		if (plus)
			GeneralGameManager.advance++;
		PutMove();
		isTalking = false;
	}
	
	public void TopBall(string textTop)
	{
		RemoveButtons ();
		askAsker = askChar.GetComponent<Ask>();
		askAsker.Image = "globo 02";
		askAsker.Put ();
		globoSound.Play ();
		StartCoroutine (GameObject.Find ("Ask(Clone)").gameObject.GetComponent<Ask> ().Anim (2f, textTop));
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
					"Últimamente profesores que tratan mal a sus estudiantes aparecen amarrados dentro de los salones.",
					"Esto debe ser obra del encapuchado. Nunca nadie lo ha visto.",
					"El personero debería hacer algo ante esta situación, pero no hace nada. ",
					"No digas nada pero me dijeron que hay un lugar custodiado y escondido en el colegio, repleto de libros.", 
				};
				boys = new string[]{"Josefa", "Josefa", "Camilo", "Josefa"};
				top = "¡Se ha guardado en tu maleta!";
				plus = true;
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
					"El profesor ¿no? Cada vez se pasan más tratándonos mal.",
					"No hay nada que diga que lo que hace es incorrecto.",
					"Ojalá el Encapuchado haga algo. Mejor vamos a formar."
				};
				boys = new string[]{"Profesor", "Profesor", "Camilo", "Camilo", "Camilo", "Camilo"};
				top = "Oprime la flecha de arriba cuando estes frente al patio para ir a formar.";
				plus = true;
				break;

			case 3:
				conv = new string[]{
					"No puedo creer que acá nos traten así..."
				};
				boys = new string[]{"Camilo"};
				break;

			case 4:
				conv = new string[]{
					"Ya decía yo......¿Alguna vez te has dado cuenta que los bravucones nunca están en las formaciones?"
				};
				boys = new string[]{"Camilo"};
				break;

			case 5:
				conv = new string[]{
					"Quién eres tu?",
					"Hola. No importa quién soy. Lo importante ahora es detener lo que está pasando.",
					"¿Y qué esta pasando?",
					"¿No ves como se comporta la gente? ¿y esas sustancias verdes que parecen mocos?",
					"Algo muy raro pasa y quiero descubrirlo!",
					"La gente se está comportando de forma extraña. Mucha mala vibra, no?",
					"Si, todos se ha convertido en personas egoístas, solitarias y nada amigables.",
					"¡Y también tienen un terrible caso de acné verde!",
					"Creo que seguiré investigando. Espero que no desaparezcas...",
					"Desaparecer es mi súper-poder. ¡Suerte, parcero!",
				};
				boys = new string[]{"Player", "Encapuchado", "Player", "Encapuchado", "Encapuchado", "Player", "Encapuchado", "Encapuchado", "Player", "Encapuchado"};
				top = "¡El encapuchado te ha dado un martillo!";
				plus = true;
				break;

			case 6:
				conv = new string[]{
					"JUGADOR, hablamos con el Niño Nuevo y pensamos que las sanciones públicas no deberían ser permitidas",
					"Sí, como le pasó a Pablo hace unas horas en el patio.",
					"Sí, pero ¿cómo confirmarlo?"
				};
				boys = new string[]{"Camilo", "Josefa", "Antonio"};
				top = "Mira los papeles qué recogiste, allí puedes encontrar algo...";
				break;

			case 7:
				conv = new string[]{
					"\"Los estudiantes serán sancionados sin atentar contra su dignidad\".",
					"\"los estudiantes serán sancionados en público si la falta atentó contra los valores de la institución\".",
					"\"Los estudiantes serán sancionados sin atentar contra sus derechos\".",
					"\"Los estudiantes serán sancionados frente a otros si la falta atentó contra el director\"."
				};
				boys = new string[]{"Antonio", "Josefa", "Camilo", "Andrea"};
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
		if (Input.GetMouseButtonDown (0)) 
		{
			if (!put && GameObject.FindWithTag("Talk") != null)
			{
				put = true;
				GameObject.FindGameObjectWithTag("Talk").gameObject.GetComponent<Talk>().Active(false);
				GameObject.FindGameObjectWithTag("Conversation").gameObject.GetComponent<Text>().text = "";
			}

			else if (!isTalking)
			{
				for (int i = 0, k = objects.Length; i <k; i++) 
				{
					if (objects [i].gameObject.GetComponent<OtherChar> ().ClickLimits (Input.mousePosition) && !GameObject.FindGameObjectWithTag("Left").gameObject.GetComponent<ButtonMv>().ClickLimits(Input.mousePosition) &&
					    !GameObject.FindGameObjectWithTag("Right").gameObject.GetComponent<ButtonMv>().ClickLimits(Input.mousePosition) && !GameObject.FindGameObjectWithTag("Up").gameObject.GetComponent<ButtonMv>().ClickLimits(Input.mousePosition) && 
					    !GameObject.FindGameObjectWithTag("A").gameObject.GetComponent<ButtonMv>().ClickLimits(Input.mousePosition) && !GameObject.FindGameObjectWithTag("B").gameObject.GetComponent<ButtonMv>().ClickLimits(Input.mousePosition))
						ConversationSeq(i);
				}
			}

			if (GameObject.FindWithTag("Dog") != null)
			{
				GameObject.FindGameObjectWithTag("Dog").gameObject.GetComponent<Ask>().Active(false);
				GameObject.FindGameObjectWithTag("Top").gameObject.GetComponent<Text>().text = "";
				if (GameObject.Find("Button(Clone)") == null)
				{
					ButtonQuest.put = true;
					PutMove();
				}
			}
		}

		if (Time.time > 1f && Time.time < 1f + Time.fixedDeltaTime)
			TopBall ("Mh.. el colegio también está extraño.. ¿que será esa cosa verde?");

		if (GeneralGameManager.advance == 5)
			GeneralGameManager.paper = true;

		if (line == 2 && GeneralGameManager.advance == 5) 
			GameObject.Find ("Camilo(Clone)").gameObject.transform.position = new Vector3 (0f, GameObject.Find ("Camilo(Clone)").gameObject.transform.position.y);

		if (GeneralGameManager.advance == 7 && ButtonQuest.put) 
		{
			GameObject.FindGameObjectWithTag("General").gameObject.GetComponent<GeneralGameManager>().PutQuestion();
			GameObject[] finish = GameObject.FindGameObjectsWithTag("Finish");
			for (int i = 0, k = finish.Length; i < k; i++)
			{
				if (finish[i].gameObject.transform.position.x >= 6.5f)
					finish[i].gameObject.transform.position = new Vector3(xMax + 0.25f, finish[i].gameObject.transform.position.y);
			}
		}

		if (GeneralGameManager.advance == 9)
		{ 
			GeneralGameManager.hammer = true;
			GeneralGameManager.key = true;
		}

		/*if (GeneralGameManager.advance == 10) 
		{
			GameObject.Find("Camilo(Clone)").gameObject.transform.position = new Vector2(48f, GameObject.Find("Camilo(Clone)").gameObject.transform.position.y);
			GameObject.Find("Josefa(Clone)").gameObject.transform.position = new Vector2(50f, GameObject.Find("Josefa(Clone)").gameObject.transform.position.y);
		}

		if (!isTalking && line == 6 && ButtonQuest.put) 
		{
			GameObject.FindGameObjectWithTag("General").gameObject.GetComponent<GeneralGameManager>().PutQuestion();
		}*/

		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();
	}
}
