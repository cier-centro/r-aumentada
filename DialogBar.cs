using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogBar : MonoBehaviour {

    public Camera camBar;
    public static int ctrlDiagBar;
    public static bool Fade;
    public GameObject policiaBar, policiaBar2;
    public static AudioSource sontrueno;
    public static AudioSource sonfonBar;
    public Text TexVo, TexVa, TexP1, TexP2, TexNa, TexPlay;
    private float timeFade = 0;
    private string veca,  veco, pol1, pol2, nina, comodin, persText, vacio;
    private bool cambio;
    bool convaV, convoV, connaV, conp1V, conp2V, connV;
    

	void Start () 
    {
        ctrlDiagBar = 0;
        sontrueno = gameObject.AddComponent<AudioSource>();
        sontrueno.clip = Resources.Load("trueno") as AudioClip;
        sonfonBar = gameObject.AddComponent<AudioSource>(); //Asocia un archivo de audio a una parametro para un objeto
        sonfonBar.clip = Resources.Load("introjuego") as AudioClip; sonfonBar.Play();
        convaV = convoV = connaV = conp1V = conp2V = connV = false;
        cambio = false;
        comodin = "Por Ahora no tengo más que decir";
        vacio = veco = veca = pol1 = pol2 = nina = persText = " ";
        
        
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (ctrlDiagBar == 1)
        {
            GameObject.Find("globNiño").GetComponent<SpriteRenderer>().enabled = true;
            persText = "¿¿Qué pasó?? ¡Parece que las personas que están realizando acciones injustas están cambiando de forma! ";
            TexPlay.gameObject.GetComponent<Text>().text = persText;
            ctrlDiagBar = 2;
            cambio = false;
        }

        if (ctrlDiagBar == 7)
        {
            GameObject.Find("globPol1").GetComponent<SpriteRenderer>().enabled = true;
            pol1 = "¿Ah? Que qué hacemos? ¿No ves? ¡Hacer cumplir la ley!.Somos los únicos autorizados a establecer el orden en toda la ciudad. !No importa de qué manera ¡Ahora, ¡Quítense!";
            TexP2.gameObject.GetComponent<Text>().text = pol1;
            ctrlDiagBar = 8;
            cambio = false;
        }

        Vector3 mouse = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))//Lee si se hizo click
        {
            Debug.Log(ctrlDiagBar);
            if (HizoClick(mouse) && !Fade && this.name != "Bot_LeftBar" && this.name != "Bot_RightBar" && this.name != "Bot_UpBar")
            {
                                               
                if (ctrlDiagBar == 2 && cambio)
                {
                    if (this.name == "PlayerBarrio")
                    {
                        GameObject.Find("globNiño").GetComponent<SpriteRenderer>().enabled = false;
                        TexPlay.gameObject.GetComponent<Text>().text = " ";
                        GameObject.Find("globVecinoB").GetComponent<SpriteRenderer>().enabled = true;
                        veco = "el niño rompió el vidrio de la casa de un vecino con una piedra y por ello, los policías lo castigan de forma violenta";
                        TexVo.gameObject.GetComponent<Text>().text = veco;
                        ctrlDiagBar = 3;
                        cambio = false;
                    }
                }
                if (ctrlDiagBar == 3 && cambio)
                {
                        ctrlDiagBar = 33;
                        veco = "Ante la policía no se puede hacer nada, son la autoridad";
                        TexVo.gameObject.GetComponent<Text>().text = veco;
                        cambio = false;
                }
                if (ctrlDiagBar == 33 && cambio)
                {
                        GameObject.Find("globVecinoB").GetComponent<SpriteRenderer>().enabled = false;
                        ctrlDiagBar = 3;
                        TexVo.gameObject.GetComponent<Text>().text = " ";
                        GameObject.Find("globVecinaB").GetComponent<SpriteRenderer>().enabled = true;
                        veca = "Pobre chico... desacató la ley pero no deberían ser tan fuertes con él ¿No crees?";
                        TexVa.gameObject.GetComponent<Text>().text = veca;
                        ctrlDiagBar = 4;
                        cambio = false;
                }
                if (ctrlDiagBar == 4 && cambio)
                {
                    if (this.name == "vecina")
                    {
                        GameObject.Find("globVecinaB").GetComponent<SpriteRenderer>().enabled = false;
                        GameObject.Find("globNina").GetComponent<SpriteRenderer>().enabled = true;
                        TexVa.gameObject.GetComponent<Text>().text = " ";
                        nina = "Protestar es ser peleonero y está mal ¿Sabías? No busques problemas.";
                        TexNa.gameObject.GetComponent<Text>().text = nina;
                        ctrlDiagBar = 50;
                        cambio = false;
                    }
                }
                if (ctrlDiagBar == 50 && cambio)
                {
                    if (this.name == "Niña" || this.name == "PlayerBarrio")
                    {
                        GameObject.Find("globNina").GetComponent<SpriteRenderer>().enabled = false;
                        TexNa.gameObject.GetComponent<Text>().text = " ";
                        GameObject.Find("globNiño").GetComponent<SpriteRenderer>().enabled = true;
                        persText = "¡Ey! ¿Qué debes hacer ante esta situación?";
                        TexPlay.gameObject.GetComponent<Text>().text = persText;
                        ctrlDiagBar = 51;
                        cambio = false;
                    }
                }
                if (ctrlDiagBar == 51 && cambio)
                {
                    if (this.name == "PlayerBarrio")
                    {
                        GameObject.Find("globNiño").GetComponent<SpriteRenderer>().enabled = false;
                        TexPlay.gameObject.GetComponent<Text>().text = " ";
                        ctrlDiagBar = 5;
                        cambio = false;
                    }
                }
                if (ctrlDiagBar == 5)
                {

                    PreguntaBar.visBar = true;
                }
                
                if (ctrlDiagBar == 8 && cambio)
                {
                    if (this.name == "pol1")
                    {
                        GameObject.Find("globPol1").GetComponent<SpriteRenderer>().enabled = false;                        
                        TexP2.gameObject.GetComponent<Text>().text = " ";
                        GameObject.Find("globPol2").GetComponent<SpriteRenderer>().enabled = true;
                        pol2 = ".. ¿Si este niño y esta señora tienen razón?";
                        TexP1.gameObject.GetComponent<Text>().text = pol2;
                        ctrlDiagBar = 9;
                        cambio = false;
                    }
                }
                if (ctrlDiagBar == 9 && cambio)
                {
                    if (this.name == "pol2")
                    {
                        GameObject.Find("globPol2").GetComponent<SpriteRenderer>().enabled = false;
                        TexP1.gameObject.GetComponent<Text>().text = " ";
                        GameObject.Find("globPol1").GetComponent<SpriteRenderer>().enabled = true;
                        pol1 = "¿Qué haz hecho niño?......Esto no se quedará así ¡Vas a pagarlas!";
                        TexP2.gameObject.GetComponent<Text>().text = pol1;
                        ctrlDiagBar = 91;
                        cambio = false;
                    }
                }
                if (ctrlDiagBar == 91 && cambio)
                {
                    if (this.name == "pol1")
                    {
                        GameObject.Find("globPol1").GetComponent<SpriteRenderer>().enabled = false;
                        TexP2.gameObject.GetComponent<Text>().text = " ";
                        GameObject.Find("globVecinaB").GetComponent<SpriteRenderer>().enabled = true;
                        veca = "¿Cómo haz hecho eso Niño ?";
                        TexVa.gameObject.GetComponent<Text>().text = veca;
                        ctrlDiagBar = 92;
                        cambio = false;
                    }
                }

                if (ctrlDiagBar == 92 && cambio)
                {
                    if (this.name == "vecina")
                    {
                        GameObject.Find("globVecinaB").GetComponent<SpriteRenderer>().enabled = false;
                        TexVa.gameObject.GetComponent<Text>().text = " ";
                        GameObject.Find("globNiño").GetComponent<SpriteRenderer>().enabled = true;
                        persText = "Ni idea, algo extraño pasa aquí...";
                        TexPlay.gameObject.GetComponent<Text>().text = persText;
                        ctrlDiagBar = 93;
                        cambio = false;
                    }
                }

                if (ctrlDiagBar == 93 && cambio)
                {
                    if (this.name == "PlayerBarrio")
                    {
                        GameObject.Find("globNiño").GetComponent<SpriteRenderer>().enabled = false;
                        TexPlay.gameObject.GetComponent<Text>().text = " ";
                        ctrlDiagBar = 94;
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0)) { cambio = true; }
	}



    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "PlayerBarrio" && ctrlDiagBar==0 )
        {
            ctrlDiagBar = 11;
            Fade = true;
            timeFade = 0f;
            sontrueno.Play();
        }
    }

    void LateUpdate()
    {
        timeFade += Time.deltaTime;
                    
            if (ctrlDiagBar == 11 && timeFade < 0.2f)
            {
                sontrueno.Play();
                policiaBar.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola2");
                policiaBar2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("polb2");

            }
            if (ctrlDiagBar == 11 && timeFade > 0.2f)
            {
                policiaBar.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola3");
                policiaBar2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("polb3");
            }

            if (ctrlDiagBar == 11 && timeFade > 0.4f && timeFade < 0.6f)
            {
                policiaBar.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola2");
                policiaBar2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("polb2");
            }
            if (ctrlDiagBar == 11 && timeFade > 0.6f && timeFade < 0.8f)
            {
                policiaBar.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola3");
                policiaBar2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("polb3");                
            }
            if (ctrlDiagBar == 11 && timeFade > 0.8f && timeFade < 1.0f)
            {
                policiaBar.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola2");
                policiaBar2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("polb2");
            }
            if (ctrlDiagBar == 11 && timeFade > 1.2f && timeFade < 1.4f)
            {
                policiaBar.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola3");
                policiaBar2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("polb3");
            }
            if (ctrlDiagBar == 11 && timeFade > 1.4f && timeFade < 1.6f)
            {
                policiaBar.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola2");
                policiaBar2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("polb2");
            }
            if (ctrlDiagBar == 11 && timeFade > 1.6f && timeFade < 1.8f)
            {
                policiaBar.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola3");
                policiaBar2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("polb3");
                
            }
            if (ctrlDiagBar == 11 && timeFade > 1.8f && timeFade < 2.0f)
            {
                policiaBar.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola1");
                policiaBar2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("polb1");
            }
            if (ctrlDiagBar == 11 && timeFade > 2.0f && timeFade < 2.2f)
            {
                policiaBar.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola3");
                policiaBar2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("polb3");
                ctrlDiagBar = 1;
                Fade = false;
        }




    }

    bool HizoClick(Vector3 mouse)
    {
        if ((camBar.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (camBar.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (camBar.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (camBar.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
            return true;
        else
            return false;
    }


}
