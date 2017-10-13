using UnityEngine;
using System.Collections;

public class PuertaTut : MonoBehaviour 
{
    public string backTut, winTut;
    public bool activ_sonidoTut;
    public static AudioSource sonfonTut, sonwinTut;

    public GameObject niño;

	// Use this for initialization
	void Start () 
    {
        GetComponent<SpriteRenderer>().enabled = true;
        sonfonTut = gameObject.AddComponent<AudioSource>(); //Asocia un archivo de audio a una parametro para un objeto
        sonwinTut = gameObject.AddComponent<AudioSource>();
        sonfonTut.clip = Resources.Load(backTut) as AudioClip;
        sonwinTut.clip = Resources.Load(winTut) as AudioClip;
        sonfonTut.Play();   
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Mensajes.conteo == 5 && this.name == "lock")
        {
            GetComponent<SpriteRenderer>().enabled = false;            
        }
	    
	}

    void OnTriggerEnter2D(Collider2D co)
    {
        //Si el libro recibe la colisión de un objeto llamado pacman, desaparece el libro.
        if (co.name == "Player" && Mensajes.conteo == 5)
        {
            Objeto.cambia_tv = false;
            Mensajes.conteo = 6;
            niño.transform.position = new Vector2(-158f, -10.8f);            
        }
        if (this.name == "salcasa" && co.name == "Player")
        {
            Application.LoadLevel(4);
        }
    }
}
