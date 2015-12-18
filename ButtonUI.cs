using UnityEngine;
using System.Collections;

public class ButtonUI : MonoBehaviour {

	public static bool showUI;
	private RectTransform rectangle;

	// Use this for initialization
	void Start () 
	{
		rectangle = gameObject.GetComponent<RectTransform> ();
		showUI = false;
		StartCoroutine (ShowButton (showUI));
	}

	private IEnumerator ShowButton (bool show)
	{
		int sign = 0;
		float limit = 0f;
		if (show) 
		{
			sign = -1;
			limit = 2.755f;
		} 
		else if (!show && !showUI)
		{
			limit = 6.2f;
			sign = 1;
		}

		while (Mathf.Abs(Camera.main.ScreenToWorldPoint(rectangle.position).y - limit) >= 0.5f) 
		{
			this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + Time.deltaTime * 150f * sign);
			yield return null;
		}
	}

	public void FixedUI()
	{
		showUI = true;
	}

	void LateUpdate()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y >= 2.5f)
				StartCoroutine(ShowButton(true));
			else
				StartCoroutine(ShowButton(false));
		}
	}
}
