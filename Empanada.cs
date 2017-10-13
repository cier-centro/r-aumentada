using UnityEngine;
using System.Collections;

public class Empanada : MonoBehaviour {

	// Use this for initialization
    public string sonido;
    private AudioSource source;
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>(); //Asocia un archivo de audio a una parametro para un objeto
        GetComponent<SpriteRenderer>().enabled = true;
        sonido = "success";
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        //Si el libro recibe la colisión de un objeto llamado pacman, desaparece el libro.
        if (co.name == "Player" && GetComponent<SpriteRenderer>().enabled && Mensajes.conteo == 3)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            sonar();
            Mensajes.visible = true;
            Mensajes.conteo = 5;
        }
    }


    //Si se seleccionó activar sonido se le asocia el audio almacenado en el archivo cuyo nombre esta guardado en la variable sonido    
    void sonar()
    {
        source.clip = Resources.Load(sonido) as AudioClip;
        source.Play();
    }
}
