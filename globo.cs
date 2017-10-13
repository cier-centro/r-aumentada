using UnityEngine;
using System.Collections;

public class globo : MonoBehaviour {

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
            this.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(Mostrar());            
        }
    }

    IEnumerator Mostrar()
    {
        yield return new WaitForSeconds(4);
        this.GetComponent<SpriteRenderer>().enabled = false;
        ready = true;
    }

}
