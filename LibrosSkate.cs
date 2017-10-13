//Clase que controla la desaparición de los libros cuando les ase el player por encima
using UnityEngine;
using System.Collections;

public class LibrosSkate : MonoBehaviour
{
    public string sonidoSKT;
    private AudioSource source;
    private int []PuntG1 = new int[9];
    private int[] PuntG2 = new int[5];
    private int[] PuntG3 = new int[6];
    private int[] PuntG4 = new int[4];
    private int[] PuntG5 = new int[3];
    private float time, speed, time_star;
    public static bool starSKT = false;


    void Start()
    {
        source = gameObject.AddComponent<AudioSource>(); //Asocia un archivo de audio a una parametro para un objeto
        PuntG1[1]=PuntG1[2]=PuntG1[3]=PuntG1[4]=PuntG1[5]=PuntG1[6]=PuntG1[7]=PuntG1[8]=0;
        PuntG2[1] = PuntG2[2] = PuntG2[3] = PuntG2[4] = 0;
        PuntG3[1] = PuntG3[2] = PuntG3[3] = PuntG3[4] =  PuntG3[5] = 0;
        PuntG4[1] = PuntG4[2] = PuntG4[3] = 0;
        PuntG5[1] = PuntG5[2] = 0;
        time = 0f;
        speed = 0.25f;
    }

    void OnTriggerEnter2D(Collider2D co)
    {

        if ((this.name == "Estrella" || this.name == "Estrella2") && co.name == "Player")
        {
            starSKT = true;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        if (co.name == "Bomba(Clone)" && GetComponent<SpriteRenderer>().enabled)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = true;
            switch (this.name)
            { 
                case "Grupo11":
                    {
                        PuntG1[1] += 1;
                        if (PuntG1[1] == 7)
                        {
                            GetComponent<SpriteRenderer>().enabled = false;
                            this.transform.position = new Vector3(35.8f, 13.7f, 0f);
                            PuntajeSkate.scoreG4 += 1;
                            sonar();
                        }
                    }
                    break;
                case "Grupo12":
                    {
                        PuntG1[2] += 1;
                        if (PuntG1[2] == 7)
                        {
                            GetComponent<SpriteRenderer>().enabled = false;
                            this.transform.position = new Vector3(35.8f, 13.7f, 0f);
                            PuntajeSkate.scoreG4 += 1;
                            sonar();
                        }
                    }
                    break;                

                case "Grupo21":
                    {
                        PuntG2[1] += 1;
                        if (PuntG2[1] == 6)
                        {
                            GetComponent<SpriteRenderer>().enabled = false;
                            this.transform.position = new Vector3(35.8f, 13.7f, 0f);
                            PuntajeSkate.scoreG3 += 1;
                            sonar();
                        }
                    }
                    break;
                case "Grupo22":
                    {
                        PuntG2[2] += 1;
                        if (PuntG2[2] == 6)
                        {
                            GetComponent<SpriteRenderer>().enabled = false;
                            this.transform.position = new Vector3(35.8f, 13.7f, 0f);
                            PuntajeSkate.scoreG3 += 1;
                            sonar();
                        }
                    }
                    break;
                

                case "Grupo31":
                    {
                        PuntG3[1] += 1;
                        if (PuntG3[1] == 5)
                        {
                            GetComponent<SpriteRenderer>().enabled = false;
                            this.transform.position = new Vector3(35.8f, 13.7f, 0f);
                            PuntajeSkate.scoreG2 += 1;
                            sonar();
                        }
                    }
                    break;

                case "Grupo32":
                    {
                        PuntG3[2] += 1;
                        if (PuntG3[2] == 5)
                        {
                            GetComponent<SpriteRenderer>().enabled = false;
                            this.transform.position = new Vector3(35.8f, 13.7f, 0f);
                            PuntajeSkate.scoreG2 += 1;
                            sonar();
                        }
                    }
                    break;
                

                case "Grupo41":
                    {
                        PuntG4[1] += 1;
                        if (PuntG4[1] == 4)
                        {
                            GetComponent<SpriteRenderer>().enabled = false;
                            this.transform.position = new Vector3(35.8f, 13.7f, 0f);
                            PuntajeSkate.scoreG1 += 1;
                            sonar();
                        }
                    }
                    break;
                case "Grupo42":
                    {
                        PuntG4[2] += 1;
                        if (PuntG4[2] == 4)
                        {
                            GetComponent<SpriteRenderer>().enabled = false;
                            this.transform.position = new Vector3(35.8f, 13.7f, 0f);
                            PuntajeSkate.scoreG1 += 1;
                            sonar();
                        }
                    }
                    break;
                case "Grupo43":
                    {
                        PuntG4[3] += 1;
                        if (PuntG4[3] == 4)
                        {
                            GetComponent<SpriteRenderer>().enabled = false;
                            this.transform.position = new Vector3(35.8f, 13.7f, 0f);
                            PuntajeSkate.scoreG1 += 1;
                            sonar();
                        }
                    }
                    break;

                case "Grupo51":
                    {
                        PuntG5[1] += 1;
                        if (PuntG5[1] == 9)
                        {
                            GetComponent<SpriteRenderer>().enabled = false;
                            this.transform.position = new Vector3(35.8f, 13.7f, 0f);
                            PuntajeSkate.scoreG5 += 1;
                            sonar();
                        }
                    }
                    break;
                
            }         
        }
    }


