using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parpadeo : MonoBehaviour {
	int changeTimes=3;
	float time=0;
	Color realColor;
	void Start(){
		realColor=GetComponent<SpriteRenderer> ().color;
	}
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= 0.3 &&changeTimes>4) {
			changeTimes++;
			time = 0;
			if (GetComponent<SpriteRenderer> ().color.Equals (Color.red)) {
				GetComponent<SpriteRenderer> ().color = realColor;
			} else {
				GetComponent<SpriteRenderer> ().color = Color.red;
			}
		}
	}
}
