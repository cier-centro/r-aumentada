using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScriptPac : MonoBehaviour {

	public int high, score;

	public List<Image> lives = new List<Image>(3);

	Text txt_score;
	
	void Start () 
	{
	
	    for (int i = 0; i < 3 - GameManagerPac.lives; i++)
	    {
	        Destroy(lives[lives.Count-1]);
            lives.RemoveAt(lives.Count-1);
	    }
	}
	
	void Update () 
	{
        score = GameManagerPac.score;
		
	}


}