    //Si se seleccionó activar sonido se le asocia el audio almacenado en el archivo cuyo nombre esta guardado en la variable sonido    
    void sonar()
    {

            source.clip = Resources.Load(sonidoSKT) as AudioClip;
            source.Play();

    }

    void LateUpdate()
    {
        time += Time.deltaTime;  
        if (perroSkate.readySKT && time!=0f && this.name!="Estrella" && this.name!="Estrella2" && !LibrosSkate.starSKT)
        {
            if (time < 0.7f)
            {
                Vector2 mover = this.transform.position;
                if (this.name == "Grupo11" || this.name == "Grupo31" || this.name == "Grupo51")
                {
                    mover.x += 24f;
                    Vector2 p1 = Vector2.MoveTowards(transform.position, mover, speed);
                    GetComponent<Rigidbody2D>().MovePosition(p1);
                }
                else
                {
                    mover.x += 10f;
                    Vector2 p = Vector2.MoveTowards(transform.position, mover, speed);
                    GetComponent<Rigidbody2D>().MovePosition(p);                
                }
                
            }
            else if (time < 1.4f)
            {
                Vector2 mover = this.transform.position;
                if (this.name == "Grupo11" || this.name == "Grupo31" || this.name == "Grupo51")
                {
                    mover.x -= 40f;
                    Vector2 p1 = Vector2.MoveTowards(transform.position, mover, speed);
                    GetComponent<Rigidbody2D>().MovePosition(p1);
                }
                else                 
                {
                    mover.x -= 70f;
                    Vector2 p = Vector2.MoveTowards(transform.position, mover, speed);
                    GetComponent<Rigidbody2D>().MovePosition(p);
                }
                
            }
            else
                time = 0f;

       }
    }

    void FixedUpdate()
    {
        PuntajeSkate.global = PuntajeSkate.scoreG1 + PuntajeSkate.scoreG2 + PuntajeSkate.scoreG3 + PuntajeSkate.scoreG4 + PuntajeSkate.scoreG5;

        if (starSKT)
        {
            time_star += Time.deltaTime;
            if (time_star < 3f)
            {
                speed = 0f;
                BombSkate.TiroSkt = -1;
            }
            else
            {
                starSKT = false;
                BombSkate.TiroSkt = -20;
                speed = 0.15f;
                time_star = 0f;
            }

        }
        else
        {
            if (PuntajeSkate.global == 5) { speed = 0.20f; }
            if (PuntajeSkate.global == 6) { speed = 0.25f; BombSkate.TiroSkt = -30; }
            if (PuntajeSkate.global == 7) { speed = 0.30f; }
            if (PuntajeSkate.global == 8) { speed = 0.35f; BombSkate.TiroSkt = -40; }
            if (PuntajeSkate.global == 9) { speed = 0.45f; BombSkate.TiroSkt = -50; }
            if (PuntajeSkate.global == 10) Application.LoadLevel(13);
        }
    }
}
