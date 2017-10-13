using UnityEngine;
using System.Collections;

public class VideoGameManager : MonoBehaviour {

	public int togo;
	private float time;
	// Update is called once per frame
	void Start ()
	{
		time = 0f;
	}

	void FixedUpdate () {
		time += Time.deltaTime;
		if (time >= 2f) //Tiempo para iniciar trancisión
			GameObject.Find ("Out2").GetComponent<Inventory> ().fadeoff ();
		if (time > 24f) //Tiempo para pasar a otra escena
		{
			GeneralGameManager.advance++;
			if (togo == 13)//8 TO DO
				GeneralGameManager.advance = 20;
			Application.LoadLevel (togo);
		}
	}
}
