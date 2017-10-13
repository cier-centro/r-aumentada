using UnityEngine;
using System.Collections;

public class PuertaBib : MonoBehaviour {
    public Sprite img,img2;
    public static bool fin;

    void start()
    {
        GetComponent<SpriteRenderer>().sprite = img;
        fin = false;
    }
    void Update ()
    {
        if (PuntajeBib.scoreBib >= 5)
        {
            GetComponent<SpriteRenderer>().sprite = img2;
            PuntajeBib.Txt2Bib = "Ve a la puerta!!";
        }
        if (PersoneroBib.pilladoBib) { GetComponent<SpriteRenderer>().sprite = img2; }  
     }
    void OnTriggerEnter2D(Collider2D co)
    {
        //Si la puerta recibe la colisión de un objeto llamado Player, termina.
        if (PuntajeBib.scoreBib >= 5)
        {
            PersoneroBib.sonwin.Play();
            PersoneroBib.sonfon.Pause();
            PuntajeBib.Txt2Bib = "Bien Hecho!";
            fin = true;
            Application.LoadLevel(5);
        }
        else if(co.name=="PlayerBib")
        {
            PuntajeBib.Txt2Bib  = "Aún no has recogido \n todas las pistas!";
        }
    }


}
