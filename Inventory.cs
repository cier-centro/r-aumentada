using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	private Button btn;
	private ColorBlock btnCol;
	// Use this for initialization
	void Start () 
	{
		btn = GetComponent<Button> ();
		btn.interactable = false;
	}

	public void InventoryOn()
	{
		if ((this.name == "Paper" && GeneralGameManager.paper) || (this.name == "Gun" && GeneralGameManager.gun) || 
		    (this.name == "Hammer" && GeneralGameManager.hammer) || (this.name == "Key" && GeneralGameManager.key || this.name == "Out"))
			btn.interactable = true;

		GameObject.FindGameObjectWithTag ("GameController").gameObject.GetComponent<GameManager> ().RemoveButtons ();
	}

	public void InventoryOff()
	{
		ButtonUI.showUI = false;
		btn.interactable = false;
		if (GameObject.FindWithTag ("Left") == null)
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ().PutMove ();
	}

	public void Appear(bool wantAppear)
	{
		btn = GetComponent<Button> ();
		btnCol = btn.colors;
		btnCol.fadeDuration = 0.5f;
		if (wantAppear) 
		{
			btnCol.normalColor = new Color(255f, 255f, 255f, 1f);
			btnCol.highlightedColor = new Color(255f, 255f, 255f, 1f);
			btnCol.pressedColor = new Color(255f, 255f, 255f, 1f);
			btn.colors = btnCol;
			btn.interactable = true;
		} 
		else 
		{
			btn.interactable = false;
			btnCol.normalColor = new Color(255f, 255f, 255f, 0f);
			btnCol.highlightedColor = new Color(255f, 255f, 255f, 0f);
			btnCol.pressedColor = new Color(255f, 255f, 255f, 0f);
			btn.colors = btnCol;
		}
	}
}
