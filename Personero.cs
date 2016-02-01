using UnityEngine;
using System.Collections;

public class Personero : MonoBehaviour {

    public float x= -24;
    public float y= 17;
    public static bool pillado=false;
    public string son,back,win;
    public bool activ_sonido;
    public static AudioSource src,sonfon,sonwin;
    public GameObject vida1, vida2, vida3, vida4;
    private int contvidas;
    private AudioSource sonvida;

    void Start ()
    {
        sonfon = gameObject.AddComponent<AudioSource>(); //Asocia un archivo de audio a una parametro para un objeto
        sonfon.clip = Resources.Load(back) as AudioClip; sonfon.Play();
        sonwin = gameObject.AddComponent<AudioSource>(); //Asocia un archivo de audio a una parametro para un objeto
        sonwin.clip = Resources.Load(win) as AudioClip;
        sonvida = gameObject.AddComponent<AudioSource>();
        sonvida.clip = Resources.Load("lose") as AudioClip; 
        x = this.gameObject.transform.position.x;
        y = this.gameObject.transform.position.y;
        src = gameObject.AddComponent<AudioSource>(); //Asocia un archivo de audio a una parametro para un objeto
        contvidas = 0;
    }


    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "Profe1" || co.name == "Profe2" || co.name == "Profe3")
        {
            perro.ready = false;
            sonar();
            pillado = true;
            transform.position = new Vector2(x, y);
            Application.LoadLevel(0);
        }

        if (co.name == "ProfeLight" || co.name == "ProfeLight2" || co.name == "ProfeLight3")
        {
            sonvida.Play();
            if (contvidas <= 4)
            {
                contvidas += 1;
            }
            else 
            {
                Application.LoadLevel(0); 
            }           
        }
    }

    //Si se seleccionó activar sonido se le asocia el audio almacenado en el archivo cuyo nombre esta guardado en la variable sonido    
    void sonar()
    {
        sonfon.Pause();
        if (activ_sonido) src.clip = Resources.Load(son) as AudioClip; src.Play();
        
    }

    void FixedUpdate()
    {
        switch (contvidas)
        {
            case (0): 
                { 
                    vida1.GetComponent<SpriteRenderer>().enabled = false;
                    vida2.GetComponent<SpriteRenderer>().enabled = false;
                    vida3.GetComponent<SpriteRenderer>().enabled = false;
                    vida4.GetComponent<SpriteRenderer>().enabled = false;
                } break;
            case (1):
                {
                    vida1.GetComponent<SpriteRenderer>().enabled = true;
                } break;
            case (2):
                {
                    vida2.GetComponent<SpriteRenderer>().enabled = true;
                } break;
            case (3):
                {
                    vida3.GetComponent<SpriteRenderer>().enabled = true;
                } break;
            case (4):
                {
                    vida4.GetComponent<SpriteRenderer>().enabled = true;
                } break;
        }
    }

  }
