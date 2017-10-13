using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BotEsc : MonoBehaviour

{
    private float time;
    public Camera camera;
    public string bot,fondo;
    public static bool Avanza = false;
    private AudioSource  sonfon, sonbot;
    private bool seguir;

    void Start()
    {
        time = 0f;
        camera = Camera.main;
        sonbot = gameObject.AddComponent<AudioSource>(); //Asocia un archivo de audio a una parametro para un objeto
        sonbot.clip = Resources.Load(bot) as AudioClip;

        sonfon = gameObject.AddComponent<AudioSource>(); 
        sonfon.clip = Resources.Load(fondo) as AudioClip;
        sonfon.Play();
    }

    void LateUpdate()
    {
        time += Time.deltaTime;
        if (time < 2f)
            if (this.name != "continuar")
            {
                this.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, -0.25f * time + 1f);
            }
    }

    bool HizoClick(Vector3 mouse)
    {
        if ((camera.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (camera.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (camera.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (camera.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
            return true;
        else
            return false;
    }

    void Update()
    {
        Vector3 mouse = Input.mousePosition;        
        if (Input.GetMouseButtonDown(0))//Lee si se hizo click
        {           
            if (HizoClick(mouse) && seguir)
            {
                sonbot.Play();
                if(this.name == "Bot_Left")
                {
                    if (Cambio.num < 4)
                        Cambio.num += 1;
                    else
                        Cambio.num = 1;
                    seguir = false;
                }
                if(this.name == "Bot_Right")
                {
                    if (Cambio.num > 1)
                        Cambio.num -= 1;
                    else
                        Cambio.num = 4;
                    seguir = false;
                }
               if (HizoClick(mouse) && this.name == "continuar")
                {
                    Application.LoadLevel(2);
                }

            }

                    }
        if (Input.GetMouseButtonUp(0)) 
        { 
            seguir = true; 
        }
    }


    void FixedUpdate()
    {
        if (Cambio.sigue)
        {
            GameObject.Find("continuar").GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GameObject.Find("continuar").GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }

}
