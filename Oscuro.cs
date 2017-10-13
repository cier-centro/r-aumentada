using UnityEngine;
using System.Collections;

public class Oscuro : MonoBehaviour 
{
    public Camera camera;
    public GameObject personaje, fondo2, ojos, perro;
    public string img;
    private bool change;
    public static bool luz_pared;
	// Use this for initialization
	void Start () 
    {
        personaje.GetComponent<SpriteRenderer>().enabled = false;
        fondo2.GetComponent<SpriteRenderer>().enabled = true;
        ojos.GetComponent<SpriteRenderer>().enabled = true;
        perro.GetComponent<SpriteRenderer>().enabled = false;
        change = true;
        luz_pared = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 mouse = Input.mousePosition;
        if (Input.GetMouseButtonDown(0) && HizoClick(mouse))
        {
            if (change)
            {
                personaje.GetComponent<SpriteRenderer>().enabled = false;
                perro.GetComponent<SpriteRenderer>().enabled = false;
                fondo2.GetComponent<SpriteRenderer>().enabled = true;
                ojos.GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(img);
                this.GetComponent<SpriteRenderer>().enabled = true;               
            }
            else
            {
                personaje.GetComponent<SpriteRenderer>().enabled = true;
                perro.GetComponent<SpriteRenderer>().enabled = true;
                fondo2.GetComponent<SpriteRenderer>().enabled = false;
                luz_pared = true;
                ojos.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<SpriteRenderer>().enabled = false;
            }
            change = !change;
        }	
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
}
