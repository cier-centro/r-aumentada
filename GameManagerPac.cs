using System.Collections.Generic;
using UnityEngine;

public class GameManagerPac : MonoBehaviour {

    public static int Level = 0;
    public static int lives = 3;
    public static bool reinicio = false;

	public enum GameState { Init, Game, Dead, Scores }
	public static GameState gameState;

    private GameObject pacman;
    private GameObject Profe4;
    private GameObject Profe2;
    private GameObject Profe3;
    private GameObject Profe1;
    public GameObject Vida1;
    public GameObject Vida2;
    public GameObject Vida3;


	public static bool scared;
    static public int score;

    public static AudioSource sonfon;
      
    private static GameManagerPac _instance;

    public static GameManagerPac instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManagerPac>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }


    void Awake()
    {
//#if UNITY_EDITOR
		//Application.LoadLevel(9);
//#endif
        if (_instance == null)
        {
            _instance = this;
           // DontDestroyOnLoad(this);
        }


        AssignGhosts();
    }

	void Start () 
	{

		gameState = GameState.Init;
        sonfon = gameObject.AddComponent<AudioSource>();
        sonfon.clip = Resources.Load("mjuego_pacman_01") as AudioClip;
        sonfon.Play();
        sonfon.loop = true;
    }

    void OnLevelWasLoaded()
    {
        if (Level == 0) lives = 3;

        AssignGhosts();
    }


	void FixedUpdate () 
	{

        if (perro.ready)
        {
            GameManagerPac.gameState = GameManagerPac.GameState.Game;
        }
        else
        {
            GameManagerPac.gameState = GameManagerPac.GameState.Dead;
            ResetScene();
            reinicio = true;
        }
        switch (lives)
        {
            case (0): { Vida1.GetComponent<SpriteRenderer>().enabled = false; } break;
            case (1): { Vida2.GetComponent<SpriteRenderer>().enabled = false; } break;
            case (2): { Vida3.GetComponent<SpriteRenderer>().enabled = false; } break;                  
        }

        if (lives == 0)
        {
            ProfeMove2.speedprofe = 0.3f;             
            Application.LoadLevel(10);
        }

        if (Puerta.fin)
        {
            //Application.Quit();
            sonfon.Stop();
        }
	}

	public void ResetScene()
	{

        gameState = GameState.Init;  
        reinicio = false;

	}

    void AssignGhosts()
    {

        Profe1 = GameObject.Find("Malo01");
        Profe2 = GameObject.Find("Malo02");
        Profe3 = GameObject.Find("Malo03");       
        pacman = GameObject.Find("pacman");
        
    }

    public void LoseLife()
    {
        lives--;
        gameState = GameState.Dead;
    }

}
