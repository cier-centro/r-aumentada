using UnityEngine;
using System.Collections;

public class Puntaje2 : MonoBehaviour {

    public static int score;
    public string TxtPantalla;
    public Font TLetra;
    public static string Txt2;
    public Texture2D icono;
    public static GUIStyle Estilo = new GUIStyle();
    void Start()
    {
        Estilo.font = (Font)TLetra;
        Estilo.normal.textColor = Color.white;
        score = 0;
        TxtPantalla = "Objetos: " ;
        Txt2 = "... ";
    }

    void OnGUI()
    {
        if (Personero.pillado)
        {
            score = 0;
            Personero.pillado = false;
            mlight.rapido = false;
            ProfeMove.speed -= 0.08f;
        }

        TxtPantalla = "Objetos: " + score+" de 7";
        GUI.Label(new Rect(10, 80, 50, 50), icono);
        GUI.Label (new Rect(50, 90, 200, 20), TxtPantalla,Estilo);
        GUI.Label(new Rect(50, 130, 200, 20), Txt2, Estilo);
     }
    
      
}
