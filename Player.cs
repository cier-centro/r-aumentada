﻿using UnityEngine;
using System.Collections;
//public enum Dir_Arma { Derecha, Izquierda }

public class Player : Character {
	//private GameObject[] doors;

	public Player(string image, float size, float posX, float posY)
	{
		this.size = size;
		this.image = image;
		this.posX = posX;
		this.posY = posY;
	}
	

	public override void Start()
	{
		base.Start ();
		//doors = GameObject.FindGameObjectsWithTag ("Door");
		coll.size = new Vector2(coll.size.x, 4f);
	}
	
	public override void Put()
	{
		base.Put ();
		sc.sortingOrder = 3;
		this.tag = "Player";
		Instantiate (this, new Vector3 (this.posX, this.posY, 0f), Quaternion.identity);
	}

	void FixedUpdate()
	{
		if (GameObject.FindWithTag ("Left") != null) 
		{
			/*if (Input.GetMouseButton (0)) 
			{
				if (GameObject.FindGameObjectWithTag ("Left").gameObject.GetComponent<ButtonMv> ().ClickLimits (Input.mousePosition))
					Move ("left");
				else if (GameObject.FindGameObjectWithTag ("Right").gameObject.GetComponent<ButtonMv> ().ClickLimits (Input.mousePosition))
					Move ("right");
				else
					StopWalk();
			} 
			else
				StopWalk ();

			if (Input.GetMouseButtonDown (0) && isGround ()) 
			{
				if (GameObject.FindGameObjectWithTag ("Up").gameObject.GetComponent<ButtonMv> ().ClickLimits (Input.mousePosition))
					Jump ();
			}

			for (int i = 0, k = doors.Length; i < k; i++)
			{
				if (Input.GetMouseButtonDown (0) && this.gameObject.transform.position.x >= doors[i].gameObject.transform.position.x - doors[i].gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2 &&
				    this.gameObject.transform.position.x <= doors[i].gameObject.transform.position.x + doors[i].gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2 &&
				    GameObject.FindGameObjectWithTag ("Up").gameObject.GetComponent<ButtonMv> ().ClickLimits (Input.mousePosition))
				{
					//ACA LA INSTRUCCION PARA CAMBIAR DE ESCENARIO
				}
			}*/
		}
		else
			StopWalk ();
	}
}