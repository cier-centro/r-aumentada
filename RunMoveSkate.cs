//Clase Principal que controla el movimiento del Player.
using UnityEngine;
using System.Collections;

public class RunMoveSkate : MonoBehaviour
{
    
    public static string dirSKT;
    public float speed = 0.2f; //VARIABLE PARA CONTROLAR LA VELOCIDAD DEL PERSONAJE
    public static Vector2 dir2SKT; 
    Vector2 dest = Vector2.zero;//INICIALIZA LA VARIABLE DE FUTURA POSICIÓN
    public float Vel_Tiro;//Variable para la velocidad del disparo
    public GameObject Bomba; //Objeto que sirve de bala o disparo
    private Rigidbody2D R_Bomba;
    private Rigidbody2D rigidPlayer;  //Variable para guardar el cuerpo del objeto player
    private string img_Tiro = "libro";
    public static bool disparoSKT,saltoSKT;
    private AudioSource dispara;
    public GameObject vida1, vida2, vida3;
    public static int vidasSKT;

    void Start()
    {
        dest = transform.position;//LE ASIGNA A LA POSICIÓN FUTURA EL MOVIMIENTO GENERADO POR LAS TECLAS
        R_Bomba = Bomba.GetComponent<Rigidbody2D>();//Guarda las propiedades de objeto rígido de la bomba
        rigidPlayer = GetComponent<Rigidbody2D>(); //Guarda las propiedades de objeto rígido del player
        disparoSKT = false;
        dispara = gameObject.AddComponent<AudioSource>();
        dispara.clip = Resources.Load("disparo") as AudioClip;
        vida1.GetComponent<SpriteRenderer>().enabled = true;
        vida2.GetComponent<SpriteRenderer>().enabled = true;
        vida3.GetComponent<SpriteRenderer>().enabled = true;
        vidasSKT = 3;
    }
    
    void FixedUpdate()
    {
        
        if (perroSkate.readySKT)
        {
            //SE ASIGNA EN UN VECTOR EL RESULTADO DEL MOVIMIENTO A UNA DIRECCIÓN CON CIERTA VELOCIDAD
            Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);//AL OBJETO ASOCIADO A ESTE SCRIPT SE LE ASIGNA EL PROCESO DE MOVER LA POSICIÓN

            //De acuerdo con la tecla oprimida se asigna una dirección al Objeto
            if (BotonSkate.dispSKT && !disparoSKT)
            {
                disparar();
                disparoSKT = true;
                GetComponent<Animator>().SetTrigger("DispSkt");
                
            }

            if (BotonSkate.rightSKT && valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
                RunMoveSkate.dirSKT = "derecha";
                GetComponent<Animator>().SetTrigger("Quieto");
            }
            if (BotonSkate.leftSKT && valid(-Vector2.right))
            {
                dest = (Vector2)transform.position - Vector2.right;
                RunMoveSkate.dirSKT = "izquierda";
                GetComponent<Animator>().SetTrigger("Quieto");
            }
            if (BotonSkate.upSKT && valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
                RunMoveSkate.dirSKT = "arriba";
                GetComponent<Animator>().SetTrigger("Quieto");
            }
            if (BotonSkate.downSKT && valid(-Vector2.up))
            {
                dest = (Vector2)transform.position - Vector2.up;
                RunMoveSkate.dirSKT = "abajo";
                GetComponent<Animator>().SetTrigger("Quieto");
            }
            if (BotonSkate.jumpSKT && valid(-Vector2.up))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 0.3f));
                GetComponent<Animator>().SetTrigger("SaltarSkt");
            }
            

            //Se actualizan los valores de DirX y DirY que controlan las animaciones del personaje
            Vector2 dir = dest - (Vector2)transform.position;
            dir2SKT.x = dir.x;
            dir2SKT.y = dir.y;
        }
        else 
        {
            dir2SKT.x = 0f;
            dir2SKT.y = 0f;
            this.transform.position = new Vector3(111f, -50f, 0f);
            GetComponent<Animator>().SetTrigger("Quieto");

        }
    }

    bool valid(Vector2 dir)
    {
        //Detecta que la posición a la que quiere moverse no esté obstaculizada por un collider
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }

    void disparar()
    {
            Instantiate(Bomba, rigidPlayer.position, Quaternion.identity);//crea el objeto
            Bomba.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(img_Tiro);//Le asocia una imagen
            R_Bomba.transform.Translate(new Vector2(0, Vel_Tiro) * Time.deltaTime); //Dispara
            Bomba.transform.Translate(new Vector2(0, Vel_Tiro) * Time.deltaTime);//Le agrega una fuerza
            dispara.Play();
    }

    void Update()
    {
        switch (RunMoveSkate.vidasSKT)
        {
            case 0: 
                {
                    vida1.GetComponent<SpriteRenderer>().enabled = false;
                    vida2.GetComponent<SpriteRenderer>().enabled = false;
                    vida3.GetComponent<SpriteRenderer>().enabled = false;
                } break;
            
            case 1:
                {
                    vida1.GetComponent<SpriteRenderer>().enabled = true;
                    vida2.GetComponent<SpriteRenderer>().enabled = false;
                    vida3.GetComponent<SpriteRenderer>().enabled = false;
                } break;
            case 2:
                {
                    vida1.GetComponent<SpriteRenderer>().enabled = true;
                    vida2.GetComponent<SpriteRenderer>().enabled = true;
                    vida3.GetComponent<SpriteRenderer>().enabled = false;
                } break;
            case 3:
                {
                    vida1.GetComponent<SpriteRenderer>().enabled = true;
                    vida2.GetComponent<SpriteRenderer>().enabled = true;
                    vida3.GetComponent<SpriteRenderer>().enabled = true;
                } break;
        }
    }
    
}