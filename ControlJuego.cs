using UnityEngine;
using System.Collections;

public class ControlJuego : MonoBehaviour {

    public GameObject Salida;
    public string img, img2;
    private Camera camera;

    void Start()
    {
        camera = Camera.main;//Carga la camara principal
		Application.LoadLevel (0);
     }
    void Update()
    {
        Vector3 posClick = Input.mousePosition;
        if (Personero.pillado)
        {           
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(img);
            StartCoroutine(Mostrar());           
        }
        if (Puerta.fin)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            transform.position = new Vector2(-34f, 61f);
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(img2);            
			Application.LoadLevel(0);
        }
    }


    IEnumerator Mostrar()
    {
        yield return new WaitForSeconds(4);
        GetComponent<SpriteRenderer>().enabled = false;
        Personero.sonfon.PlayDelayed(10f);
    }


}
