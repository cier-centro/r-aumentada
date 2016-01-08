using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bonus : Scenario {

	private AudioSource bonusSound;
	private bool finish = false;

	void Start()
	{
		bonusSound = gameObject.AddComponent<AudioSource> ();
		bonusSound.clip = Resources.Load ("success") as AudioClip;
		bonusSound.loop = false;
	}

	public override void Put()
	{
		base.Put ();
		this.tag = "Bonus";
		sc.sortingLayerName = "Game";
		sc.sortingOrder = 1;
		Instantiate (this, new Vector3 (this.posX, this.posY, 0f), Quaternion.identity);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		this.gameObject.transform.position = new Vector2(200f, 200f);
		if (!bonusSound.isPlaying)
		{
			bonusSound.Play();
			finish = true;
		}
		GeneralGameManager.score++;
		GameObject.FindGameObjectWithTag("Score").gameObject.GetComponent<Text>().text = GeneralGameManager.score.ToString();
	}

	void FixedUpdate()
	{
		if (finish && !bonusSound.isPlaying)
			Destroy (this.gameObject);
	}
}
