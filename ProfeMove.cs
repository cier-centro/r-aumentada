//Clase que controla el movimiento autónomo del Profesor.

using UnityEngine;
using System.Collections;

public class ProfeMove : MonoBehaviour
{
    public Transform[] waypoints;//Crea un vector con el número de puntos guía que se escojan externamente
    int cur = 0;

    public static float speed = 0.2f; //Se le asigna una velocidad que puede ser cambiada externamente

    void FixedUpdate()
    {
        if (!perro.ready)
        {

        }

        //Busca un punto de dirección si no lo encuentra se mueve cerca
        else if (transform.position != waypoints[cur].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
            Debug.Log("Punto: " + cur);
        }
        // Cuando encuentra el punto de ruta va al siguiente
        else
        {
            cur = (cur + 1) % waypoints.Length;
            Debug.Log("Punto: "+cur);
        }

        // Actualiza las variables de la animación
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);

    }
}