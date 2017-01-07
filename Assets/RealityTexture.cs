using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RealityTexture : MonoBehaviour {

	void Start () {
		Renderer renderer = GetComponent<Renderer>();

		WebCamTexture webCamTexture = new WebCamTexture(WebCamTexture.devices[0].name,1280,720,30);

		renderer.material.mainTexture = webCamTexture;

		webCamTexture.Play();
		//transform.localScale = new Vector3 ( Screen.width, Screen.height,1);
	//	transform.localScale = new Vector3(1, (float)webCamTexture.height / (float)webCamTexture.width, 1);
	}

	}



