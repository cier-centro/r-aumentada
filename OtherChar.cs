using UnityEngine;
using System.Collections;

public class OtherChar : Character {

	private bool follow;
	private float speed = 2f;

	public override void Start () 
	{
		base.Start ();
		coll.isTrigger = true;
		rigidPlayer.isKinematic = true;
	}
	
	public override void Put()
	{
		base.Put ();
		sc.gameObject.layer = 9;
		sc.sortingOrder = 2;
		this.tag = "Other";
		Instantiate (this, new Vector3 (this.posX, this.posY, 0f), Quaternion.identity);
	}

	public IEnumerator Move(float posFinal)
	{
		float distance = Mathf.Abs(posFinal - rigidPlayer.position.x);
		
		while (distance > 0.1f) 
		{
			//animator.SetTrigger("BeginWalk");
			if (posFinal > rigidPlayer.position.x)
			{
				this.gameObject.transform.localScale = new Vector3 (1, 1, 1);
				this.speed = Mathf.Abs(speed);
			}
			else
			{
				this.gameObject.transform.localScale = new Vector3 (-1, 1, 1);
				speed = -Mathf.Abs(speed);
			}
			rigidPlayer.velocity = new Vector2(speed, rigidPlayer.velocity.y);
			distance = Mathf.Abs(posFinal - rigidPlayer.position.x);
			if (distance < 0.01f)
			{
				//animator.SetTrigger ("StopWalk");
				yield return false;
			}
			yield return true;
		}
		//animator.SetTrigger ("StopWalk");
	}
}
