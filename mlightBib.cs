using UnityEngine;
using System.Collections;

public class mlightBib : MonoBehaviour {

    public static bool rapidoBib;
    public GameObject PerseguidoBib;

    void OnTriggerEnter2D(Collider2D co)
    {

        if (co.name == "PlayerBib")
        {
            this.GetComponent<Light>().color = new Color(1F, 0.1F, 0.1F, 1F);
            rapidoBib = true;
        }         

    }

    void Start()
    {
       PerseguidoBib= GameObject.FindWithTag("PlayerBib");
        GUI.Label(new Rect(200, 20, 200, 20), PuntajeBib.Txt2Bib, PuntajeBib.EstiloBib);
    }
    void Update()
    {       
        if( mlightBib.rapidoBib)
        {
            PuntajeBib.Txt2Bib = "TE VIERON!!!";
            GetComponent<Light>().color = new Color(1F, 0.1F, 0.1F, 1F);         
        }
        if (!mlightBib.rapidoBib)
        {
            GetComponent<Light>().color = new Color(1F, 1F, 1F, 1F);
            
            if (PuntajeBib.scoreBib >= 4) PuntajeBib.Txt2Bib = "Ve a la puerta!!";
            //else PuntajeBib.Txt2Bib = " ";
        }
        if (this.name == "ProfeLight2")
        {
            if (Mathf.Abs(PerseguidoBib.GetComponent<Transform>().position.x - this.GetComponent<Transform>().position.x) >20f || Mathf.Abs(PerseguidoBib.GetComponent<Transform>().position.y - this.GetComponent<Transform>().position.y) > 20f)
                mlightBib.rapidoBib = false;
        }
        
        
    }
}
