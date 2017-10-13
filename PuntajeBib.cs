using UnityEngine;
using System.Collections;

public class PuntajeBib : MonoBehaviour {

    public static int scoreBib;
    public string TxtPantalla;
    public Font TLetra;
    public static string Txt2Bib;
    public Texture2D icono;
    public static GUIStyle EstiloBib = new GUIStyle();
    void Start()
    {
        EstiloBib.font = (Font)TLetra;
        EstiloBib.normal.textColor = Color.white;
        scoreBib = 0;
        TxtPantalla = "Objetos: " ;
        Txt2Bib = "... ";
    }

    void OnGUI()
    {
        if (PersoneroBib.pilladoBib)
        {
            scoreBib = 0;
            PersoneroBib.pilladoBib = false;
            mlightBib.rapidoBib = false;
            ProfeMoveBib.speed -= 0.08f;
        }

        TxtPantalla = "Objetos: " + scoreBib+" de 7";
        GUI.Label(new Rect(10, 80, 50, 50), icono);
        GUI.Label (new Rect(50, 90, 200, 20), TxtPantalla,EstiloBib);
        GUI.Label(new Rect(50, 130, 200, 20), Txt2Bib, EstiloBib);
     }
    
      
}
