using UnityEngine;
using System.Collections;

public class perroBib : MonoBehaviour {

    public static bool readyBib = false;
       
    void Start()
    {      
            this.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(Mostrar());                 
    }

    void FixedUpdate()
    {
        if(readyBib==false)
        {
            StartCoroutine(Mostrar());            
        }
    }

    IEnumerator Mostrar()
    {
        yield return new WaitForSeconds(4);
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Canvas>().enabled = false;
        readyBib = true;
    }


}
