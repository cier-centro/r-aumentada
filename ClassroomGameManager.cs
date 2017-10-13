using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ClassroomGameManager : MonoBehaviour {
	
	public string scenarioName;
	public GameObject player;
	public GameObject background;
	public GameObject floor;
	public GameObject button;
	public GameObject balloon;
	public GameObject otherCharac;
	public GameObject askChar;
	public GameObject feedBack;
	public GameObject item;
	
	public static float xMax;
	public static float xMin;
	
	private Talk bln;
	private Ask askAsker;
	private Background bg;
	private Columns clm;
	private Floor fl;
	private Floor bnd;
	private Player ply;
	private OtherChar other;
	private ButtonMv btn;
	private Real fb;
	private Items itm;
	
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
	private float time;
	private float time2;
	private int advanceCR = 0;
	
	void PutBackground()
	{
		bg = background.GetComponent<Background> ();
		bg.Image = "salon de clases (interior)";
		bg.PosX = 0;
		bg.PosY = 0;
		bg.Size = 0.225f;
		bg.Put ();
	}
	
	void PutFloor()
	{
		fl = floor.GetComponent<Floor> ();
		fl.Width = bg.ImageSize.x + 1f;
		fl.Height = 0.5f;
		fl.PosX = bg.PosX;
		fl.PosY = -5f;
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
				bnd.PosX = -bg.ImageSize.x / 2 - 0.25f;
			else
				bnd.PosX = bg.ImageSize.x / 2 + 0.25f;
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
		string[] names = {"Maria", "Camilo", "Nicky", "Ronaldo", "Felipe"};
		string[] assets = {
			"chica-2", //0
			"Camilo", //1
			"bravucon-bully-mosntruo", //2
			"bravucon-1-monstruo", //3
			"bravucon-2-mosntruo",
		};
		float[] positionsX = {-3f, -1f, 1.5f, 3.5f, 5.5f};
		//float[] positionsY = {-2.9f, -2.9f, -2.9f, -2.9f, -2.9f};
		other = otherCharac.GetComponent<OtherChar> ();
		
		for (int i = 0, k = names.Length; i < k; i++) 
		{
			other.name = names[i];
			if (i == 1)
				other.Size = 0.8f;
			else
				other.Size = 0.5f;
			other.Image = assets[i];
			other.PosX = positionsX[i];
			//other.PosY = positionsY[i];
			other.PosY = -2.9f;
			other.Solid = false;
			other.Put();
		}
	}
	
	void PutItems()
	{
		string[] images = {
			"Control_Blanco_IZQ",
			"Control_Blanco_DER"
		};
		string[] names = {
			"Control_Blanco_IZQ",
			"Control_Blanco_DER"
		};
		float[] positionX = {0f, 0f};
		float[] positionY = {0f, 0f};
		int[] lay = {8, 8};
		bool[] visible = {true, true};
		float[] sizes = {1f, 1f};
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
			itm.Put();
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
		history = new string[] {
			"Maria",
			"Profesor",
			"Maria"
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
			advanceCR++;
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
		StartCoroutine (GameObject.Find ("FeedBack(Clone)").gameObject.GetComponent<Real> ().Anim (4f, textFB));
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
					"¡Es el profesor de español¡ ¡Le cerraron la puerta en la cara¡",
					"Vamos a molestar al profesor hasta que se vaya del colegio y deje de molestarnos."
				};
				boys = new string[]{"Maria", "Ronaldo"};
				plus = true;
				break;
				
			case 1:
				conv = new string[]{
					"Engendros demoníacos! Buenos para nada! Tienen 0 TODOS!",
					"Uy, se fritó el profesor",
					"No hay que negar que maneja bien el español",
					"Uch Parecía loco. ¿Es entendible que el profesor haya reaccionado de esta manera?"
				};
				boys = new string[]{"Profesor", "Felipe", "Camilo", "Maria"};
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
		time += Time.deltaTime;
		time2 += Time.deltaTime;
		Debug.Log (GeneralGameManager.advance);
		Debug.Log (advanceCR);
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
			StartCoroutine (TopBall ("¡Ahora vamos a clase!"));

		if (GeneralGameManager.advance == 18 && advanceCR == 1 && ButtonQuest.put & time2 >= 0.3f & time2 <= 0.3f + Time.deltaTime)
			GameObject.FindGameObjectWithTag ("General").gameObject.GetComponent<GeneralGameManager> ().PutQuestion ();

		if (GeneralGameManager.advance == 19) 
		{
			if (GameObject.Find("Profesor(Clone)") == null)
				PutNew("Profesor", "profesor1", true, -5.5f, -2.9f, 0.8f);

			if (advanceCR == 2 && ButtonQuest.put & time2 >= 0.3f & time2 <= 0.3f + Time.deltaTime)
				GameObject.FindGameObjectWithTag ("General").gameObject.GetComponent<GeneralGameManager> ().PutQuestion ();
		}

		if (GeneralGameManager.advance == 20 && ButtonQuest.put & time2 >= 0.3f & time2 <= 0.3f + Time.deltaTime)
			Application.LoadLevel (13);

		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();
	}
}