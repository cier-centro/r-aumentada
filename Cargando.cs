using UnityEngine;
using System.Collections;

public class Cargando : MonoBehaviour {

    private float timeLoad;

    // Use this for initialization
    void Start()
    {
        timeLoad = 0f;
    }

    void LateUpdate()
    {
        timeLoad += Time.deltaTime;
        if (timeLoad >= 2f) Application.LoadLevel(3);

    }
}
