using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {

	public static int score;
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
	private int line;
	private string[] conv;
	private string[] boys;
	private GameObject[] objects;
	private bool isTalking;
	private bool dirTalk = true;

	// Use this for initialization


	IEnumerator Conversation(string[] P, string [] text, bool direction)
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
		PutMove();
		UIErase (false);
		isTalking = false;
	}

	void TopBall(string textTop)
	{
		RemoveButtons ();
		askAsker = askChar.GetComponent<Ask>();
		askAsker.Image = "globo 02";
		askAsker.Put ();
		globoSound.Play ();
		StartCoroutine (GameObject.Find ("Ask(Clone)").gameObject.GetComponent<Ask> ().Anim (2f, textTop));
		isTalking = true;
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
				bnd.PosX = bg.ImageSize.x * bg.Size / 2 + 0.25f;
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

//	public void PutEnter()
//	{
//		btn = button.GetComponent<Button> ();
//		btn.Image = "lock";
//		btn.Size = 1f;
//		btn.StrName = "Enter";
//		btn.Put();
//	}
//	
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
		string[] names = {"Girl", "Boy", "Camilo", "Nicky", "Nicky2", "Nicky3"};
		string[] assets = {"chica-1", "chico-2", "chico-2", "bravucon-bully", "bravucon-1", "bravucon-2"};
		float[] positions = {-32f, -30f, 7f, 10f, 12f, 14f};
		other = otherCharac.GetComponent<OtherChar> ();

		for (int i = 0, k = names.Length; i < k; i++) 
		{
			other.name = names[i];
			other.Size = 0.8f;
			other.Image = assets[i];
			other.PosX = positions[i];
			other.PosY = -2.6f;
			other.Put();
		}
	}

	void PutBonus(float min, float max)
	{
		bns = bonus.GetComponent<Bonus> ();
		bns.Image = "empanada";
		bns.Size = 1f;

		for (int i = 0; i < 4; i++) 
		{
			bns.PosX = Random.Range (min, max);
			bns.PosY = Random.Range (0f, Camera.main.ScreenToWorldPoint (new Vector3 (0f, Camera.main.pixelHeight, 0f)).y - bns.ImageSize.y / 2f - 1f);
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
		score = 0;
		line = 0;
		Load ();
		history = new string[]{"Girl", "Camilo"};
		objects = GameObject.FindGameObjectsWithTag("Other");
		globoSound = gameObject.AddComponent<AudioSource> ();
		globoSound.clip = Resources.Load ("aparece_globo") as AudioClip;
	}

	public void RemoveButtons()
	{
		if (GameObject.FindWithTag ("Left") != null) 
		{
			//UIErase(true);
			GameObject.FindGameObjectWithTag ("Left").gameObject.GetComponent<ButtonMv> ().Active (false);
			GameObject.FindGameObjectWithTag ("Right").gameObject.GetComponent<ButtonMv> ().Active (false);
			GameObject.FindGameObjectWithTag ("Up").gameObject.GetComponent<ButtonMv> ().Active (false);
			GameObject.FindGameObjectWithTag("A").gameObject.GetComponent<ButtonMv> ().Active (false);
			GameObject.FindGameObjectWithTag("B").gameObject.GetComponent<ButtonMv> ().Active (false);
			//else
				//GameObject.FindGameObjectWithTag ("Enter").gameObject.GetComponent<Button> ().Active (false);
		}
	}

	void UIErase(bool erase)
	{
		if (erase) 
		{
			GameObject.Find ("ButtonBag").gameObject.GetComponent<Button> ().interactable = false;
			GameObject.Find ("Food").gameObject.GetComponent<Image>().enabled = false;
			GameObject.Find ("ButtonHome").gameObject.GetComponent<Button> ().interactable = false;
			GameObject.FindGameObjectWithTag("Score").gameObject.GetComponent<Text>().text = "";
		} 
		else 
		{
			GameObject.Find ("ButtonBag").gameObject.GetComponent<Button> ().interactable = true;
			GameObject.Find ("Food").gameObject.GetComponent<Image> ().enabled = true;
			GameObject.Find ("ButtonHome").gameObject.GetComponent<Button> ().interactable = true;
			GameObject.FindGameObjectWithTag("Score").gameObject.GetComponent<Text>().text = score.ToString();
		}
	}

	void ConversationSeq (int i)
	{
		if (GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position.x <= objects [i].gameObject.transform.position.x)
			dirTalk = true;
		else
			dirTalk = false;
		if (objects [i].gameObject.name == history [line] + "(Clone)") 
		{
			RemoveButtons();
			switch (line)
			{
			case 0:
				conv = new string[]{
					"No digas nada pero me dijeron que hay un lugar custodiado y escondido en el colegio, repleto de libros.", 
					"El personero se supone puede sancionar a los profesores en caso de abuso, pero no hace nada.",
					"Oh mira, un folder me sobra ¿lo quieres?"
				};
				boys = new string[]{"Girl", "Boy", "Boy", "Girl", "Girl"};
				break;
				
			case 1:
				conv = new string[]{
					"Últimamente profesores que tratan mal a sus estudiantes aparecen amarrados dentro de los salones.",
					"Esto debe ser obra del encapuchado. Nunca nadie lo ha visto.",
					"Já, Niño, con verte una vez por día me sobra. Si te vuelvo a ver…"
				};
				boys = new string[]{"Camilo", "Camilo", "Nicky"};
				break;
				
			default:
				conv = new string[]{
					"¡No quiero hablar ahora!"
				};
				boys = new string[]{objects [i].gameObject.name.Substring(0, objects[i].gameObject.name.Length -7)};
				break;
			}
			if (line < history.Length -1)
				line++;
			StartCoroutine (Conversation (boys, conv, dirTalk));
		} 
		else 
		{
			RemoveButtons();
			string [] conv = {"¡No tengo nada que decirte! Mejor busca a " + history [line]};
			string [] boys = {objects [i].gameObject.name.Substring(0, objects[i].gameObject.name.Length -7)};
			StartCoroutine (Conversation (boys, conv, dirTalk));
		}
	}

	void FixedUpdate () 
	{
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

			else if (isTalking)
			{
				GameObject.FindGameObjectWithTag("Dog").gameObject.GetComponent<Ask>().Active(false);
				GameObject.FindGameObjectWithTag("Top").gameObject.GetComponent<Text>().text = "";
				PutMove();
				UIErase(false);
				isTalking = false;
			}
		}

		if (Time.time > 1f && Time.time < 1f + Time.fixedDeltaTime)
			TopBall ("!Bien, llegaste al colegio¡ Encuentra a Camilo antes de las clases");

		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();
	}
}
