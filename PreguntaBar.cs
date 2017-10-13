using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PreguntaBar : MonoBehaviour 
{
    public Camera camPregBar;
    public static bool visBar;
    public static int rtaBar;
    public Text tp, t1, t2, t3, t4;
    public  GameObject globDogBar;
    public Text AnswerB;
    private string textoPBar, textoOp1, textoOp2, textoOp3, textoOp4;
    private bool algo;

	// Use this for initialization
	void Start () 
    {
        rtaBar = 0;
        visBar = algo = false;
        textoPBar = "¿Qué debes hacer ante esta situación?";
        textoOp1 = "Animar a la señora a protestar y así juntos podrán reclamarle al policía.";
        textoOp2 = "Atender el consejo del señor y juiciosamente seguir tu camino.";
        textoOp3 = "Animar a la señora protestar y armarse de una piedra para reclamarle al policía.";
        textoOp4 = "Atender el consejo de la niña y juiciosamente seguir tu camino.";

	}
	
	// Update is called once per frame
	void Update () 
    {
                        
        Vector3 mouse = Input.mousePosition;
        if (Input.GetMouseButtonDown(0) )//Lee si se hizo click
        {
            if ((HizoClick(mouse)) && DialogBar.ctrlDiagBar == 5 && this.name == "globPerroB")
            {
                AnswerB.gameObject.GetComponent<Text>().text = " ";
                DialogBar.ctrlDiagBar = 4;
                globDogBar.GetComponent<SpriteRenderer>().enabled = false;
            }
            if ( (HizoClick(mouse)) && (DialogBar.ctrlDiagBar == 4) && visBar)
            {
                globDogBar.GetComponent<SpriteRenderer>().enabled = false;
                if (this.name == "Cuadro1B")
                {
                    rtaBar = 1;
                    DialogBar.ctrlDiagBar = 6;
                    visBar = false;                   

                }
                if (this.name == "Cuadro2B")
                {
                    rtaBar = 2;
                    DialogBar.ctrlDiagBar = 5;
                    visBar = false;
                    algo = true;
                    
                }
                if (this.name == "Cuadro3B")
                {
                    rtaBar = 3;    
                    DialogBar.ctrlDiagBar = 5;
                    visBar = false;
                    algo = true;

                }
                if (this.name == "Cuadro4B")
                {
                    rtaBar = 4;
                    DialogBar.ctrlDiagBar = 5;
                    visBar = false;
                    algo = true;

                }
            } 
        }
	}

    bool HizoClick(Vector3 mouse)
    {
        if ((camPregBar.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (camPregBar.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (camPregBar.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (camPregBar.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
            return true;
        else
            return false;
    }

    void FixedUpdate()
    {
        
            if (visBar)
            {
				PreguntaBar.rtaBar = 1;
                this.GetComponent<SpriteRenderer>().enabled = true;
                tp.gameObject.GetComponent<Text>().text = textoPBar;
                t1.gameObject.GetComponent<Text>().text = textoOp1;
                t2.gameObject.GetComponent<Text>().text = textoOp2;
                t3.gameObject.GetComponent<Text>().text = textoOp3;
                t4.gameObject.GetComponent<Text>().text = textoOp4;
				
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = false;
                tp.gameObject.GetComponent<Text>().text = " ";
                t1.gameObject.GetComponent<Text>().text = " ";
                t2.gameObject.GetComponent<Text>().text = " ";
                t3.gameObject.GetComponent<Text>().text = " ";
                t4.gameObject.GetComponent<Text>().text = " ";
            }

        if (DialogBar.ctrlDiagBar == 5)
        {

            if (PreguntaBar.rtaBar == 1)
            {
                AnswerB.gameObject.GetComponent<Text>().text = " ";
                globDogBar.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (PreguntaBar.rtaBar == 2)
            {
                globDogBar.GetComponent<SpriteRenderer>().enabled = true;
                AnswerB.gameObject.GetComponent<Text>().text = " Recuerda que aunque las autoridades son las encargadas de mantener el orden, tú siempre puedes cuestionar sus acciones.  ";
            }
            if (PreguntaBar.rtaBar == 3)
            {
                globDogBar.GetComponent<SpriteRenderer>().enabled = true;
                AnswerB.gameObject.GetComponent<Text>().text = " Recuerda que aunque es legítimo que protestemos por acciones injustas debemos hacerlo pacíficamente. ";
            }
            if (PreguntaBar.rtaBar == 4)
            {
                globDogBar.GetComponent<SpriteRenderer>().enabled = true;
                AnswerB.gameObject.GetComponent<Text>().text = " Recuerda que como ciudadanos partícipes de nuestro entorno debemos defender nuestros derechos y los de los demás. ";
            }
        }
    }
}
