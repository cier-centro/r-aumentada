//Clase Principal que controla el movimiento del Player.
using UnityEngine;
using System.Collections;

public class RunMoveTut : MonoBehaviour
{
    
    public static string dir;
    public float speed; //VARIABLE PARA CONTROLAR LA VELOCIDAD DEL PERSONAJE
    public float distancia;
    Vector2 dest = Vector2.zero;//INICIALIZA LA VARIABLE DE FUTURA POSICIÓN
    public static AudioSource sonjump;

    void Start()
    {
        dest = transform.position;//LE ASIGNA A LA POSICIÓN FUTURA EL MOVIMIENTO GENERADO POR LAS TECLAS
        speed = 10f;
    }
    
    void FixedUpdate()
    {

        if (globoBib.ready)
        {
            //De acuerdo con la tecla oprimida se asigna una dirección al Objeto
            if (BotonTut.upTut && Pies.pies_piso)
            {
                GetComponent<Animator>().SetTrigger("MoveU");
                dest = (Vector2)transform.position + Vector2.up;
                saltar();
                Pies.pies_piso = false;
                sonjump = gameObject.AddComponent<AudioSource>();
                sonjump.clip = Resources.Load("salto") as AudioClip;
                sonjump.Play();
                RunMoveTut.dir = "arriba";
                Vector2 dir = dest - (Vector2)transform.position;                
            }
            else if (BotonTut.rightTut)
            {
				if (Pies.pies_piso) {
					GetComponent<Animator> ().SetTrigger ("MoveR");
				}
                dest = (Vector2)transform.position + Vector2.right;
                speed = Mathf.Abs(speed);
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
                 RunMoveTut.dir = "derecha";
                 Vector2 dir = dest - (Vector2)transform.position;                
            }

            else if (BotonTut.leftTut)
            {
				if (Pies.pies_piso) {
					GetComponent<Animator> ().SetTrigger ("MoveL");
				}
                dest = (Vector2)transform.position - Vector2.right;
                speed = -Mathf.Abs(speed);
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
                RunMoveTut.dir = "izquierda";
                Vector2 dir = dest - (Vector2)transform.position;                
            }
            else
            {
                if(Pies.pies_piso)
                    Detenerse(); 
            }            
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
        BotonTut.upTut = false;
    }

}