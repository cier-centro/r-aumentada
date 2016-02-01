using UnityEngine;
using System.Collections;

public class Puerta : MonoBehaviour {
    public string sp;
    public static bool fin;
    private AudioSource audio;
    
   void start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pclose");
        fin = false;       
    }


   void OnTriggerEnter2D(Collider2D co)
   {
       //Si la puerta recibe la colisión de un objeto llamado Player, termina.
       if (co.name == "pacman" && Puntaje.scoreP == 4 && Puntaje.scoreY == 1)
       {           
           Application.LoadLevel(4);
       }
   }

    
    void Update ()
    {
        if (Puntaje.scoreP == 4 && Puntaje.scoreY==1)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("popen");
            
        }
        //if (GameManagerPac.reinicio) { GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pclose"); }  
     }
    

    void sonp()
    {
        audio.clip = Resources.Load("mjuego_ganar") as AudioClip;
        audio.Play();
    }

}
