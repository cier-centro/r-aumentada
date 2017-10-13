using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EscenasT : MonoBehaviour {

    private float timeTran;
    private AudioSource sonasc,sound;
    Vector2 dest, dest2, dest3, destSkt = Vector2.zero;

    // Use this for initialization
    void Start ()
    {
        timeTran = 0;
        dest = new Vector2(-10.80479f, -2.949454f);
        dest2 = new Vector2(6.3f, -8.83f);
        dest3 = new Vector2(10.89f, -3.21f);
        destSkt = new Vector2(10.99f, -3.32f);
        sonasc = gameObject.AddComponent<AudioSource>();
        sound = gameObject.AddComponent<AudioSource>();
        sonasc.clip = Resources.Load("sonas") as AudioClip;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeTran += Time.deltaTime;
        if (Application.loadedLevelName == "Biblioteca1")
        {
            sound.clip = Resources.Load("sonmadera") as AudioClip;
            if (timeTran <= 0.5f)
            {
                sound.Play();
            }
            if (timeTran <= 2f)
            {
                GameObject.Find("globRon").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("globFelipe").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("globPer").GetComponent<SpriteRenderer>().enabled = false;
                dest.x += Time.deltaTime * 2;
                GameObject.Find("JugTrans").GetComponent<Rigidbody2D>().MovePosition(dest);
            }
            else if (timeTran <= 4f)
            {
                sound.Stop();
                GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtNicky1").gameObject.GetComponent<Text>().text = "¡Eh! ¿Escucharon algo?";
                GameObject.Find("JugTrans").GetComponent<Animator>().SetTrigger("StopWalkMan");
                GameObject.Find("JugTrans").GetComponent<Animator>().SetTrigger("BeginBlinkMan");

            }

            else if (timeTran <= 6f)
            {
                sound.clip = Resources.Load("sonagua") as AudioClip;
                sound.Play();
                GameObject.Find("globRon").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtRon1").gameObject.GetComponent<Text>().text = "¿Qué hacemos aquí? ¡Tengo miedo!";
                GameObject.Find("globPer").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Text").gameObject.GetComponent<Text>().text = "!!!";
            }
            else if (timeTran <= 10f)
            {
                GameObject.Find("globRon").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("globFelipe").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtNicky1").gameObject.GetComponent<Text>().text = " ";
                GameObject.Find("TxtRon1").gameObject.GetComponent<Text>().text = " ";
                GameObject.Find("TxtFelipe1").gameObject.GetComponent<Text>().text = "Nicky se acaba de robar el manual de convivencia del colegio. ¿Qué vas a hacer con él?";
                GameObject.Find("JugTrans").GetComponent<Animator>().SetTrigger("BeginBlinkMan");
            }
            else if (timeTran <= 14f)
            {
                GameObject.Find("globFelipe").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtFelipe1").gameObject.GetComponent<Text>().text = " ";
                GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtNicky1").gameObject.GetComponent<Text>().text = "Jaja, ya lo rompí.";
            }
            else if (timeTran <= 18f)
            {

                GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtNicky1").gameObject.GetComponent<Text>().text = " ";
                GameObject.Find("globRon").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtRon1").gameObject.GetComponent<Text>().text = "Qué poco de reglas y deberes. Que aburrimiento ese libro, ¿Alguien sabe para qué sirve toda esa tontería?";
            }
            else if (timeTran <= 20f)
            {
                GameObject.Find("globRon").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("globFelipe").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtNicky1").gameObject.GetComponent<Text>().text = " ";
                GameObject.Find("TxtRon1").gameObject.GetComponent<Text>().text = " ";
                GameObject.Find("TxtFelipe1").gameObject.GetComponent<Text>().text = "Y ahora ¿qué hacemos con los pedazos rotos? ";
                GameObject.Find("JugTrans").GetComponent<Animator>().SetTrigger("BeginBlinkMan");
            }
            else if (timeTran <= 22f)
            {
                GameObject.Find("globFelipe").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtFelipe1").gameObject.GetComponent<Text>().text = " ";
                GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtNicky1").gameObject.GetComponent<Text>().text = "Dejémoslos por la biblioteca. Aquí nadie entra, piensan que es un lugar perdido. Apaguen la vela y vamos.";
            }
            else if (timeTran == 24) timeTran = 0;
        }

        else if (Application.loadedLevelName == "Biblioteca2")
        {
            sound.clip = Resources.Load("sonagua") as AudioClip;
            
            if (timeTran <= 1f)
            {
                sound.Play();
                GameObject.Find("GlobRob").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("GlobFelipe").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("GlobNicky").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("GlobCapucho").GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (timeTran <= 3f)
            {                
                GameObject.Find("GlobFelipe").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtFelipe").gameObject.GetComponent<Text>().text = "¿Dónde está? !!";

            }
            else if (timeTran <= 7f)
            {
                GameObject.Find("GlobFelipe").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtFelipe").gameObject.GetComponent<Text>().text = "  ";
                GameObject.Find("GlobNicky").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = "¡Muchas maletas ustedes! ¡Lo dejaron escapar!";
            }
            else if (timeTran <= 10f)
            {
                GameObject.Find("GlobNicky").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = " ";
                GameObject.Find("GlobRob").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtRob").gameObject.GetComponent<Text>().text = " Pero a ti también se te escapó... ";

            }
            else if (timeTran <= 12f)
            {
                GameObject.Find("GlobRob").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtRob").gameObject.GetComponent<Text>().text = "  ";
                GameObject.Find("GlobNicky").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = "¡Cállense y vamos por él!";
            }
            else if (timeTran <= 14f)
            {
                dest2.y += Time.deltaTime * 3;
                GameObject.Find("capucho").GetComponent<Rigidbody2D>().MovePosition(dest2);
            }
            else if (timeTran <= 16f)
            {
                GameObject.Find("GlobNicky").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = " ";
                GameObject.Find("GlobCapucho").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtCapucho").gameObject.GetComponent<Text>().text = "¿A donde creen que van?";
            }
            else if (timeTran <= 19f)
            {

                GameObject.Find("GlobCapucho").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtCapucho").gameObject.GetComponent<Text>().text = " ";
                GameObject.Find("GlobFelipe").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtFelipe").gameObject.GetComponent<Text>().text = " ¡Uy! ¿Quién es ese?";
            }
            else if (timeTran <= 22f)
            {

                GameObject.Find("GlobFelipe").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtFelipe").gameObject.GetComponent<Text>().text = " ";
                GameObject.Find("GlobNicky").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = " Eeeh... ¡No, no vamos para ningún lado!";
            }
        }
        else if (Application.loadedLevelName == "Patio")
        {
            sound.clip = Resources.Load("sonpatio") as AudioClip;
            if (timeTran <= 1f)
            {
                sound.Play();
                GameObject.Find("GlobPatio").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtPatio").gameObject.GetComponent<Text>().text = "  ";

            }
            else if (timeTran <= 3f)
            {
                dest3.x -= Time.deltaTime * 3;
                GameObject.Find("PlayPat").GetComponent<Rigidbody2D>().MovePosition(dest3);
            }
            else if(timeTran<=5f)
            {
                GameObject.Find("PlayPat").GetComponent<Animator>().SetTrigger("StopWalkMan");
                GameObject.Find("PlayPat").GetComponent<Animator>().SetTrigger("BeginBlinkMan");
            }
            else if (timeTran <= 8f)
            {
                GameObject.Find("GlobPatio").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtPatio").gameObject.GetComponent<Text>().text = " ... El estudiante sancionado esta semana será Pablo ... ";
            }
            else if (timeTran <= 9f)
            {
                GameObject.Find("GlobPatio").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtPatio").gameObject.GetComponent<Text>().text = "  ";

            }
            else if (timeTran <= 12f)
            {
                GameObject.Find("GlobPatio").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtPatio").gameObject.GetComponent<Text>().text = " .. Desobedece las leyes del colegio en su vestimenta y la forma en que contesta a sus maestros.. ";
                GameObject.Find("PlayPat").GetComponent<Animator>().SetTrigger("BeginBlinkMan");
            }
            else if (timeTran <= 13f)
            {
                GameObject.Find("GlobPatio").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtPatio").gameObject.GetComponent<Text>().text = "  ";

            }
            else if (timeTran <= 16f)
            {
                GameObject.Find("GlobPatio").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtPatio").gameObject.GetComponent<Text>().text = " ..  ¡Estos pantalones no son decentes! deben estar limpios e impecables... ";
            }
            else if (timeTran <= 17f)
            {
                GameObject.Find("GlobPatio").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtPatio").gameObject.GetComponent<Text>().text = "  ";

            }
            else if (timeTran <= 20f)
            {
                GameObject.Find("GlobPatio").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtPatio").gameObject.GetComponent<Text>().text = " ... Tiene los zapatos sucios y no decir nada de la camisa. Usted joven ¡es una vergüenza!... ";
                GameObject.Find("PlayPat").GetComponent<Animator>().SetTrigger("BeginBlinkMan");
            }
            else if (timeTran <= 21f)
            {
                GameObject.Find("GlobPatio").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtPatio").gameObject.GetComponent<Text>().text = "  ";

            }
            else if (timeTran <= 22f)
            {
                GameObject.Find("GlobPatio").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtPatio").gameObject.GetComponent<Text>().text = " ¡¡Sigan este ejemplo y todos serán sancionados la otra semana!! ";
            }

        }
        else if (Application.loadedLevelName == "Profesores")
        {            
            if (timeTran <= 5f)
            {
                sonasc.Play();
                GameObject.Find("globasc1").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Txtasc1").gameObject.GetComponent<Text>().text = "  ";
                GameObject.Find("globasc2").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Txtasc2").gameObject.GetComponent<Text>().text = "  ";

            }
            else if (timeTran <= 8f)
            {                
                GameObject.Find("globasc1").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Txtasc1").gameObject.GetComponent<Text>().text = " !!! ";
            }
            else if (timeTran <= 12f)
            {
                GameObject.Find("globasc1").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Txtasc1").gameObject.GetComponent<Text>().text = "  ";
            }
            else if (timeTran <= 14f)
            {
                GameObject.Find("globasc1").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Txtasc1").gameObject.GetComponent<Text>().text = " mmm ... y a que piso vamos?? ";
            }
            else if (timeTran <= 17f)
            {
                GameObject.Find("globasc1").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Txtasc1").gameObject.GetComponent<Text>().text = "  ";
            }
            else if (timeTran <= 19f)
            {
                GameObject.Find("globasc2").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Txtasc2").gameObject.GetComponent<Text>().text = "... al 18 ... obvio ";
            }
            else if (timeTran <= 22f)
            {
                GameObject.Find("globasc2").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Txtasc2").gameObject.GetComponent<Text>().text = "  ";
            }
        }

        if (Application.loadedLevelName == "Skatepark")
        {
            sound.clip = Resources.Load("sonskate") as AudioClip;
            if (timeTran <= 0.5f)
            {
                sound.Play();
            }
            if (timeTran <= 2f)
            {
                destSkt.x -= Time.deltaTime * 4;
                GameObject.Find("PlayerSkt").GetComponent<Rigidbody2D>().MovePosition(destSkt);
            }
            else if (timeTran <= 4f)
            {
                GameObject.Find("PlayerSkt").GetComponent<Animator>().SetTrigger("StopWalkMan");                
                GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = " ¿ ?";                

            }

            else if (timeTran <= 8f)
            {
                GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = " ";
                GameObject.Find("globoplayer").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TextP").gameObject.GetComponent<Text>().text = "¿Nicky, por qué siempre quieren saltarse las reglas?.. En 10 minutos debemos abandonar los parques!";

            }
            else if (timeTran <= 10f)
            {
                GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = "¿Cuáles reglas? ";
                GameObject.Find("globoplayer").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TextP").gameObject.GetComponent<Text>().text = " ";
            }
            else if (timeTran <= 13f)
            {
                GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = " ";
                GameObject.Find("globoplayer").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TextP").gameObject.GetComponent<Text>().text = "Sabes que desde que desapareció el niño estamos en una situación complicada, y los residentes del barrio decidieron tomar precauciones esta semana...";
            }
            else if (timeTran <= 17f)
            {
                GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = " ";
                GameObject.Find("globoplayer").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TextP").gameObject.GetComponent<Text>().text = "... entre ellas, no transitar en  los lugares abandonados ¡como esta pista!";
            }
            else if (timeTran <= 20f)
            {

                GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = "!Yo hago las reglas, yo las puedo evadir cuando quiera¡ Tendremos que resolver esto patinando!  ";
                GameObject.Find("globoplayer").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TextP").gameObject.GetComponent<Text>().text = " ";
            }
            else if (timeTran <= 22f)
            {
                GameObject.Find("globNicky").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("TxtNicky").gameObject.GetComponent<Text>().text = " ";
                GameObject.Find("globo2").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Text2").gameObject.GetComponent<Text>().text = "Si ganamos se van.... ";
            }
            else if (timeTran <= 24f)
            {
                GameObject.Find("globo2").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Text2").gameObject.GetComponent<Text>().text = " ";
                GameObject.Find("globo3").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Text3").gameObject.GetComponent<Text>().text = "... Si perdemos nos vamos.";
                sound.Stop();
            }
            else if (timeTran == 24) timeTran = 0;
        }

     }
}
