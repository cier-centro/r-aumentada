using UnityEngine;
using System.Collections;

public class Cuadros : MonoBehaviour {

    public GameObject cuadro;
    public Sprite c1, c2, c3;
    public Camera cameraCuad;
	// Use this for initialization
	void Start () 
    {
        cuadro.GetComponent<SpriteRenderer>().enabled = false;    
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 mouse = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))//Lee si se hizo click
        {
            if (HizoClick(mouse))
            {
                if (this.name == "cuadro1")
                {
                    cuadro.GetComponent<SpriteRenderer>().enabled = true; 
                    cuadro.GetComponent<SpriteRenderer>().sprite = c1;
                }
                else if (this.name == "cuadro2")
                {
                    cuadro.GetComponent<SpriteRenderer>().enabled = true; 
                    cuadro.GetComponent<SpriteRenderer>().sprite = c2;
                }
                else if (this.name == "cuadro3")
                {
                    cuadro.GetComponent<SpriteRenderer>().enabled = true; 
                    cuadro.GetComponent<SpriteRenderer>().sprite = c3;
                }
                if (this.name == "cuadBig")
                {
                    this.GetComponent<SpriteRenderer>().enabled = false; 
                }
            }
        }
	
	}

    bool HizoClick(Vector3 mouse)
    {
        if ((cameraCuad.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (cameraCuad.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (cameraCuad.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (cameraCuad.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
            return true;
        else
            return false;
    }
}
