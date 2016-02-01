using UnityEngine;
using System.Collections;

public class mlight : MonoBehaviour {

    public static bool rapido;
    public GameObject Perseguido;

    void OnTriggerEnter2D(Collider2D co)
    {

        if (co.name == "Player")
        {
            this.GetComponent<Light>().color = new Color(1F, 0.1F, 0.1F, 1F);
            rapido = true;
        }         

    }

    void Start()
    {
       Perseguido= GameObject.FindWithTag("Player");
    }
    void Update()
    {       
        if( mlight.rapido)
        {
            Puntaje2.Txt2 = "TE VIERON!!!";
            GUI.Label(new Rect(200, 20, 200, 20), Puntaje2.Txt2, Puntaje2.Estilo);
            GetComponent<Light>().color = new Color(1F, 0.1F, 0.1F, 1F);         
        }
        if (!mlight.rapido)
        {
            GetComponent<Light>().color = new Color(1F, 1F, 1F, 1F);
            
            if (Puntaje2.score >= 4) Puntaje2.Txt2 = "Ve a la puerta!!";
            else Puntaje2.Txt2 = "... ";
        }
        if (Mathf.Abs(Perseguido.GetComponent<Transform>().position.x - this.GetComponent<Transform>().position.x) > 10f && Mathf.Abs(Perseguido.GetComponent<Transform>().position.y - this.GetComponent<Transform>().position.y) > 10f)
        {
            mlight.rapido = false;
        }
        
    }
}
