using UnityEngine;
using System.Collections;

public class Boton : MonoBehaviour

{
    private float time;
    public Camera camera;
    public static bool up, down, left, right = false;

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

        if ((camera.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (camera.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (camera.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (camera.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
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
                down = true;
                right = up = left = false;
            }
            else if (HizoClick(mouse) && this.name == "Bot_Up")
            {
                up = true;
                right = left = down = false;
            }
            else if (HizoClick(mouse) && this.name == "Bot_Left")
            {
                left = true;
                right = up = down = false;
            }
            else if (HizoClick(mouse) && this.name == "Bot_Right")
            {
                right = true;
                left = up = down = false;
            }
        }
         if(Input.GetMouseButtonUp(0)) { right = left = up = down = false; }
    }

}
