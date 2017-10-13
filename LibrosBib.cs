//Clase que controla la desaparición de los libros cuando les ase el player por encima
using UnityEngine;
using System.Collections;

public class LibrosBib : MonoBehaviour
{
    public string sonidoBib;
    public bool activ_sonidoBib;
    private AudioSource source;
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>(); //Asocia un archivo de audio a una parametro para un objeto
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        //Si el libro recibe la colisión de un objeto llamado Player, desaparese el libro.
        if (co.name == "PlayerBib")
        {
            if (GetComponent<SpriteRenderer>().enabled) PuntajeBib.scoreBib += 1;
            GetComponent<SpriteRenderer>().enabled = false;
            sonar();
            this.transform.position = new Vector3(95.8f, 13.7f, 0f);
            ProfeMoveBib.speed += 0.1f;
        }
    }

    void Update()
    {
        if (PuntajeBib.scoreBib==0) GetComponent<SpriteRenderer>().enabled = true;
    }

    //Si se seleccionó activar sonido se le asocia el audio almacenado en el archivo cuyo nombre esta guardado en la variable sonido    
    void sonar()
    {
        if (activ_sonidoBib)
        {
            source.clip = Resources.Load(sonidoBib) as AudioClip;
            source.Play();
        }
    }

}
