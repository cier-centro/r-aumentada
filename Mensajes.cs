using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mensajes : MonoBehaviour 
{
    public static int conteo;
    public GameObject globo;
    public static bool visible;
    private string actual;

    void start() 
    {
        conteo = 1;
        visible = true;
        actual = "¡Jugador despertaste! \n Está muy oscuro acá, intenta prender la luz.(TOCA EL SWITCH). ";
    }
	
	// Update is called once per frame
	void Update () 
    {       
       if (Oscuro.luz_pared && conteo==0)
       {   
           conteo = 11;
           Mensajes.visible = true;
       }
       switch (conteo)
       {
           
           case 0: {
               actual = "¡Jugador despertaste!\n Está muy oscuro acá, intenta prender la luz.(TOCA EL SWITCH).";
                    } 
           break;
           case 1:
                    {
                        actual = "Ya sabes prender la Luz Ahora intenta moverte Utiliza las flechas para moverte a la izquierda y a la derecha ";
                    }
           break;
           
           case 11:
           {
               actual = "Oh, bien, no veía nada.";
           }
           break;
           
           case 12:
           {
               actual = " ¿¿Ah?? ¿Puedes escucharme? Eso es raro, algo debió pasar contigo mientras dormías. ";
           }
           break;

           case 13:
           {
               actual = " Lo descubriremos. Levántate y salgamos de aquí. ";
           }
           break;

           case 2:
           {
               actual = "Bien Hecho! Ya sabes moverte \n Ahora intenta saltar\nUtiliza la flecha de arriba";
           }
           break;
           
           case 3:
           {
               actual = "Bien Hecho! Ya saltas \n Ahora intenta comer una empanada\n(Salta y coje la empanada)";
           }
           break;
           
           case 4:
           {
               actual = "Bien Hecho! Ya sabes moverte e interactuar con el escenario... Explora un poco, cuando acabes ve a la puerta";
           }
           break;
           
           case 5:
           {
               actual = "Bien Hecho! Ya sabes moverte e interactuar con el escenario... Explora un poco, cuando acabes ve a la puerta";
           }
           break;
           case 6:
           {
               actual = " Debes comunicarte con tu hermana. ¡Escucha lo que dice!";
           }
           break;
           case 7:
           {
               actual = " ¡Escucha lo que dice tu hermana! y explora un poco el cuarto";
           }
           break;
           case 8:
           {
               actual = " ¡!";
           }
           break;
           case 9:
           {
               actual = " Muy bien! No hay más que ver aquí. Vamos a la escuela!";
           }
           break;
       }
	}

    void FixedUpdate() 
    {
        if (visible)
        {
            globo.GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.GetComponent<Text>().text = actual;
        }
        else if (conteo!=0)
        {
            globo.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<Text>().text = "";
        }
    }
}
