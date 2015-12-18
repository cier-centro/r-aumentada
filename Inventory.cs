using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	private Button btn;
	// Use this for initialization
	void Start () 
	{
		btn = GetComponent<Button> ();
		btn.interactable = false;
	}

	public void InventoryOn()
	{
		btn.interactable = true;
		GameObject.FindGameObjectWithTag ("GameController").gameObject.GetComponent<GameManager> ().RemoveButtons ();
	}

	public void InventoryOff()
	{
		ButtonUI.showUI = false;
		btn.interactable = false;
	}
}
