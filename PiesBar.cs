using UnityEngine;
using System.Collections;

public class PiesBar : MonoBehaviour 
{
    public static bool pies_pisoBar;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "PisoBar")
        {
            pies_pisoBar = true;     
        }
    }
}
