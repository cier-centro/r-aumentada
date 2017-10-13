using UnityEngine;
using System.Collections;

public class perroSkate : MonoBehaviour {

    public string img;
    public static bool readySKT = false;
       
    void Start()
    {      
            this.GetComponent<SpriteRenderer>().enabled = true;
             StartCoroutine(Mostrar());                 
    }

    void FixedUpdate()
    {
        if(readySKT==false)
        {
            StartCoroutine(Mostrar());            
        }
    }

    IEnumerator Mostrar()
    {
        yield return new WaitForSeconds(3);
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Canvas>().enabled = false;
        readySKT = true;
    }


}
