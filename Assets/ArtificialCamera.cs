using UnityEngine;
using System.Collections;

public class ArtificialCamera : MonoBehaviour {
	Vector3 comp;
	//public GameObject virtualCamera;
	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
		if (Input.gyro.enabled  == false) {

		}

	}

	// Update is called once per frame
	void Update () {
		Quaternion rotation = new Quaternion();
		Vector3 angles = Input.gyro.attitude.eulerAngles;
		rotation.eulerAngles = new Vector3(-angles.x, -angles.y, angles.z);
		transform.rotation = rotation;
	}

}