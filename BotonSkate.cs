using UnityEngine;
using System.Collections;

public class BotonSkate : MonoBehaviour

{
    private float time;
    public Camera cameraSTK;
    public static bool dispSKT,upSKT, downSKT, leftSKT, rightSKT, jumpSKT = false;

    void Start()
    {
        time = 0f;
    }

    void LateUpdate()
    {
        time += Time.deltaTime;
        if (time < 5f)
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, -0.15f * time + 1f);
    }
    
    bool HizoClick(Vector3 mouse)
    {

        if ((cameraSTK.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (cameraSTK.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (cameraSTK.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (cameraSTK.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
            return true;
        else
            return false;
    }

    void Update()
    {
        Vector3 mouse = Input.mousePosition;


        if (Input.GetMouseButtonDown(0) )//Lee si se hizo click
        {
            if (HizoClick(mouse) && this.name == "Bot_Down")
            {
                Debug.Log("Hizo Click Abajo");
                downSKT = true;
                jumpSKT = rightSKT = upSKT = leftSKT = dispSKT = false;
            }
            else if (HizoClick(mouse) && this.name == "Bot_Up")
            {
                Debug.Log("Hizo Click Arriba");
                upSKT = true;
                jumpSKT = rightSKT = leftSKT = downSKT = dispSKT = false;
            }
            else if (HizoClick(mouse) && this.name == "Bot_Left")
            {
                Debug.Log("Hizo Click Izquierda");
                leftSKT = true;
                jumpSKT = rightSKT = upSKT = downSKT = dispSKT  = false;
            }
            else if (HizoClick(mouse) && this.name == "Bot_Right")
            {
                Debug.Log("Hizo Click Derecha");
                rightSKT = true;
                jumpSKT = leftSKT = upSKT = downSKT = dispSKT = false;
            }
            else if (HizoClick(mouse) && this.name == "Bot_Disp")
            {
                Debug.Log("Hizo Click Disparo");
                dispSKT= true;
                jumpSKT = rightSKT = leftSKT = upSKT = downSKT = false;
            }
            else if (HizoClick(mouse) && this.name == "Bot_Jump")
            {
                Debug.Log("Hizo Click Saltar");
                jumpSKT = true;
                rightSKT = leftSKT = upSKT = downSKT = dispSKT=false;
            }
        }
         if(Input.GetMouseButtonUp(0)) 
         {            
             rightSKT = leftSKT = upSKT = downSKT = RunMoveSkate.saltoSKT = false;
         }
    }

}
