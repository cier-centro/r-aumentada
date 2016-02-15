using UnityEngine;
using System.Collections;
//public enum Dir_Arma { Derecha, Izquierda }

public class Player : Character {

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
	}
	
	public override void Put()
	{
		base.Put ();
		sc.sortingOrder = 6;
		this.tag = "Player";
		Instantiate (this, new Vector3 (this.posX, this.posY, 0f), Quaternion.identity);
	}

	void FixedUpdate()
	{
		if (GameObject.FindWithTag ("Left") == null) 
		{
			StopWalk ();
		}
	}
}