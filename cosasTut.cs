using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cosasTut : MonoBehaviour {

    public Camera cameraCT;
    // Use this for initialization
	void Start () 
    {
        GetComponent<SpriteRenderer>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    Vector3 mouse = Input.mousePosition;
        if (Input.GetMouseButtonDown(0) && HizoClick(mouse))
        {
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        }
	}

    bool HizoClick(Vector3 mouse)
    {
        if ((cameraCT.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (cameraCT.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (cameraCT.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (cameraCT.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
            return true;
        else
            return false;
    }
}
