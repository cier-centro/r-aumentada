using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	private Button btn;
	private ColorBlock btnCol;
	private float time;

	void Start () 
	{
		time = 0f;
		btn = GetComponent<Button> ();
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
        if (time <= 2 * Time.deltaTime && (this.name == "Out" || this.name == "Out2"))
            this.fadein();
        if (Application.loadedLevelName == "Profesores")
        {
            if (time > 4f)
            {
                GetComponent<Image>().enabled = false;
                GameObject.FindGameObjectWithTag("asc").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ascensor");
                GameObject.FindGameObjectWithTag("asc2").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.FindGameObjectWithTag("asc3").GetComponent<SpriteRenderer>().enabled = true;

            }
        }
	}
}
