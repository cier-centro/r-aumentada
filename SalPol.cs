using UnityEngine;
using System.Collections;

public class SalPol : MonoBehaviour {

    public Camera camFinB;
    public static bool FadeFin;
    public static AudioSource sontruenoFin;
    public GameObject policiaBarFin;

    private float timeFadeFin;

	// Use this for initialization
	void Start () 
    {
        FadeFin = false;
        sontruenoFin = gameObject.AddComponent<AudioSource>();
        sontruenoFin.clip = Resources.Load("trueno") as AudioClip;
    }
	
	// Update is called once per frame
	void Update () 
    {
	    Vector3 mouse = Input.mousePosition;

	}
    bool HizoClick(Vector3 mouse)
    {
        if ((camFinB.ScreenToWorldPoint(mouse).x > (this.GetComponent<Renderer>().bounds.min.x)) &&
            (camFinB.ScreenToWorldPoint(mouse).x < (this.GetComponent<Renderer>().bounds.max.x)) &&
            (camFinB.ScreenToWorldPoint(mouse).y > (this.GetComponent<Renderer>().bounds.min.y)) &&
            (camFinB.ScreenToWorldPoint(mouse).y < (this.GetComponent<Renderer>().bounds.max.y)))
            return true;
        else
            return false;
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (this.name == "pol2" && co.name == "PlayerBarrio" && DialogBar.ctrlDiagBar == 6)
        {
            DialogBar.ctrlDiagBar = 61;
            FadeFin = true;
            timeFadeFin = 0f;
            sontruenoFin.Play();
        }
        else if (this.name=="SalidaBarrio" && co.name == "PlayerBarrio" && DialogBar.ctrlDiagBar == 94)
        {
            Application.LoadLevel("School");
        }
    }




    void LateUpdate()
    {
        timeFadeFin += Time.deltaTime;
        
            if (DialogBar.ctrlDiagBar == 61 && timeFadeFin < 0.2f)
            {
                sontruenoFin.Play();
                policiaBarFin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola1");                            
            }
            if (DialogBar.ctrlDiagBar == 61 && timeFadeFin> 0.2f && timeFadeFin < 0.4f)
            {
                policiaBarFin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola3");                            
            }

            if (DialogBar.ctrlDiagBar == 61 && timeFadeFin> 0.4f && timeFadeFin < 0.6f)
            {
                policiaBarFin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola2");
                               
            }
            if (DialogBar.ctrlDiagBar == 61 && timeFadeFin > 0.6f && timeFadeFin < 0.8f)
            {
                policiaBarFin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola3");

            }
            if (DialogBar.ctrlDiagBar == 61 && timeFadeFin > 0.8f && timeFadeFin < 1.0f)
            {
                policiaBarFin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola2");

            }
            if (DialogBar.ctrlDiagBar == 61 && timeFadeFin > 1.0f && timeFadeFin < 1.2f)
            {
                policiaBarFin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola1");

            }
            if (DialogBar.ctrlDiagBar == 61 && timeFadeFin > 1.2f && timeFadeFin < 1.4f)
            {
                policiaBarFin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola3");

            }
            if (DialogBar.ctrlDiagBar == 61 && timeFadeFin > 1.4f && timeFadeFin < 1.6f)
            {
                policiaBarFin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola1");

            }
            if (DialogBar.ctrlDiagBar == 61 && timeFadeFin > 1.6f && timeFadeFin < 1.8f)
            {
                policiaBarFin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola3");

            }
            if (DialogBar.ctrlDiagBar == 61 && timeFadeFin > 1.8f && timeFadeFin < 2.0f)
            {
                policiaBarFin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola2");

            }
            

            
            if (DialogBar.ctrlDiagBar == 61 && timeFadeFin> 2.0f && timeFadeFin < 2.2f)
            {
                policiaBarFin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("pola1");
                FadeFin = false;
                DialogBar.ctrlDiagBar = 7;  
            }                       
     }

 }
