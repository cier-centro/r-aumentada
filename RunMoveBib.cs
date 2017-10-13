//Clase Principal que controla el movimiento del Player.
using UnityEngine;
using System.Collections;

public class RunMoveBib : MonoBehaviour
{
    
    public static string dirBib;
    public float speed = 0.2f; //VARIABLE PARA CONTROLAR LA VELOCIDAD DEL PERSONAJE
    public static Vector2 dir2Bib; 
    Vector2 dest = Vector2.zero;//INICIALIZA LA VARIABLE DE FUTURA POSICIÓN

    void Start()
    {
        dest = transform.position;//LE ASIGNA A LA POSICIÓN FUTURA EL MOVIMIENTO GENERADO POR LAS TECLAS
    }
    
    void FixedUpdate()
    {

        if (perroBib.readyBib && !PersoneroBib.pilladoBib)
        {
            //SE ASIGNA EN UN VECTOR EL RESULTADO DEL MOVIMIENTO A UNA DIRECCIÓN CON CIERTA VELOCIDAD
            Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);//AL OBJETO ASOCIADO A ESTE SCRIPT SE LE ASIGNA EL PROCESO DE MOVER LA POSICIÓN

            //De acuerdo con la tecla oprimida se asigna una dirección al Objeto
            if (BotonBiB.upBib && valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
                RunMoveBib.dirBib = "arriba";
            }
            if (BotonBiB.rightBib && valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
                RunMoveBib.dirBib = "derecha";
            }
            if (BotonBiB.downBib && valid(-Vector2.up))
            {
                dest = (Vector2)transform.position - Vector2.up;
                RunMoveBib.dirBib = "abajo";
            }
            if (BotonBiB.leftBib && valid(-Vector2.right))
            {
                dest = (Vector2)transform.position - Vector2.right;
                RunMoveBib.dirBib = "izquierda";
            }

            //Se actualizan los valores de DirX y DirY que controlan las animaciones del personaje
            Vector2 dir = dest - (Vector2)transform.position;
            GetComponent<Animator>().SetFloat("DirX", dir.x);
            GetComponent<Animator>().SetFloat("DirY", dir.y);
            dir2Bib.x = dir.x;
            dir2Bib.y = dir.y;
        }
        else 
        {
            dest = new Vector2 (-23.75f, 12.49f);
            dir2Bib.x = 0;
            dir2Bib.y = 0;
        }
    }

    bool valid(Vector2 dir)
    {
        //Detecta que la posición a la que quiere moverse no esté obstaculizada por un collider
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}