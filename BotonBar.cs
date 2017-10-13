using UnityEngine;
using System.Collections;

public class BotonBar : MonoBehaviour

{
    private float timeBar;
    public Camera cameraBar;
    public static bool upBar, downBar, leftBar, rightBar = false;

    void Start()
    {
        timeBar = 0f;
    }

    void LateUpdate()
    {
        timeBar += Time.deltaTime;
        if (timeBar < 2f)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, -0.45f * timeBar + 1f);
        }
    }

  
    bool HizoClick(Vector3 mouse)
    {
        if ((cameraBar.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (cameraBar.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (cameraBar.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (cameraBar.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
            return true;
        else
            return false;
    }

    void Update()
    {
        Vector3 mouse = Input.mousePosition;

        if (Input.GetMouseButtonDown(0) )//Lee si se hizo click
        {
            if (HizoClick(mouse) && this.name == "Bot_UpBar" && !DialogBar.Fade && !SalPol.FadeFin)
            {
                Debug.Log("arriba");
                timeBar = 0f;
                upBar = true;
                rightBar = leftBar = downBar = false;

            }
            else if (HizoClick(mouse) && this.name == "Bot_LeftBar" && !DialogBar.Fade && !SalPol.FadeFin)
            {
                timeBar = 0f;
                leftBar = true;
                rightBar = upBar = downBar = false;

            }
            else if (HizoClick(mouse) && this.name == "Bot_RightBar" && !DialogBar.Fade && !SalPol.FadeFin)
            {
                timeBar = 0f;
                rightBar = true;
                leftBar = upBar = downBar = false;

            }
        }
         if(Input.GetMouseButtonUp(0)) 
         {
             upBar = rightBar = leftBar = false;
             GameObject.Find("Perro").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("DogSit");
             GameObject.Find("Ojos Perro").GetComponent<SpriteRenderer>().enabled = false;   
         }
    }
}
