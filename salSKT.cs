using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class salSKT : MonoBehaviour
{
    public static int contSKT = 0;
    Vector2 pos, pos2 = Vector2.zero;
    private AudioSource sound;
    

	void Start () 
    {
        pos = new Vector2(-32.4f, -10f);
        pos2 = new Vector2(-8.4f, -10f);
        this.transform.position = pos;
        sound = gameObject.AddComponent<AudioSource>();
        sound.clip = Resources.Load("introjuego") as AudioClip;
        sound.Play();
	}

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "PlayerBarrio" && contSKT == 0)
        {            
            this.transform.position = pos2;
            contSKT = 1;
        }
        if (co.name == "PlayerBarrio" && contSKT == 2)
        {
            Application.LoadLevel(15);
        }
    }
}
