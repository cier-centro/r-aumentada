using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DogBar : MonoBehaviour
{
    public Camera cameraDogBar;
    public Sprite ImgDogLeftBar, ImgDogRightBar;
    public GameObject ojosDogBar;


    void start()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
     }

    void Update()
    {
        Vector3 mouse = Input.mousePosition;

        if (BotonBar.rightBar)
        {
            this.GetComponent<SpriteRenderer>().sprite = ImgDogRightBar;
            ojosDogBar.GetComponent<Transform>().localRotation = new Quaternion(0, 0f, 0, 0);
            ojosDogBar.GetComponent<Transform>().localPosition = new Vector3(0.52564f, 0.5755f, 0f);
        }

        if (BotonBar.leftBar)
        {
            this.GetComponent<SpriteRenderer>().sprite = ImgDogLeftBar;
            ojosDogBar.GetComponent<Transform>().localRotation = new Quaternion(0, 180f, 0, 0);
            ojosDogBar.GetComponent<Transform>().localPosition = new Vector3(-0.537f, 0.569f, 0f);
        }
       

    }

    void FixedUpdate()
    {
        if (!PiesBar.pies_pisoBar)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;

        }
        else this.GetComponent<SpriteRenderer>().enabled = true;
    }
}