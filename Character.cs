using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class Character : Scenario {

	public bool run;
	protected BoxCollider2D coll;
	protected Rigidbody2D rigidPlayer;
	protected Animator anim;
	private AudioSource walkSound;
	private AudioSource jumpSound;
	private bool isBlinking;
	
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
		run = false;
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
		float speed;
		if (run) 
		{
			speed = 300f;
			anim.SetFloat("Vel", 2f);
		} 
		else 
		{
			speed = 150f;
			anim.SetFloat("Vel", 1f);
		}
		anim.SetTrigger ("BeginWalkMan");
		if (!walkSound.isPlaying)
			walkSound.Play ();
		if (direction == "Right")
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
		run = false;
	}
	
	public void StopWalk()
	{
		rigidPlayer.velocity = new Vector2 (0f, rigidPlayer.velocity.y);
		anim.SetTrigger ("StopWalkMan");
		walkSound.Stop ();
		if (!isBlinking)
			StartCoroutine (Blink ());
	}
	
	public void Jump()
	{
		float force;
		if (run)
			force = 1.4f;
		else
			force = 1.0f;
		if (!jumpSound.isPlaying)
			jumpSound.Play ();
		anim.SetTrigger ("BeginJumpMan");
		rigidPlayer.AddRelativeForce (Vector3.up * 2.2f * force, ForceMode2D.Impulse);
		run = false;
	}
	
	public bool isGround()
	{
		if (gameObject.transform.position.y - gameObject.GetComponent<Renderer>().bounds.size.y / 2f <= GameObject.FindGameObjectWithTag ("Floor").gameObject.transform.position.y + 
		    GameObject.FindGameObjectWithTag ("Floor").gameObject.GetComponent<BoxCollider2D> ().bounds.size.y / 2f + 0.02f)
			return true;
		else
			return false;
	}

	public IEnumerator Blink()
	{
		isBlinking = true;
		while (!Input.GetMouseButton(0)) 
		{
			float rnd = Random.Range (0f, 1f);
			if (rnd >= 0.8)
				anim.SetTrigger ("BeginBlinkMan");
			else
				anim.SetTrigger ("StopWalkMan");
			yield return new WaitForSeconds (1);
		}
		isBlinking = false;
	}
}