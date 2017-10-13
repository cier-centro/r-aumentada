using UnityEngine;
using System.Collections;

public class PersoneroTut : MonoBehaviour {

    public static float xTut= -55.58f;
    public static float yTut = -11.54f;
    public string backTut, winTut;
    public bool activ_sonidoTut;
    public static AudioSource sonfonTut, sonwinTut;
    

    void Start ()
    {
        sonfonTut = gameObject.AddComponent<AudioSource>(); //Asocia un archivo de audio a una parametro para un objeto
        sonwinTut = gameObject.AddComponent<AudioSource>();
        sonfonTut.clip = Resources.Load(backTut) as AudioClip;
        sonwinTut.clip = Resources.Load(winTut) as AudioClip;
        sonfonTut.Play();        
        xTut = this.gameObject.transform.position.x;
        yTut = this.gameObject.transform.position.y;
       
    }


  }
