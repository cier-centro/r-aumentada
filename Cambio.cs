using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cambio : MonoBehaviour {

    public Sprite imagen, imagen2, imagen3, imagen4;
    public Text girltxt, msg;
    public static int num = 2;
    public static bool sigue = true;

    // Use this for initialization
    void Start ()
    {
        this.GetComponent<SpriteRenderer>().sprite = imagen;
        GameObject.FindGameObjectWithTag("globgirl").GetComponent<SpriteRenderer>().enabled = false;
        girltxt.gameObject.GetComponent<Text>().text = " ";
    }
	
	// Update is called once per frame

    void FixedUpdate()
    {
        switch (num) 
        {

            case 1: 
                {
                    this.GetComponent<SpriteRenderer>().sprite = imagen2;
                    GameObject.FindGameObjectWithTag("globgirl").GetComponent<SpriteRenderer>().enabled = true;
                    girltxt.gameObject.GetComponent<Text>().text = "Me duele la cabeza... vuelve cuando salga la versión completa... ";
                    msg.gameObject.GetComponent<Text>().text = " ";
                    sigue = false;
                } 
                break;
            case 2: 
                {
                    this.GetComponent<SpriteRenderer>().sprite = imagen;
                    GameObject.FindGameObjectWithTag("globgirl").GetComponent<SpriteRenderer>().enabled = false;
                    girltxt.gameObject.GetComponent<Text>().text = "  ";
                    msg.gameObject.GetComponent<Text>().text = " TOCA EL BOTÓN PARA CONTINUAR ";
                    sigue = true;
                } 
                break;
            case 4: 
                { 
                    this.GetComponent<SpriteRenderer>().sprite = imagen4;
                    GameObject.FindGameObjectWithTag("globgirl").GetComponent<SpriteRenderer>().enabled = true;
                    girltxt.gameObject.GetComponent<Text>().text = "Naah que flojera... ";
                    msg.gameObject.GetComponent<Text>().text = " ";
                    sigue = false;

                } 
                break;
            case 3:
                {
                    this.GetComponent<SpriteRenderer>().sprite = imagen3;
                    GameObject.FindGameObjectWithTag("globgirl").GetComponent<SpriteRenderer>().enabled = true;
                    girltxt.gameObject.GetComponent<Text>().text = " Ahora no... tal vez en la siguiente versión";
                    msg.gameObject.GetComponent<Text>().text = " ";
                    sigue = false;
                }
                break;


        }
    }

 

}
