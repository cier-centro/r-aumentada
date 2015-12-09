using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Camara : MonoBehaviour {

	public GameObject player;
	public GameObject background;
	private Camera cam;
	private float minX;
	private float maxX;
	private float minY;
	private float maxY;
	private float camMax;
	private float camMin;
	private float camMaxY;
	private float camMinY;
	public static float delayCamX;
	public static float delayCamY;
	private Background bg;
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag ("Player");
		cam = GetComponent<Camera> ();
		delayCamX = cam.ScreenToWorldPoint (new Vector3 ((float)cam.pixelWidth, 0f, 0f)).x;
		delayCamY = cam.ScreenToWorldPoint (new Vector3 (0f, (float)cam.pixelHeight, 0f)).y;
		bg = background.GetComponent<Background> ();
		minX = bg.PosX - bg.ImageSize.x / 2f;
		maxX = minX + bg.ImageSize.x * bg.Size;
		minY = bg.PosY - bg.ImageSize.y / 2f;
		maxY = minY + bg.ImageSize.y * bg.Size;
		camMax = maxX - delayCamX;
		camMin = minX + delayCamX;
		camMaxY = maxY - delayCamY;
		camMinY = minY + delayCamY;
	}

	public float GetminX()
	{
		return minX;
	}

	public float GetmaxX()
	{
		return maxX;
	}

	int Limits ()
	{
		if (player.transform.position.x < camMin) 
		{
			if (player.transform.position.y > camMaxY)
				return 1;
			else if (player.transform.position.y < camMinY)
				return 6;
			else
				return 4;
		} 
		else if (player.transform.position.x > camMax) 
		{
			if (player.transform.position.y > camMaxY)
				return 3;
			else if (player.transform.position.y < camMinY)
				return 8;
			else
				return 5;

		} 
		else 
		{
			if (player.transform.position.y > camMaxY)
				return 2;
			else if (player.transform.position.y < camMinY)
				return 7;
			else
				return 0;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {

		if (Limits () == 1)
			transform.position = new Vector3 (camMin, camMaxY, -10f);
		else if (Limits () == 2)
			transform.position = new Vector3 (player.transform.position.x, camMaxY, -10f);
		else if (Limits() == 3)
			transform.position = new Vector3 (camMax, camMaxY, -10f);
		else if (Limits() == 4)
			transform.position = new Vector3 (camMin, player.transform.position.y, -10f);
		else if (Limits() == 5)
			transform.position = new Vector3 (camMax, player.transform.position.y, -10f);
		else if (Limits() == 6)
			transform.position = new Vector3 (camMin, camMinY, -10f);
		else if (Limits() == 7)
			transform.position = new Vector3 (player.transform.position.x, camMinY, -10f);
		else if (Limits() == 8)
			transform.position = new Vector3 (camMax, camMinY, -10f);
		else
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10f);
	}
}
