using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System;

public class TreasureClick : MonoBehaviour {
	public Text Clue,tres_count;
	public GameObject tresure_box,player;
	public Animator box_open;
	private RaycastHit hit;
	public Camera artificial;
	Ray ray;
	public int click_count=0;
	public void start()
	{
		tres_count.text= "0";
		player = GameObject.Find ("GPSManager");
		box_open = tresure_box.gameObject.GetComponent<Animator>();
		if (box_open == null) {
			Debug.Log ("box animator not init");
		}
		else {
			Debug.Log ("box animator (y)");
		}
		//box_open.enabled = false;
		foreach (Camera c in Camera.allCameras) {
			if (c.name == "Artificial Camera") {
				artificial = c;
			}
			
		}
		if (artificial == null) {
			Clue.text = "Not init";
		}
	}

	public void Update()
	{

		box_open = tresure_box.gameObject.GetComponent<Animator>();
	//	box_open.enabled = false;
		ray = artificial.ScreenPointToRay(Input.GetTouch(0).position);
		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {

			if (hit.transform.name == "tresure_box1") {
				
				box_open.enabled = true;
				Clue.text="Treasure found";
			//	if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !Animator.IsInTransition(0))
			//	{
					click_count++;
			//	}
				
			//	click_count=player.GetComponent<GPSManager> ().count++;
				tres_count.text = click_count.ToString ();
			//	StartCoroutine(Example());
				
			//	box_open.speed=-1;
			//	box_open.enabled = true;


			}
			else {
				box_open.enabled = false;
				Clue.text = "not found";
			}


		}



	}

	public void tresure_found()
	{
		box_open.enabled = false;
	}

	public void init()
	{
		box_open.enabled = false;
	}
	IEnumerator Example() {
       
        yield return new WaitForSeconds(4);
        
    }

}
