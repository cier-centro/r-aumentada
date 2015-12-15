using UnityEngine;
using System.Collections;
//public enum Dir_Arma { Derecha, Izquierda }

public class Character : Scenario {
	
	protected BoxCollider2D coll;
	protected Rigidbody2D rigidPlayer;
	protected Animator anim;
	private AudioSource walkSound;
	private AudioSource jumpSound;
	
	public virtual void Start()
	{
		anim = gameObject.GetComponent<Animator> ();
		rigidPlayer = gameObject.GetComponent<Rigidbody2D> ();
		coll = gameObject.GetComponent<BoxCollider2D> ();
		walkSound = gameObject.AddComponent<AudioSource> ();
		jumpSound = gameObject.AddComponent<AudioSource> ();
		walkSound.clip = Resources.Load ("walking_sound") as AudioClip;
		jumpSound.clip = Resources.Load ("salto") as AudioClip;
		walkSound.loop = true;
		jumpSound.loop = false;
	}
	
	public override void Put()
	{
		base.Put ();
		sc.sortingLayerName = "Game";
		coll = gameObject.GetComponent<BoxCollider2D> ();
		coll.size = this.imageSize / this.size;
		coll.offset = Vector2.zero;
	}
	
	public void Move(string direction)
	{
		float speed = 150f;
		anim.SetTrigger ("BeginWalkMan");
		if (!walkSound.isPlaying)
			walkSound.Play ();
		if (direction == "right")
		{
			gameObject.transform.localScale = new Vector3 (1, 1, 1);
			speed = Mathf.Abs(speed);
		}
		else
		{
			gameObject.transform.localScale = new Vector3 (-1, 1, 1);
			speed = -Mathf.Abs(speed);
		}
		rigidPlayer.velocity = new Vector2 (speed * Time.deltaTime, rigidPlayer.velocity.y);
		this.posX = transform.position.x;
	}
	
	public void StopWalk()
	{
		rigidPlayer.velocity = new Vector2 (0f, rigidPlayer.velocity.y);
		anim.SetTrigger ("StopWalkMan");
		walkSound.Stop ();
	}
	
	public void Jump()
	{
		if (!jumpSound.isPlaying)
			jumpSound.Play ();
		rigidPlayer.AddRelativeForce (Vector3.up * 8f, ForceMode2D.Impulse);
	}
	
	public bool isGround()
	{
		if (gameObject.transform.position.y - gameObject.GetComponent<Renderer>().bounds.size.y / 2f <= GameObject.FindGameObjectWithTag ("Floor").gameObject.transform.position.y + 
		    GameObject.FindGameObjectWithTag ("Floor").gameObject.GetComponent<BoxCollider2D> ().bounds.size.y / 2f + 0.02f)
			return true;
		else
			return false;
	}
}