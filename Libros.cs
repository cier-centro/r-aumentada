//Clase que controla la desaparición de los libros cuando les ase el player por encima
using UnityEngine;
using System.Collections;

public class Libros : MonoBehaviour
{
    public string sonido;
    private AudioSource source;
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>(); //Asocia un archivo de audio a una parametro para un objeto
        if (this.name == "Llave")
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        //Si el libro recibe la colisión de un objeto llamado pacman, desaparece el libro.
        if (co.name == "pacman" && GetComponent<SpriteRenderer>().enabled)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            this.transform.position = new Vector3(35.8f, 13.7f, 0f);
            sonar();

            if (this.name == "Llave")
            {
                Puntaje.scoreY += 1;
                ProfeMove2.speedprofe += 0.15f;
            }

            else
            {
                Puntaje.scoreP += 1;
                ProfeMove2.speedprofe += 0.05f;
            }
        }
    }

    void Update()
    {
        if (this.name == "Llave" && Puntaje.scoreP == 4 && Puntaje.scoreY == 0)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
                
        if (Puntaje.scoreP==0 && this.name != "Llave")
        { 
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        if (this.name == "Llave" && Puntaje.scoreY == 1)
        { 
            GetComponent<SpriteRenderer>().enabled = false;
            this.transform.position = new Vector3(35.8f, 13.7f, 0f);
        }
    }

    //Si se seleccionó activar sonido se le asocia el audio almacenado en el archivo cuyo nombre esta guardado en la variable sonido    
    void sonar()
    {

            source.clip = Resources.Load(sonido) as AudioClip;
            source.Play();

    }

}
