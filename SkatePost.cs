using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkatePost : MonoBehaviour {

    private float timeTran, timeTran2, timeTran3;
    public Camera camSKT;
    private AudioSource sound, soundnic;
    Vector2 dest = Vector2.zero;
    private int nextSKT = 0;
    private bool cambio, sond = true;

	// Use this for initialization
	void Start () 
    {
        timeTran2 = 0f;
        dest = new Vector2(-10.80479f, -3.549454f);
        sound = gameObject.AddComponent<AudioSource>();
        soundnic = gameObject.AddComponent<AudioSource>();
        sound.clip = Resources.Load("introjuego") as AudioClip;        
        sound.Play();
        sond = false;

        GameObject.Find("globo 02").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("globop1").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("globop2").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("globop3").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("TextPr").gameObject.GetComponent<Text>().text = "  ";
        GameObject.Find("Textop1").gameObject.GetComponent<Text>().text = "  ";
        GameObject.Find("Textop2").gameObject.GetComponent<Text>().text = "  ";
        GameObject.Find("Textop3").gameObject.GetComponent<Text>().text = "  ";
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        Vector3 mouse = Input.mousePosition;
        timeTran2 += Time.deltaTime;
        timeTran3 += Time.deltaTime;
        timeTran += Time.deltaTime;
        Debug.Log(nextSKT);
        if (timeTran2 <= 2f)
        {
            GameObject.Find("globo2").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("globo3").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("globoplayer").GetComponent<SpriteRenderer>().enabled = false;
            dest.x += Time.deltaTime * 8;
            GameObject.Find("PlayerSkt").GetComponent<Rigidbody2D>().MovePosition(dest);            
        }
        else if (timeTran2 <= 6f)
        {            
            GameObject.Find("PlayerSkt").GetComponent<Animator>().SetTrigger("StopWalkMan");           
            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = "¡Haz ganado esta vez! ¡pero en las próximas ocasiones no habrá oportunidad para juegos.";
        }
        else if (timeTran2 <= 10f)
        {
            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = " ";
            GameObject.Find("globoplayer").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("TextP").gameObject.GetComponent<Text>().text = "¿Por qué siempre insistes en saltarte las reglas? ";
        }
        else if (timeTran2 <= 13f)
        {
            GameObject.Find("globoplayer").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("TextP").gameObject.GetComponent<Text>().text = " ";
            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = "Escucha Jugador, te contaré una historia: Cuando éramos pequeños, una noche, nuestra madre nos contó una historia:";
            soundnic.clip = Resources.Load("audio1") as AudioClip;
            soundnic.Play();
            sond = true;
        }
        else if ( timeTran2 < 40f)
        {
            
            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = " ";
            GameObject.Find("globoplayer").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("TextP").gameObject.GetComponent<Text>().text = " !!"; 
        }
       else if (timeTran >= 68f && timeTran <= 72f)
       {
            sond = false;
            GameObject.Find("globo2").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Text2").gameObject.GetComponent<Text>().text = "  ¿Estás escuchando? te ves distraído. ¿Qué fue lo que dijo mi hermano? ";
            GameObject.Find("globoplayer").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("TextP").gameObject.GetComponent<Text>().text = " ";
            nextSKT = 2;
       }

        else if (nextSKT == 2)
        {
            GameObject.Find("globo2").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Text2").gameObject.GetComponent<Text>().text = "    ";
            GameObject.Find("globo 02").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("globop1").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("globop2").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("globop3").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("TextPr").gameObject.GetComponent<Text>().text = " ...Que la obediencia de las normas... ";
            GameObject.Find("Textop1").gameObject.GetComponent<Text>().text = " permite a los insectos hacer grandes obras. ";
            GameObject.Find("Textop2").gameObject.GetComponent<Text>().text = " permite a los mosquitos hacer grandes obras. ";
            GameObject.Find("Textop3").gameObject.GetComponent<Text>().text = " permite a las abejas hacer grandes obras. ";
        }
        else if (nextSKT == 6)
        {
            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = "  ";
            GameObject.Find("globo2").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Text2").gameObject.GetComponent<Text>().text = "    ";
            GameObject.Find("globo 02").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("globop1").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("globop2").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("globop3").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("TextPr").gameObject.GetComponent<Text>().text = " En cuál de las siguientes formas NO le contestarías al hermano de Niki: ";
            GameObject.Find("Textop1").gameObject.GetComponent<Text>().text = " ...Están exentos de las normas. ";
            GameObject.Find("Textop2").gameObject.GetComponent<Text>().text = "... son los que hacen las normas.";
            GameObject.Find("Textop3").gameObject.GetComponent<Text>().text = "... son como las abejas reina... ";

        }





        if (Input.GetMouseButtonDown(0) && nextSKT == 2)
        {
            if (HizoClick(mouse) && this.name == "globop1" || this.name == "globop2")
            {
                //timeTran2 = 10f;
                Debug.Log("mal");
                nextSKT = 2;
            }
            else if (HizoClick(mouse) && this.name == "globop3")
            {
                nextSKT = 3;
                Debug.Log("bien");
            }            
        }

        if (nextSKT == 3 || nextSKT == 4 || nextSKT == 5 || nextSKT >= 7)
        {
            GameObject.Find("globo 02").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("globop1").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("globop2").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("globop3").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("TextPr").gameObject.GetComponent<Text>().text = "  ";
            GameObject.Find("Textop1").gameObject.GetComponent<Text>().text = "  ";
            GameObject.Find("Textop2").gameObject.GetComponent<Text>().text = "  ";
            GameObject.Find("Textop3").gameObject.GetComponent<Text>().text = "  ";
            
        }

        if (nextSKT == 3 && Input.GetMouseButtonDown(0) && cambio)
            
        {

            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = "Jugador aquí viene lo más importante:";
            nextSKT = 4;
            cambio = false;

        }

        if (nextSKT == 4 && Input.GetMouseButtonDown(0) && cambio)
        {
            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = " ";
            soundnic.clip = Resources.Load("audio2") as AudioClip;
            soundnic.Play();
            nextSKT = 5;
            cambio = false;
        }

        if (nextSKT == 5 && Input.GetMouseButtonDown(0) && cambio)
        {
            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = " ¿Entiendes? ";
            soundnic.Stop();
            cambio = false;
            nextSKT = 6;
        }
        if (nextSKT == 6 && Input.GetMouseButtonDown(0) && cambio)
        {
            cambio = false;
            nextSKT = 7;
        }

        if (Input.GetMouseButtonDown(0) && nextSKT == 7 && cambio)
        {
            if (HizoClick(mouse) && this.name == "globop1" || this.name == "globop2")
            {
                Debug.Log("mal");
                nextSKT = 6;
            }
            else if (HizoClick(mouse) && this.name == "globop3")
            {
                nextSKT = 8;
                Debug.Log("bien");
            }
        }

        if (nextSKT == 8 && Input.GetMouseButtonDown(0) && cambio)
        {
            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = " ";
            GameObject.Find("globoplayer").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("TextP").gameObject.GetComponent<Text>().text = "Tu historia por poco me convence pero...! nosotros nosomos abejas Niki !";
            nextSKT = 9;
            cambio = false;
        }
        if (nextSKT == 9 && Input.GetMouseButtonDown(0) && cambio)
        {
            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = "Pero casi... la historia de esta ciudad lo demuestra.. ";
            GameObject.Find("globoplayer").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("TextP").gameObject.GetComponent<Text>().text = " ";
            nextSKT = 10;
            cambio = false;
        }

        if (nextSKT == 10 && Input.GetMouseButtonDown(0) && cambio)
        {
            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = " ";
            GameObject.Find("globoplayer").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("TextP").gameObject.GetComponent<Text>().text = "Es cierto Nicki  hemos permanecido en las tinieblas por mucho tiempo, pero somos diferentes ahora..";
            nextSKT = 11;
            cambio = false;
        }
        if (nextSKT == 11 && Input.GetMouseButtonDown(0) && cambio)
        {
            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = "¿diferentes? ¿crees que tus insolencias pueden cambiar en algo esta ciudad? ";
            GameObject.Find("globoplayer").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("TextP").gameObject.GetComponent<Text>().text = " ";
            nextSKT = 12;
            cambio = false;
        }
        if (nextSKT == 12 && Input.GetMouseButtonDown(0) && cambio)
        {
            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = " ";
            GameObject.Find("globoplayer").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("TextP").gameObject.GetComponent<Text>().text = " Las abejas obreras están condenadas a ser obreras y las que son reinas condenadas a ser reina. En nuestro caso es diferente, nosotros delegamos nuestras  abejas reinas y si queremos ¡podemos quitarlas! ¡ la historia del mundo lo demuestra!";
            nextSKT = 13;
            cambio = false;
        }
        if (nextSKT == 13 && Input.GetMouseButtonDown(0) && cambio)
        {
            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = "JUGADOR, no somos de la misma estirpe ¡Entiéndelo de una vez! ";
            GameObject.Find("globoplayer").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("TextP").gameObject.GetComponent<Text>().text = " ";
            nextSKT = 14;
            cambio = false;
        }

        if (nextSKT == 14 && Input.GetMouseButtonDown(0) && cambio)
        {
            GameObject.Find("globo3").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Text3").gameObject.GetComponent<Text>().text = " Hermano, tal vez deberíamos decirles del niño ...";
            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = " ";
            nextSKT = 15;
            cambio = false;
        }
        if (nextSKT == 15 && Input.GetMouseButtonDown(0) && cambio)
        {
            GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = "¡Dejémonos de historias ridículas! Nos vamos ... porque eres un chico valiente; pero esto no se volverá a repetir, no olvides cuál es tu lugar y cuál el de nosotros.";
            GameObject.Find("globo3").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Text3").gameObject.GetComponent<Text>().text = " ";
            nextSKT = 16;
            cambio = false;
        }
        if (nextSKT == 16 && Input.GetMouseButtonDown(0) && cambio)
        {

            Application.LoadLevel(1);
            
        }


        if (Input.GetMouseButtonUp(0)) { cambio = true; }

    }

    bool HizoClick(Vector3 mouse)
    {
        if ((camSKT.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (camSKT.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (camSKT.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (camSKT.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
            return true;
        else
            return false;
    }
}
