using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	private Button btn;
	private ColorBlock btnCol;
	private float time;
	// Use this for initialization
	void Awake ()
	{
		if (this.name == "Out") 
		{
			btn = GetComponent<Button> ();
			btnCol = btn.colors;
			btnCol.normalColor = new Color(0f, 0f, 0f, 1f);
			btnCol.highlightedColor = new Color(0f, 0f, 0f, 1f);
			btnCol.pressedColor = new Color(0f, 0f, 0f, 1f);
			btn.colors = btnCol;
			btn.interactable = true;
		}
	}

	void Start () 
	{
		time = 0f;
		btn = GetComponent<Button> ();
		if (this.name != "Out")
			btn.interactable = false;
	}

	public void InventoryOn()
	{
		if ((this.name == "Paper" && GeneralGameManager.paper) || (this.name == "Gun" && GeneralGameManager.gun) || 
		    (this.name == "Hammer" && GeneralGameManager.hammer) || (this.name == "Key" && GeneralGameManager.key) || this.name == "Out")
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

	public void fadeoff ()
	{
		btn = GetComponent<Button> ();
		btnCol = btn.colors;
		btnCol.fadeDuration = 1f;
		btnCol.normalColor = new Color(0f, 0f, 0f, 1f);
		btnCol.highlightedColor = new Color(0f, 0f, 0f, 1f);
		btnCol.pressedColor = new Color(0f, 0f, 0f, 1f);
		btn.colors = btnCol;
		btn.interactable = true;
	}

	public void fadein ()
	{
		btn = GetComponent<Button> ();
		btnCol = btn.colors;
		btn.interactable = true;
		btnCol.fadeDuration = 1f;
		btnCol.disabledColor = new Color (0f, 0f, 0f, 0f);
		btn.interactable = false;
		btn.colors = btnCol;
	}

	void FixedUpdate()
	{
		time += Time.deltaTime;
		if (time <= 2 * Time.deltaTime && (this.name == "Out" || this.name == "Out2"))
			this.fadein ();
	}
}
