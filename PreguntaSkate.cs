using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PreguntaSkate : MonoBehaviour 
{
    public Camera camSkt;
    public Text AnswerS;
    private bool change;
    private int rtaSkt;
    public static int alNext;
    private string textoPBar, textoOp1, textoOp2, textoOp3, textoOp4;
    private float timeaux;
    
    Vector2 dest = Vector2.zero;

	// Use this for initialization
	void Start () 
    {
        rtaSkt = 0;
        alNext = 0;
        dest = new Vector2(-4.02f, -4.45f);                       

        textoPBar = "¿Qué amigo crees que tiene la razón?";
        textoOp1 = "El Líder local, porque se sabe que hay personas favorecidas por la posición de sus padres.";
        textoOp2 = "Andrea, porque si van a decirles que se salgan de la pista hay que traer más gente por si se surge un conflicto.";
        textoOp3 = "Chepe, porque si la policía que es la encargada de fomentar el orden no hace nada, ellos no deben involucrarse.";
        textoOp4 = "La hermana, porque ellos deben procurar que sus compañeros de barrio cumplan los acuerdos.";
        
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (salSKT.contSKT==1 && alNext == 0)
        {
            GameObject.Find("globNiño").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("TextNiño").gameObject.GetComponent<Text>().text = " ¿Qué hacen aquí? ¿No leyeron el aviso? Faltan 10 minutos para las 4pm! Tenemos que salir de aqui!";
            alNext = 2;
            salSKT.contSKT = 3;
        }


        Vector3 mouse = Input.mousePosition;
        if (Input.GetMouseButtonDown(0) )//Lee si se hizo click
        {            
            if(HizoClick(mouse) && this.name != "Bot_LeftBar" && this.name != "Bot_RightBar" && this.name != "Bot_UpBar")
            {
                Debug.Log(alNext+" "+change);
                if (alNext == 2 && change)
                {
                    GameObject.Find("globNiño").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("TextNiño").gameObject.GetComponent<Text>().text = "  ";
                    GameObject.Find("globCamilo").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("TextCamilo").gameObject.GetComponent<Text>().text = " Están incumpliendo la norma. ";
                    change = false;
                    alNext = 3;
                    
                }
    
                if (alNext == 3 && change)
                {
                    GameObject.Find("globCamilo").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("TextCamilo").gameObject.GetComponent<Text>().text = " ";
                    GameObject.Find("globHermana").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("TextHermana").gameObject.GetComponent<Text>().text = "Es Niki y el hermano. Digamosles que se tienen que ir. ";
                    change = false;
                    alNext = 4;
                    
                }
    
                if (alNext == 4 && change)
                {
                    GameObject.Find("globHermana").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("TextHermana").gameObject.GetComponent<Text>().text = " ";
                    GameObject.Find("globAdan").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("TextAdan").gameObject.GetComponent<Text>().text = " Niños, ya saben qué pasa con ellos en el barrio… ¡son hijos del Alcalde! Yo paso.. ";
                    change = false;
                    alNext = 5;
                    
                }
    
                if (alNext == 5 && change)
                {
                    GameObject.Find("globAdan").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("TextAdan").gameObject.GetComponent<Text>().text = "  ";
                    GameObject.Find("globNuevo").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("TextNuevo").gameObject.GetComponent<Text>().text = " Si la policía no los puede molestar mucho menos nosotros. ";
                    change = false;
                    alNext = 6;
                    
                }
                if ( alNext == 6 && change)
                {
                    
                    GameObject.Find("globNuevo").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("TextNuevo").gameObject.GetComponent<Text>().text = "  ";
                    GameObject.Find("globLaura").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("TextLaura").gameObject.GetComponent<Text>().text = " Además si nos arman problema nosotros somos menos... ";
                    change = false;
                    alNext = 61;
                    
                }
                if (alNext == 61 && change)
                {
                     dest.x -= 12;  
                     GameObject.Find("extra").GetComponent<Rigidbody2D>().MovePosition(dest);

                    change = false;
                    alNext = 7;
                }

                if (alNext == 7 && change && this.name != "Cuadro1B" && this.name != "Cuadro2B" && this.name != "Cuadro3B" && this.name != "Cuadro4B")
                {                    
                    
                    GameObject.Find("globPerroB").GetComponent<SpriteRenderer>().enabled = false;
                    AnswerS.gameObject.GetComponent<Text>().text = " ";
                    GameObject.Find("globLaura").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("TextLaura").gameObject.GetComponent<Text>().text = "  ";
                    change = false;
                    alNext = 8;
                    GameObject.Find("FondoBarrio").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("TextAskB").gameObject.GetComponent<Text>().text = textoPBar;
                    GameObject.Find("TextCB1").gameObject.GetComponent<Text>().text = textoOp1;
                    GameObject.Find("TextCB2").gameObject.GetComponent<Text>().text = textoOp2;
                    GameObject.Find("TextCB3").gameObject.GetComponent<Text>().text = textoOp3;
                    GameObject.Find("TextCB4").gameObject.GetComponent<Text>().text = textoOp4;
                    
                }

                if (alNext == 8 && change)
                {               
                    if (this.name == "Cuadro1B")
                    {
                        change = false;
                        rtaSkt = 1;
                        alNext = 81;
                         
                    }
                    if (this.name == "Cuadro2B")
                    {
                        change = false;
                        rtaSkt = 2;
                        alNext = 81;
                    }
                    if (this.name == "Cuadro3B")
                    {
                        change = false;
                        rtaSkt = 3;
                        alNext = 81;
                    }
                    if (this.name == "Cuadro4B")
                    {
                        change = false;
                        rtaSkt = 4;
                        alNext = 9;
                        salSKT.contSKT = 2;
                    }
                    GameObject.Find("FondoBarrio").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("TextAskB").gameObject.GetComponent<Text>().text = " ";
                    GameObject.Find("TextCB1").gameObject.GetComponent<Text>().text = " ";
                    GameObject.Find("TextCB2").gameObject.GetComponent<Text>().text = " ";
                    GameObject.Find("TextCB3").gameObject.GetComponent<Text>().text = " ";
                    GameObject.Find("TextCB4").gameObject.GetComponent<Text>().text = " ";
                }
    
                if (alNext == 81)
                {
                    GameObject.Find("globPerroB").GetComponent<SpriteRenderer>().enabled = true;
                    if (rtaSkt == 1)
                    {
                        change = false;
                        AnswerS.gameObject.GetComponent<Text>().text = " las normas deben cumplirlas todos los integrantes de una sociedad. ";                        
                        alNext = 7;
                    }
                    if (rtaSkt == 2)
                    {
                        change = false;
                        AnswerS.gameObject.GetComponent<Text>().text = " la manera en la que le exigimos el cumplimiento de las normas a nuestros semejantes debe ser pacífica.";
                        alNext = 7;
                    }
                    if (rtaSkt == 3)
                    {
                        change = false;
                        AnswerS.gameObject.GetComponent<Text>().text = " Aunque la policía y otros órganos estatales son los encargados de exigir el cumplimiento de normas, es una obligación que los ciudadanos exijan este cumplimiento entre ellos. ";                        
                        alNext = 7;
                    }
                    if (rtaSkt == 4)
                    {
                        change = false;
                        AnswerS.gameObject.GetComponent<Text>().text = "  ";
                        salSKT.contSKT = 2;
                    }
                }
                
            }    
        }
      if (Input.GetMouseButtonUp(0)) { change = true; }

	}

    bool HizoClick(Vector3 mouse)
    {
        if ((camSkt.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (camSkt.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (camSkt.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (camSkt.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
            return true;
        else
            return false;
    }


}
