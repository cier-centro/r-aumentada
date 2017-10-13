using UnityEngine;
using System.Collections;

public class CamaraBib : MonoBehaviour {

    public GameObject personeroBib;

    public float x = 0.0f;
    public float y = 0.0f;


    void Start()
    {
    }


    void Update()
    {

        if (Camera.main.orthographicSize <= 15f)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize + 0.1f;
        }
        x = personeroBib.gameObject.transform.position.x;
        y = personeroBib.gameObject.transform.position.y;
        transform.position = new Vector2(x, y);
    }
    
}
