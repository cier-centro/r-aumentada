using UnityEngine;
using System.Collections;

public class Personero1 : MonoBehaviour 
{      
    
    // Use this for initialization
	void Start () 
    {
        if (this.name == "PersoneroD")
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else GetComponent<SpriteRenderer>().enabled = false; 
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        switch(RunMove.dir)
        {
            case ("arriba"):
                { 
                    if(this.name=="PersoneroUp")
                    {
                        GetComponent<SpriteRenderer>().enabled = true;
                    } 
                    else GetComponent<SpriteRenderer>().enabled = false; 
                } break;
            case ("abajo"): 
                { 
                    if(this.name=="PersoneroDwn")
                    {
                        GetComponent<SpriteRenderer>().enabled = true;
                    } 
                    else GetComponent<SpriteRenderer>().enabled = false; 
                } break;
            case ("derecha"): 
                { 
                    if(this.name=="PersoneroD")
                    {
                        GetComponent<SpriteRenderer>().enabled = true;
                    } 
                    else GetComponent<SpriteRenderer>().enabled = false; 
                } break;
            case ("izquierda"):
                { 
                    if(this.name=="PersoneroI")
                    {
                        GetComponent<SpriteRenderer>().enabled = true;
                    } 
                    else GetComponent<SpriteRenderer>().enabled = false; 
                } break;
        }
        
        GetComponent<Animator>().SetFloat("DirX", RunMove.dir2.x);
        GetComponent<Animator>().SetFloat("DirY", RunMove.dir2.y);
	}
}
