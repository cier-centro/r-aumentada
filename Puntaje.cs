using UnityEngine;
using System.Collections;

public class Puntaje : MonoBehaviour {

    public static int scoreP, scoreY;
    public string TxtPantalla, TxtPantalla2;
    public Texture2D icono, icono2;
    GUIStyle Estilo = new GUIStyle();
    void Start()
    {
        Estilo.font = (Font)Resources.Load("Letra-Bold", typeof(Font));
        Estilo.normal.textColor = Color.white;
        scoreP = 0;
        scoreY = 0;
        TxtPantalla = "Piezas: " ;
        TxtPantalla2 = "Llave: ";
        
    }

    void OnGUI()
    {
        TxtPantalla = "Piezas: " + scoreP + "/4";
        GUI.Label(new Rect(60, 90, 30, 30), icono);
        GUI.Label (new Rect(90, 100, 200, 20), TxtPantalla,Estilo);
        TxtPantalla2 = "Llave: " + scoreY + "/1";
        GUI.Label(new Rect(60, 125, 30, 30), icono2);
        GUI.Label(new Rect(90, 130, 200, 20), TxtPantalla2, Estilo);

        if (scoreP>3 && scoreY==1) GUI.Label(new Rect(60, 230, 160, 15), "VE A LA PUERTA!!", Estilo);
    }    
      
}
