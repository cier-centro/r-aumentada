using UnityEngine;
using System.Collections;

public class ControlJuegoBib : MonoBehaviour {

    public GameObject SalidaBib;
    public string imgBib, img2Bib;
    private Camera camera;

    void Start()
    {
        ProfeMoveBib.speed = 0.4f;
//#if UNITY_EDITOR
	//	Application.LoadLevel(5);
//#endif
        camera = Camera.main;//Carga la camara principal
    }

    void Update()
    {
        Vector3 posClick = Input.mousePosition;
        if (PersoneroBib.pilladoBib)
        {           
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(imgBib);
            StartCoroutine(Mostrar());           
        }
        if (PuertaBib.fin)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            transform.position = new Vector2(-34f, 61f);
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(img2Bib);            
        }
    }


    IEnumerator Mostrar()
    {
        yield return new WaitForSeconds(4);
        GetComponent<SpriteRenderer>().enabled = false;
        PersoneroBib.sonfon.PlayDelayed(10f);
    }


}
