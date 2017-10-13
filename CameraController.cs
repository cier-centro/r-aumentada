using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	void Start ()
	{
		offset = transform.position - player.transform.position;
	}

	void LateUpdate ()
	{
		Vector3 trans= new Vector3(player.transform.position.x+offset.x, this.transform.position.y,player.transform.position.z+offset.z );
		transform.position = trans;
	}
}