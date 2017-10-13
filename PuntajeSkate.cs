using UnityEngine;
using System.Collections;

public class PuntajeSkate : MonoBehaviour {

    public static int scoreG1, scoreG2, scoreG3, scoreG4, scoreG5, global;
    public string TxtPantalla, TxtPantalla2;
    public Texture2D icono, icono2, icono3, icono4, icono5;
    GUIStyle Estilo = new GUIStyle();
    private AudioSource fondo;
    void Start()
    {
        Estilo.font= (Font)Resources.Load("Letra-Bold", typeof(Font));
        Estilo.normal.textColor = Color.white;
        scoreG1 = 0;
        scoreG2 = 0;
        scoreG3 = 0;
        scoreG4 = 0;
        scoreG5 = 0;
        global = 0;
        fondo= gameObject.AddComponent<AudioSource>();
        fondo.clip = Resources.Load("fondo") as AudioClip;
        fondo.Play();
        fondo.loop = true;
    }

    void OnGUI()
    {
        TxtPantalla = "Grupo1: " + scoreG1 + "/2";
        GUI.Label(new Rect(20, 90, 40, 40), icono);
        GUI.Label (new Rect(60, 100, 200, 20), TxtPantalla,Estilo);

        TxtPantalla2 = "Grupo2: " + scoreG2 + "/2";
        GUI.Label(new Rect(20, 125, 40, 40), icono2);
        GUI.Label(new Rect(60, 135, 200, 20), TxtPantalla2, Estilo);

        GUI.Label(new Rect(20, 160, 40, 40), icono3);
        GUI.Label(new Rect(60, 170, 200, 20), "Grupo3: " + scoreG3 + "/2", Estilo);

        GUI.Label(new Rect(20, 195, 40, 40), icono4);
        GUI.Label(new Rect(60, 205, 200, 20), "Grupo4: " + scoreG4 + "/3", Estilo);

        GUI.Label(new Rect(20, 230, 40, 40), icono5);
        GUI.Label(new Rect(60, 240, 200, 20), "Grupo5: " + scoreG5 + "/1", Estilo);


    }    
      
}
