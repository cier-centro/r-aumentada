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
		if (time >= 5f) 
			GameObject.Find ("Out2").GetComponent<Inventory> ().fadeoff ();
		if (time > 8f) 
		{
			GeneralGameManager.advance++;
			if (togo == 8)//TODO
				GeneralGameManager.advance = 20;
			Application.LoadLevel (togo);
		}
	}
}
