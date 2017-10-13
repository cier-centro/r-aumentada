using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pregunta : MonoBehaviour 
{
    public Camera camPreg;
    public static bool  vis;
    public string doorgirl;
    public static bool rta;
    private string textoP;
    public GameObject niñoP;

	// Use this for initialization
	void Start () 
    {       
        rta = false;
        vis = false;
        textoP = "¿Cuál de los siguientes lugares de la ciudad escogerías para cumplir con los intereses de todos los familiares?";
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 mouse = Input.mousePosition;
        if (Input.GetMouseButtonDown(0) && (HizoClick(mouse)) && (Mensajes.conteo == 8))//Lee si se hizo click
        {
            vis = false;          
            if (this.name == "cuadro3Ask")
            {
                rta = true;
                Hermana.conteoH = 6;
                Mensajes.conteo = 9;                
            }
            
        }
	}

    bool HizoClick(Vector3 mouse)
    {
        if ((camPreg.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (camPreg.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (camPreg.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (camPreg.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
            return true;
        else
            return false;
    }

    void FixedUpdate()
    {
        if (this.name == "cuadro1Ask" || this.name == "cuadro2Ask" || this.name == "cuadro3Ask" || this.name == "FondoBlanco" || this.name == "globo Pregunta")
            {
                if(vis) GetComponent<SpriteRenderer>().enabled = true;
                else GetComponent<SpriteRenderer>().enabled = false;
            }

            if (this.name == "TextAsk")
            {
                if (vis) this.gameObject.GetComponent<Text>().text = textoP;
                else this.gameObject.GetComponent<Text>().text =" ";
            }

            if (this.name == "puertaniña")
            {
                if (rta)
                {
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(doorgirl);
                    Vector3 mouse = Input.mousePosition;
                    if (Input.GetMouseButtonDown(0) && (HizoClick(mouse)))//Lee si se hizo click
                    {
                        niñoP.transform.position = new Vector2(-116f, -10.8f); 
                    }
                }
            }

        
    }
}
