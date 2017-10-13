using UnityEngine;
using System.Collections;

public class BotonTut : MonoBehaviour

{
    private float timeTut;
    public Camera cameraTut;
    public static bool upTut, downTut, leftTut, rightTut = false;

    void Start()
    {
        timeTut = 0f;
    }

    void LateUpdate()
    {
        timeTut += Time.deltaTime;
        if (timeTut < 2f)
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, -0.4f * timeTut + 1f);
    }

  
    bool HizoClick(Vector3 mouse)
    {
        if ((cameraTut.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (cameraTut.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (cameraTut.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (cameraTut.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
            return true;
        else
            return false;
    }

    void Update()
    {
        Vector3 mouse = Input.mousePosition;

        if (Input.GetMouseButtonDown(0)  && Mensajes.conteo >0 && Mensajes.conteo < 10)//Lee si se hizo click
        {
            if (HizoClick(mouse) && this.name == "Bot_Down")
            {
                timeTut = 0f;
                downTut = true;
                rightTut = upTut = leftTut = false;
                this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 2);
            }
            else if (HizoClick(mouse) && this.name == "Bot_Up" && Mensajes.conteo >= 2)
            {
                timeTut = 0f;
                upTut = true;
                rightTut = leftTut = downTut = false;
                this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 2);
                if (Mensajes.conteo == 2)
                {
                    Mensajes.conteo = 3;
                    Mensajes.visible = true;
                }
            }
            else if (HizoClick(mouse) && this.name == "Bot_Left")
            {
                timeTut = 0f;
                leftTut = true;
                rightTut = upTut = downTut = false;
                this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 2);
                if (Mensajes.conteo == 1) 
                {
                    Mensajes.conteo = 2;
                    Mensajes.visible = true;

                }
            }
            else if (HizoClick(mouse) && this.name == "Bot_Right")
            {
                timeTut = 0f;
                rightTut = true;
                leftTut = upTut = downTut = false;
                this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 2);
                if (Mensajes.conteo == 1)
                {
                    Mensajes.conteo = 2;
                    Mensajes.visible = true;
                }
            }
        }
         if(Input.GetMouseButtonUp(0)) 
         { 
             upTut = rightTut = leftTut  = false;
         }
    }

    void FixedUpdate() 
    {

        if (this.name == "Bot_Up")
        {
            if ((Mensajes.conteo < 2 || Mensajes.conteo > 9))
                this.GetComponent<SpriteRenderer>().enabled = false;
            else if (Mensajes.conteo == 2)
            {
                this.GetComponent<SpriteRenderer>().enabled = true;
                timeTut = 0f;
                this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 2);
            }
        }

        else if (this.name == "Bot_Left" || this.name == "Bot_Right")
        {
            if (Mensajes.conteo > 9)
                this.GetComponent<SpriteRenderer>().enabled = false;
            else if (Mensajes.conteo == 1)
            {
                this.GetComponent<SpriteRenderer>().enabled = true;                
                timeTut = 0f;
                this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 2);
            }
        }
        
        if (Application.loadedLevelName == "Barrio") 
        {
            Vector3 mouse = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))//Lee si se hizo click
            {
                if (HizoClick(mouse) && this.name == "Bot_Up" )
                {
                    timeTut = 0f;
                    upTut = true;
                    rightTut = leftTut = downTut = false;
                    this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 2);

                }
                else if (HizoClick(mouse) && this.name == "Bot_Left")
                {
                    timeTut = 0f;
                    leftTut = true;
                    rightTut = upTut = downTut = false;
                    this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 2);
                    
                }
                else if (HizoClick(mouse) && this.name == "Bot_Right")
                {
                    timeTut = 0f;
                    rightTut = true;
                    leftTut = upTut = downTut = false;
                    this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 2);
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                upTut = rightTut = leftTut = false;
            }
        
        
        }
    }


}
