using UnityEngine;
using System.Collections;

public class BombSkate : MonoBehaviour

{
    private float timeSkt, speedSkt;
    public static float TiroSkt;//Variable para la velocidad del disparo
    public GameObject BombaSkt; //Objeto que sirve de bala o disparo
    private Rigidbody2D R_BombaSkt;
    private Rigidbody2D rigidPlayerSkt;  //Variable para guardar el cuerpo del objeto player
    private string img_TiroSkt = "bomb2";

    // Use this for initialization
    void Start()
    {
        timeSkt = 0f;
        speedSkt = 0.15f;
        R_BombaSkt = BombaSkt.GetComponent<Rigidbody2D>();//Guarda las propiedades de objeto rígido de la bomba
        rigidPlayerSkt = GetComponent<Rigidbody2D>(); //Guarda las propiedades de objeto rígido del player
        BombSkate.TiroSkt = -20;
    }

    // Update is called once per frame
    void Update()
    {
        if (PuntajeSkate.global == 2) { speedSkt = 0.20f; }
        if (PuntajeSkate.global == 3) { speedSkt = 0.25f; }
        if (PuntajeSkate.global == 4) { speedSkt = 0.30f; }
        if (PuntajeSkate.global == 5) { speedSkt = 0.35f; }
        if (PuntajeSkate.global == 7) { speedSkt = 0.40f; }
        if (PuntajeSkate.global == 9) { Application.LoadLevel(13); }
    }

    void LateUpdate()
    {
        if (perroSkate.readySKT && LibrosSkate.starSKT == false)
        {
            timeSkt += Time.deltaTime;
            if (timeSkt < 0.01f && this.name == "bully01")
            {
                disparar();
            }
            if (timeSkt > 0.5f && timeSkt < 0.51f && this.name == "bully03")
            {
                disparar();
            }
            if (timeSkt > 0.20f && timeSkt < 0.21f && this.name == "bully02")
            {
                disparar();
            }
            if (timeSkt > 1.80f && timeSkt < 1.81f && this.name == "bully02")
            {
                disparar();
            }
            if (timeSkt > 1.10f && timeSkt < 1.11f && this.name == "bully03")
            {
                disparar();
            }
            if (PuntajeSkate.global > 6)
            {
                if (timeSkt > 0.10f && timeSkt < 0.11f) disparar();
                if (timeSkt > 0.30f && timeSkt < 0.31f) disparar();
                if (timeSkt > 0.50f && timeSkt < 0.51f) disparar();
                if (timeSkt > 0.70f && timeSkt < 0.71f) disparar();
                if (timeSkt > 0.90f && timeSkt < 0.91f) disparar();
                if (timeSkt > 1.10f && timeSkt < 1.11f) disparar();
                if (timeSkt > 1.30f && timeSkt < 1.31f) disparar();
                if (timeSkt > 1.50f && timeSkt < 1.51f) disparar();

            }
            if (PuntajeSkate.global > 8)
            {
                if (timeSkt > 1.10f && timeSkt < 1.11f) { disparar(); disparar(); }
                if (timeSkt > 1.30f && timeSkt < 1.31f) { disparar(); disparar(); }
                if (timeSkt > 1.50f && timeSkt < 1.51f) { disparar(); disparar(); disparar(); }
                if (timeSkt > 1.70f && timeSkt < 1.71f) { disparar(); disparar(); disparar(); }
                if (timeSkt > 1.90f && timeSkt < 1.91f) { disparar(); disparar(); }
                if (timeSkt > 2.10f && timeSkt < 2.11f) { disparar(); disparar(); }
                if (timeSkt > 2.30f && timeSkt < 2.31f) { disparar(); }
                if (timeSkt > 2.50f && timeSkt < 2.51f) { disparar(); }

            }

            if (timeSkt < 1f && !LibrosSkate.starSKT)
            {
                Vector2 mover = this.transform.position;
                mover.x += 20f;
                mover.y += 5f;
                Vector2 p = Vector2.MoveTowards(transform.position, mover, speedSkt);
                GetComponent<Rigidbody2D>().MovePosition(p);
            }
            else if (timeSkt < 2f && !LibrosSkate.starSKT)
            {
                Vector2 mover = this.transform.position;
                mover.x -= 20f;
                mover.y -= 5f;
                Vector2 p = Vector2.MoveTowards(transform.position, mover, speedSkt);
                GetComponent<Rigidbody2D>().MovePosition(p);
            }
            else
                timeSkt = 0f;
        }

    }

    void disparar()
    {
        Instantiate(BombaSkt, rigidPlayerSkt.position, Quaternion.identity);//crea el objeto
        BombaSkt.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(img_TiroSkt);//Le asocia una imagen
        R_BombaSkt.transform.Translate(new Vector2(0, -TiroSkt) * Time.deltaTime); //Dispara
        BombaSkt.transform.Translate(new Vector2(0, -TiroSkt) * Time.deltaTime);//Le agrega una fuerza
    }
}
