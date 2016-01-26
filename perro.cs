using UnityEngine;
using System.Collections;

public class perro : MonoBehaviour {

    public string img;
    public static bool ready = false;
       
    void Start()
    {      
            this.GetComponent<SpriteRenderer>().enabled = true;
             StartCoroutine(Mostrar());                 
    }

    void FixedUpdate()
    {
        if(ready==false)
        {
            StartCoroutine(Mostrar());            
        }
    }

    IEnumerator Mostrar()
    {
        yield return new WaitForSeconds(3);
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Canvas>().enabled = false;
        ready = true;
    }


}
