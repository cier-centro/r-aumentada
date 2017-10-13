using UnityEngine;
using System.Collections;

public class FondoSkate : MonoBehaviour {


    private float time;
    // Use this for initialization
    void Start ()
    {
        time = 0f;
    }

    void LateUpdate()
    {
        time += Time.deltaTime;
        if (time < 13.3f)
        {
            Vector2 mover = this.transform.position;
            mover.x -= 7f;
            Vector2 p = Vector2.MoveTowards(transform.position, mover, 0.4f);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        else
        {
            time = 0f;
            this.transform.position = new Vector3(179.8f, -39.5f, 0f);
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
