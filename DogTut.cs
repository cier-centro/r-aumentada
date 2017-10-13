using UnityEngine;
using System.Collections;

public class DogTut : MonoBehaviour 
{
    public Camera cameraDog;
    public Sprite ImgDogLeft, ImgDogRight;
    public GameObject ojosDog;
    private bool Leyendo = false;

	
	// Update is called once per frame

    void Update ()
    {
        Vector3 mouse = Input.mousePosition;


        if (Input.GetMouseButtonDown(0) &&  Mensajes.conteo == 8)
        {
            Pregunta.vis = true;
        }

        if (Input.GetMouseButtonDown(0) && (HizoClick(mouse)))//Lee si se hizo click
        {
            Leyendo = true;

            if (Mensajes.conteo!=0 && Mensajes.conteo != 11 && Mensajes.conteo != 12 && Mensajes.conteo != 13 )
            {
                Mensajes.visible = !Mensajes.visible;
            }
            
            if (Mensajes.conteo == 11  && Leyendo) 
            {

                Mensajes.conteo = 12;
                Leyendo = false;
            }

            if (Mensajes.conteo == 12 && Leyendo)
            {
                Mensajes.conteo = 13;
                Leyendo = false;
            }

            if (Mensajes.conteo == 13 && Leyendo)
            {

                Mensajes.conteo = 1;
                Leyendo = false;
            }
        }

        if (BotonTut.rightTut)
        {
            this.GetComponent<SpriteRenderer>().sprite = ImgDogRight;
            ojosDog.GetComponent<Transform>().localRotation = new Quaternion(0, 0f, 0, 0);
            ojosDog.GetComponent<Transform>().localPosition = new Vector3(0.52564f, 0.5755f, 0f);
        }

        if (BotonTut.leftTut) 
        {
            this.GetComponent<SpriteRenderer>().sprite = ImgDogLeft;
            ojosDog.GetComponent<Transform>().localRotation = new Quaternion(0, 180f, 0, 0);
            ojosDog.GetComponent<Transform>().localPosition = new Vector3(-0.537f, 0.569f, 0f);
        }


    }

       
    bool HizoClick(Vector3 mouse)
    {
        if ((cameraDog.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (cameraDog.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (cameraDog.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (cameraDog.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
            return true;
        else
            return false;
    }

    void FixedUpdate()
    {
        if (Pies.pies_piso == false && Mensajes.conteo > 1)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            ojosDog.GetComponent<SpriteRenderer>().enabled = false;
            Mensajes.visible = false;
        }
        else if (Mensajes.conteo != 0)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            ojosDog.GetComponent<SpriteRenderer>().enabled = true;          
        
        }
    }

    IEnumerator Mostrar()
    {
        Leyendo = true;
        this.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(2);
        Leyendo = false;
        
    }
}