using UnityEngine;
using System.Collections;

public class Pies : MonoBehaviour 
{
    public static bool pies_piso;

    void OnTriggerEnter2D(Collider2D col)
    {
		if (col.name == "Piso") {
			pies_piso = true;
		}
		
    }
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.name == "Piso") {
			pies_piso = false;
		}

	}
	void Update(){
		print (pies_piso);
	}
}
