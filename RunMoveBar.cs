//Clase Principal que controla el movimiento del Player.
using UnityEngine;
using System.Collections;

public class RunMoveBar : MonoBehaviour
{
    
    private float speed; //VARIABLE PARA CONTROLAR LA VELOCIDAD DEL PERSONAJE
    private float distancia;
    public static string dir;
    Vector2 dest = Vector2.zero;//INICIALIZA LA VARIABLE DE FUTURA POSICIÓN
    public static AudioSource sonjump;

    void Start()
    {
        dest = transform.position;//LE ASIGNA A LA POSICIÓN FUTURA EL MOVIMIENTO GENERADO POR LAS TECLAS
        speed = 8f;
    }
    
    void FixedUpdate()
    {

        if (BotonBar.upBar && PiesBar.pies_pisoBar && !DialogBar.Fade)
            {
                GetComponent<Animator>().SetTrigger("MoveU");
                dest = (Vector2)transform.position + Vector2.up;
                saltar();
                PiesBar.pies_pisoBar = false;
                sonjump = gameObject.AddComponent<AudioSource>();
                sonjump.clip = Resources.Load("salto") as AudioClip;
                sonjump.Play();
                RunMoveBar.dir = "arriba";
                Vector2 dir = dest - (Vector2)transform.position;                
            }
        else if (BotonBar.rightBar && !DialogBar.Fade)
            {
                GetComponent<Animator>().SetTrigger("MoveR");
                dest = (Vector2)transform.position + Vector2.right;
                speed = Mathf.Abs(speed);
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
                 RunMoveBar.dir = "derecha";
                 Vector2 dir = dest - (Vector2)transform.position;                
            }

        else if (BotonBar.leftBar && !DialogBar.Fade)
            {
                GetComponent<Animator>().SetTrigger("MoveL");
                dest = (Vector2)transform.position - Vector2.right;
                speed = -Mathf.Abs(speed);
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
                RunMoveBar.dir = "izquierda";
                Vector2 dir = dest - (Vector2)transform.position;                
            }
            else
            {
                if (PiesBar.pies_pisoBar)
                    Detenerse(); 
            }            
    }

    bool valid(Vector2 dir)
    {
        //Detecta que la posición a la que quiere moverse no esté obstaculizada por un collider
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }

    public void Detenerse()
    {
        GetComponent<Animator>().SetTrigger("Stop");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, GetComponent<Rigidbody2D>().velocity.y);
        
    }

    public void saltar()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 600f));
        BotonBar.upBar = false;
    }

}