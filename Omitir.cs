using UnityEngine;
using System.Collections;

public class Omitir : MonoBehaviour {

    public string TxtPantalla;
    public static string Txt2;
    public Texture2D icono;
    public static GUIStyle Estilo = new GUIStyle();
    public static AudioSource sonfondo;

    void Start()
    {
        Estilo.font = (Font)Resources.Load("letra", typeof(Font));
        Estilo.normal.textColor = Color.white;
        TxtPantalla = "TOCA LA PANTALLA PARA CONTINUAR";
        sonfondo = gameObject.AddComponent<AudioSource>(); //Asocia un archivo de audio a una parametro para un objeto
        sonfondo.clip = Resources.Load("fondo") as AudioClip;
        sonfondo.Play();

    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 50, 50), icono);
        GUI.Label(new Rect(40, 20, 200, 20), TxtPantalla, Estilo);
    }


    void Update ()
    {
	    if(Input.GetMouseButtonDown(0))  Application.LoadLevel(1);
    }
}
