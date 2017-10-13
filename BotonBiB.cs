using UnityEngine;
using System.Collections;

public class BotonBiB : MonoBehaviour

{
    private float time;
    public Camera cameraBibBot;
    public static bool upBib, downBib, leftBib, rightBib = false;

    void Start()
    {
        time = 0f;
    }

    void LateUpdate()
    {
        time += Time.deltaTime;
        if (time < 2f)
            this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, -0.45f * time + 1f);
    }
    
    bool HizoClick(Vector3 mouse)
    {
        if ((cameraBibBot.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (cameraBibBot.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (cameraBibBot.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (cameraBibBot.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
            return true;
        else
            return false;
    }

    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        
        if (Input.GetMouseButtonDown(0) )//Lee si se hizo click
        {
            if (HizoClick(mouse) && this.name == "Bot_DownBib")
            {
                downBib = true;
                rightBib = upBib = leftBib = false;
            }
            else if (HizoClick(mouse) && this.name == "Bot_UpBib")
            {
                upBib = true;
                rightBib = leftBib = downBib = false;
            }
            else if (HizoClick(mouse) && this.name == "Bot_LeftBib")
            {
                leftBib = true;
                rightBib = upBib = downBib = false;
            }
            else if (HizoClick(mouse) && this.name == "Bot_RightBib")
            {
                rightBib = true;
                leftBib = upBib = downBib = false;
            }
        }
         if(Input.GetMouseButtonUp(0)) { rightBib = leftBib = upBib = downBib = false; }
    }

}
