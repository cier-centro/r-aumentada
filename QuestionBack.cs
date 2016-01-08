using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionBack : MonoBehaviour {

	public IEnumerator Appear(bool wantAppear)
	{
		float time = 0f;

		if (wantAppear) 
		{
			while (this.gameObject.GetComponent<Image>().color.a <= 1f) 
			{
				this.gameObject.GetComponent<Image> ().color = new Color (255f, 255f, 255f, time * 2f);
				time += Time.deltaTime;
				yield return null;
			}
		} 
		else 
		{
			while (this.gameObject.GetComponent<Image>().color.a >= 0f) 
			{
				this.gameObject.GetComponent<Image> ().color = new Color (255f, 255f, 255f, -time * 2f);
				time += Time.deltaTime;
				yield return null;
			}
		}
	}
}
