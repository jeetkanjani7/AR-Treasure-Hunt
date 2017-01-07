using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ClueScript : MonoBehaviour {

	public Text buttonText;
	public GameObject clue_panel;
	void Start () {

		clue_panel.gameObject.SetActive (false);
		buttonText.text = "hello!";
	}
	public void Button_Click()
	{
		
		if (clue_panel.activeSelf==false) {
			
			clue_panel.gameObject.SetActive (true);
			buttonText.text="CLUE ABOVE";
		}
		else 
		{
			clue_panel.gameObject.SetActive (false);
			buttonText.text="";

		}
	}

}
