using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LanzarSkate : MonoBehaviour
{
    //Variables públicas
    public float Vel_TSKT;
    public GameObject BombaSKT;

    //Variables privadas
    private Rigidbody2D R_Bomba;
    private AudioSource dispara;

    void Start()
    {
        R_Bomba = BombaSKT.GetComponent<Rigidbody2D>();
        dispara = gameObject.AddComponent<AudioSource>();
        dispara.clip = Resources.Load("life") as AudioClip;
    }

    void Update()
    {
        if (this.name == "Bomba2(Clone)")
        {
            R_Bomba.transform.Translate(new Vector2(-BombSkate.TiroSkt,0) * Time.deltaTime);
        }

        else
        {
            R_Bomba.transform.Translate(new Vector2( -Vel_TSKT,0) * Time.deltaTime);
        }     
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (this.name == "Bomba(Clone)")
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sombra");
            if(co.name=="Grupo11" || co.name=="Grupo12" ||co.name=="Grupo21" ||co.name=="Grupo22" ||co.name=="Grupo31" ||co.name=="Grupo41" ||co.name=="Grupo42" ||co.name=="Grupo43" ||co.name=="Grupo51")
            {
                RunMoveSkate.disparoSKT = true;
                this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("rayo");
                R_Bomba.transform.Translate(new Vector2(0, 0) * Time.deltaTime);
                dispara.Play();
            }
            if (co.name == "final")
            {
                RunMoveSkate.disparoSKT = false;
            }
            
        }
            


        if (this.name == "Bomba2(Clone)" && co.name == "Player")
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            if (RunMoveSkate.vidasSKT < 0)
            {
                Application.LoadLevel(16);
            }

            else
            {
                RunMoveSkate.vidasSKT -= 1;
                perroSkate.readySKT = false;
                DestroyObject(this);
                GetComponent<SpriteRenderer>().enabled = false;
            }           
        }
      
    }

}
