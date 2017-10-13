using UnityEngine;
using System.Collections;

public class Objeto : MonoBehaviour {
    public string img,img2;
    public static bool cambio,cambio2;
    public Camera camera;
    public Material mat,mat1;
    public static bool cambia_tv, cambia_lampara, cambia_cuadro, cambia_ventana, cambia_reloj;

    void start()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(img);
        cambio = cambio2 = false;
        cambia_tv = false;
        cambia_lampara = false;
        cambia_cuadro  = false; 
        cambia_ventana = false;
        cambia_reloj = false;
    }
    void Update ()
    {
       
        Vector3 mouse = Input.mousePosition;
        if(Input.GetMouseButtonDown(0) && HizoClick(mouse) && Mensajes.conteo > 3)
        {
            if (cambio)
            {
                if (this.name == "tv")
                {
                    cambia_tv = true;
                    this.GetComponent<SpriteRenderer>().enabled = true;                    
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(img);
                    if (this.name == "Cuadro1" || this.name == "Cuadro2")
                    {
                        cambia_cuadro = true;
                    }
                    if (this.name == "Ventana")
                    {
                        cambia_ventana = true;
                    }
                }
            }
            else 
            { 
                if (this.name == "tv")
                {
                    cambia_tv = true;
                    this.GetComponent<SpriteRenderer>().enabled = false;
                }
                else GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(img2);
            }                      
            cambio = !cambio;

            if (this.name == "Lampara")
            {
                cambia_lampara = true;
                if (cambio)
                {
                    GameObject.FindGameObjectWithTag("Fondo").gameObject.GetComponent<SpriteRenderer>().material = mat;                    
                }
                else GameObject.FindGameObjectWithTag("Fondo").gameObject.GetComponent<SpriteRenderer>().material = mat1;
            }
        }

        if (this.name=="reloj" && HizoClick(mouse) && Mensajes.conteo > 3)
        {
            cambia_reloj = true;
            if (cambio2) { GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(img); }
            else { GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(img2); }
            cambio2 = !cambio2;            
        }
     }
    void OnTriggerEnter2D(Collider2D co)
    {
        PersoneroTut.sonwinTut.Play();        
    }

    bool HizoClick(Vector3 mouse)
    {
        if ((camera.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (camera.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (camera.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (camera.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
            return true;
        else
            return false;
    }

    void FixedUpdate()
    {        
        if ((cambia_tv == true) && (cambia_lampara == true) && (cambia_ventana == true))
        {
            Mensajes.conteo = 5;
            Mensajes.visible = true;
        }
    }
}
