using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hermana : MonoBehaviour 
{
    public Camera cameraHer;
    public static int conteoH;
    public GameObject globoH, PuertaHermana;
    public Text TexHermana;
    private bool visibleH;
    private string actual;
    private bool esperando;

    void start() 
    {
        conteoH= 0;
        visibleH = true;
        actual = "!!!!! ";
        esperando = true;
    }
	
	// Update is called once per frame
	void Update () 
    {       
       switch (conteoH)
       {
           
           case 1: {
                      actual = "!!!!!";
                    } 
           break;
           case 2:
                    {
                        actual = " ¿Que qué pasa? ";
                    }
           break;                  
           case 3:
           {
               actual = "El problema es que hoy me prometieron ir al parque de diversiones,";
           }
           break;
           
           case 4:
           {
               actual = "pero mi hermano tiene que ir al banco y además quiere comprar unos audífonos, y mi mamá quiere arreglarse el cabello…";
           }
           break;
           
           case 5:
           {
               actual = "Ya no me van a llevar a nada...";
               Mensajes.visible = false;
               Mensajes.conteo = 8;
           }
           break;
           
           case 6:
           {
               visibleH = true;
               actual = "¡Bien Jugador! Es una buena idea. Le contaré a mamá.";
               GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hermanita");
                }
           break;
       }
	}

    void FixedUpdate() 
    {
        Vector3 mouse = Input.mousePosition;
        if (Input.GetMouseButtonDown(0) && (HizoClick(mouse)))//Lee si se hizo click
        {
            esperando = true;
            if (conteoH == 0 && esperando)
            {
                conteoH = 1;
                esperando = false;                
            }
            if (conteoH == 1 && esperando)
            {
                if (!visibleH) visibleH = true;
                conteoH = 2;
                esperando = false;
            }

            if (conteoH == 2 && esperando)
            {
                conteoH = 3;
                esperando = false;
            }

            if (conteoH == 3 && esperando)
            {
                conteoH = 4;
                esperando = false;
            }

            if (conteoH == 4 && esperando)
            {
                conteoH = 5;
                Mensajes.conteo = 7;
                esperando = false;
            }

            if (conteoH == 5 && esperando)
            {
                conteoH = 1;
                esperando = false;
                visibleH = false;
            }
        }

        if (visibleH)
        {
            globoH.GetComponent<SpriteRenderer>().enabled = true;
            TexHermana.gameObject.GetComponent<Text>().text = actual;
        }
        else 
        {
            globoH.GetComponent<SpriteRenderer>().enabled = false;
            TexHermana.gameObject.GetComponent<Text>().text = "";
        }
    }


    bool HizoClick(Vector3 mouse)
    {
        if ((cameraHer.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (cameraHer.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (cameraHer.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (cameraHer.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
            return true;
        else
            return false;
    }

}
