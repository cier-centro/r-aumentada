//Clase que controla el movimiento autónomo del Profesor.

using UnityEngine;
using System.Collections;

public class ProfeMoveBib : MonoBehaviour
{
    public Transform[] waypointsBib;//Crea un vector con el número de puntos guía que se escojan externamente
    int cur = 0;

    public static float speed = 0.4f; //Se le asigna una velocidad que puede ser cambiada externamente

    void FixedUpdate()
    {

        //Busca un punto de dirección si no lo encuentra se mueve cerca
        if (perroBib.readyBib && transform.position != waypointsBib[cur].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypointsBib[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Cuando encuentra el punto de ruta va al siguiente
        else
        {
            cur = (cur + 1) % waypointsBib.Length;
        }

        // Actualiza las variables de la animación
        Vector2 dir = waypointsBib[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);

    }
}