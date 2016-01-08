using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager_City : MonoBehaviour {
	
	public static int score;
	public string scenarioName;
	public GameObject bonus;
	public GameObject player;
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
	private Floor fl;
	private Floor bnd;
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
	
	public static bool paper;
	public static bool hammer;
	public static bool gun;
	public static bool key;
	public static int advance;
	public static int preg;
	
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
				bnd.PosX = bg.ImageSize.x * bg.Size / 2 + 0.25f;;
			bnd.PosY = 0f;
			bnd.Rotation = 0f;
			bnd.PutFloor();
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
		ply.PosX = -bg.ImageSize.x * bg.Size / 2 + 2f;
		ply.PosY = fl.PosY + fl.Height / 2 + ply.ImageSize.y / 2f;
		ply.Put ();
	}
	
	void PutCharacters()
	{
		string[] names = {"Josefa", "Camilo", "Nicky", "Nicky2", "Nicky3", "Profesor"};
		string[] assets = {"chica-1", "chico-2", "bravucon-bully-mosntruo", "bravucon-1-monstruo", "bravucon-2-mosntruo", "profesor2"};
		float[] positions = {-20f, -18f, -11f, -8f, -6f, 20f};
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
	
	void Load()
	{
		QuestionDisable ();
		PutBackground ();
		xMin = bg.PosX - bg.ImageSize.x / 2f;
		xMax = bg.PosX + bg.ImageSize.x / 2f;
		PutBounds ();
		PutFloor ();
		PutMove ();
		PutPlayer ();
		PutCharacters ();
		PutBonus (xMin, xMax);
		PutSound ();
	}
	
	void Awake () 
	{
		paper = false;
		hammer = false;
		gun = false;
		key = false;
		preg = 1;
		advance = 0;
		score = 0;
		line = 0;
		Load ();
		history = new string[]{"Josefa", "Camilo", "Profesor"};
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
	
	public void QuestionDisable()
	{
		string[] buttonsD = {"OpcA", "OpcB", "OpcC", "OpcD"};
		GameObject.Find ("Out").gameObject.GetComponent<Inventory> ().Appear (false);
		GameObject.Find ("TextQuestion").gameObject.GetComponent<Text> ().text = "";
		
		for (int i = 0; i < 4; i++) 
		{
			GameObject.Find (buttonsD[i]).gameObject.GetComponent<Button> ().interactable = false;
			GameObject.Find ("Text" + buttonsD[i]).gameObject.GetComponent<Text> ().text = "";
		}
	}
	
	public void PutQuestion()
	{
		string[] sentence = new string[]{"", "", "", ""};
		switch (GeneralGameManager.preg) 
		{
		case 1:
			sentence = new string[]{
				"Coordinador monstruo: De acuerdo con las normas del gobierno escolar ¿es correcta la sanción que impongo al estudiante?",
				"Sí, pues debo corregir los estudiantes más problemáticos.",
				"No, pues debo procurar el bienestar de todos los estudiantes.",
				"Sí, pues debo dar ejemplo a los demás estudiantes.",
				"No, pues debo respetar los deseos de todos los estudiantes."
			};
			break;
		default:
			sentence = new string[]{
				"Coooooooordinador monstruo: colar ¿es correcta la sanción que impongo al estudiante?",
				"pues debo corregir los estudiantes más problemáticos.",
				" debo procurar el bienestar de todos los estudiantes.",
				"r ejemplo a los demás estudiantes.",
				"No, pues debo respeos los estudiantes."
			};
			break;
		}
		string[] buttonsD = {"OpcA", "OpcB", "OpcC", "OpcD"};
		GameObject.Find ("Out").gameObject.GetComponent<Inventory> ().Appear (true);
		GameObject.Find ("TextQuestion").gameObject.GetComponent<Text> ().text = sentence[0];
		
		for (int i = 1, k = sentence.Length ; i < k; i++) 
		{
			GameObject.Find (buttonsD[i-1]).gameObject.GetComponent<Button> ().interactable = true;
			GameObject.Find ("Text" + buttonsD[i-1]).gameObject.GetComponent<Text> ().text = sentence[i];
		}
	}
	
	IEnumerator Conversation(string[] P, string [] text, bool direction, string top)
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
		PutMove();
		UIErase (false);
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
					"No digas nada pero me dijeron que hay un lugar custodiado y escondido en el colegio, repleto de libros.", 
					"El personero se supone puede sancionar a los profesores en caso de abuso, pero no hace nada.",
					"Oh mira, un folder me sobra ¿lo quieres?"
				};
				boys = new string[]{"Josefa", "Camilo", "Camilo"};
				top = "¡Se ha guardado el folder en tu maleta!";
				break;
				
			case 1:
				conv = new string[]{
					"Últimamente profesores que tratan mal a sus estudiantes aparecen amarrados dentro de los salones.",
					"Esto debe ser obra del encapuchado. Nunca nadie lo ha visto.",
					"Já, Niño, con verte una vez por día me sobra. Si te vuelvo a ver…"
				};
				boys = new string[]{"Camilo", "Camilo", "Nicky"};
				break;
				
			case 2:
				conv = new string[]{
					"¿QUÉ SIGUEN HACIENDO AQUÍ NIÑOS?",
					"¡VAYAN A HACER LA FORMACIÓN YA!",
					"El profesor ¿no? Cada vez se pasan más tratándonos mal.",
					"No hay nada que diga que lo que hace es incorrecto.",
					"Ojalá el Encapuchado haga algo.",
					"Mejor vamos a formar."
				};
				boys = new string[]{"Profesor", "Profesor", "Camilo", "Camilo", "Camilo", "Camilo"};
				top = "Oprime la flecha de arriba cuando estes frente al patio para ir a formar.";
				advance++;
				break;
				
			default:
				conv = new string[]{
					"¡No quiero hablar ahora!"
				};
				boys = new string[]{objects [i].gameObject.name.Substring(0, objects[i].gameObject.name.Length -7)};
				break;
			}
			StartCoroutine (Conversation (boys, conv, dirTalk, top));
			if (line < history.Length -1)
				line++;
		} 
		else 
		{
			string [] conv = {"¡No tengo nada que decirte! Mejor busca a " + history [line]};
			string [] boys = {objects [i].gameObject.name.Substring(0, objects[i].gameObject.name.Length -7)};
			StartCoroutine (Conversation (boys, conv, dirTalk, top));
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
					{
						if (line == 2 && objects[i].name == "Profesor(Clone)")
							StartCoroutine(GameObject.Find("Camilo(Clone)").gameObject.GetComponent<OtherChar>().Move(Camera.main.transform.position.x - 1.5f));
						ConversationSeq(i);
					}
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
					UIErase(false);
				}
			}
		}
		
		if (line == 1)
			paper = true;
		
		if (advance == 2 && ButtonQuest.put) 
		{
			PutQuestion();
			GameObject[] finish = GameObject.FindGameObjectsWithTag("Finish");
			for (int i = 0, k = finish.Length; i < k; i++)
			{
				if (finish[i].gameObject.transform.position.x >= 15f)
				{
					finish[i].gameObject.transform.position = new Vector3(xMax + 0.25f, finish[i].gameObject.transform.position.y);
				}
			}
		}
		
		if (Time.time > 1f && Time.time < 1f + Time.fixedDeltaTime)
			TopBall ("!Bien, llegaste al colegio¡ Encuentra a Camilo antes de las clases");
		
		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();
	}
}
