//Clase que controla el movimiento autónomo del Profesor.

using UnityEngine;
using System.Collections;

public class ProfeMove2 : MonoBehaviour
{    
    public Transform[] wayprofe;//Crea un vector con el número de puntos guía que se escojan externamente
    Vector2 pr1 = new Vector2(90f, -10f);
    Vector2 pr2 = new Vector2(100f, -30f);
    Vector2 pr3 = new Vector2(100f, -30f);
    int cur = 0;
    public GameObject Perseguido;  

    public static float speedprofe = 0.3f; //Se le asigna una velocidad que puede ser cambiada externamente

    void start()
    {
        speedprofe = 0.3f;
    }
    
    void FixedUpdate()
    {
        if (perro.ready)
        {
            //Busca un punto de dirección si no lo encuentra se mueve cerca
            if (transform.position != wayprofe[cur].position)
            {
                Vector2 p = Vector2.MoveTowards(transform.position, wayprofe[cur].position, speedprofe);
                GetComponent<Rigidbody2D>().MovePosition(p);
            }
            // Cuando encuentra el punto de ruta va al siguiente
            else
            {
                cur = (cur + 1) % wayprofe.Length;
            }

            // Actualiza las variables de la animación
            Vector2 dir = wayprofe[cur].position - transform.position;
            GetComponent<Animator>().SetFloat("DirX", dir.x);
            GetComponent<Animator>().SetFloat("DirY", dir.y);
        }
        else 
        {
            transform.position = wayprofe[0].position;  
        }


    }
    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        {
            perro.ready = false;
            if (this.name == "Malo01") transform.position = pr1;
            if (this.name == "Malo02") transform.position = pr2;
            if (this.name == "Malo03") transform.position = pr3;
        }

    }

    


    //void Update()
    //{
        //if (perro.ready)
        //{
            //if (Vector2.Distance(Perseguido.transform.position, transform.position) <1)
            //{
                //Vector2 p = Vector2.MoveTowards(transform.position, Perseguido.transform.position, speedprofe);
                //GetComponent<Rigidbody2D>().MovePosition(p);
            //}

            //else if (transform.position != wayprofe[cur].position)
            //{
                //Vector2 p = Vector2.MoveTowards(transform.position, wayprofe[cur].position, speedprofe);
                //GetComponent<Rigidbody2D>().MovePosition(p);
            //}
            // Cuando encuentra el punto de ruta va al siguiente
//            else cur = (cur + 1) % wayprofe.Length ;

            // Actualiza las variables de la animación
//            Vector2 dir = wayprofe[cur].position - transform.position;
            //GetComponent<Animator>().SetFloat("DirX", dir.x);
            //GetComponent<Animator>().SetFloat("DirY", dir.y);
      //  }
   // }

}