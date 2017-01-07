using UnityEngine;
using System.Collections;
using  UnityEngine.UI;
using System;
/** Accessing the GPS Data over JNI calls
 *  Please check the Java sources under Plugins/Android
 * */

public class GPSManager : MonoBehaviour {

	public Text Clue,;
	private RaycastHit hit;
	public Camera artificial;
	Ray ray;




	public GameObject tresure_box1;
	public Text latText,longText,camX,camY,travelText;

	double dest_lat=26.9337493;
	double dest_lon=75.9234617;

	public double R=6378.137,gpslat1,gpslong1,travel;
	//public float a,b,c,d;
	public double[] lat_val={26.9337493,26.933756,26.93326}; 
	public double[] long_val={75.9234617,75.923170,75.92313};
	public static int count=0;

	//float locations=new float[10][1];
	//	static string speedMessage;
	static float dlat,dlon;


	public AndroidJavaClass gpsActivityJavaClass;

/*	public double havesin(float dlat,float dlon,float lat1,float lon1,float lat2,float lon2)
		{
			a = (float)(Mathf.Sin (dlat / 2) * Mathf.Sin (dlat / 2) + Mathf.Cos (lat1 * Mathf.PI / 180) * Mathf.Cos (lat2 * Mathf.PI / 180) * Mathf.Sin (dlat / 2) * Mathf.Sin (dlat / 2));
			c = (float)(Mathf.Atan2 (Mathf.Sqrt (a), Mathf.Sqrt (1 - a)));
			d = (float)(c * R*100);
			return d;
		}*/
	/*
	public void nextLevel(string str)
	{
		if (str == "tresure_box1") {
			tresure_box1.gameObject.SetActive (false);
			tresure_box2.gameObject.SetActive (true);
			Clue.text = "Temple";
			count++;
		}
		else if (str == "tresure_box2") {
			tresure_box2.gameObject.SetActive (false);
			tresure_box3.gameObject.SetActive (true);
			Clue.text = "Temple";
			count++;
		}
		else if (str == "tresure_box3") {
			tresure_box3.gameObject.SetActive (false);
			//tresure_box3.gameObject.setActive (true);
			Clue.text = "YOU WIN!!!!!!!!!!!";
			//count++;
		}
	}

	*/
	void Start () {
		
		//Clue.text = "hello!";
		latText.text = "not init";
		AndroidJNI.AttachCurrentThread();
		try{
			gpsActivityJavaClass = new AndroidJavaClass("com.LNMIIT.TreasureHunt.Communicate.java");
		}
		catch {
			latText.text = "nullllll";
		}

		foreach (Camera cam in Camera.allCameras) {
			if (cam.name == "Artificial Camera") {
				artificial = cam;
			}

		}
		if (artificial == null) {
			Clue.text = "Not init";
		}
	}

	void Update() {
		gpsActivityJavaClass.CallStatic<>("init");

		gpslat1 = gpsActivityJavaClass.CallStatic<double>("getlatitude");
		gpslong1 = gpsActivityJavaClass.CallStatic<double>("getlongitude");
		camX.text = Input.location.lastData.latitude;
		camY.text=Input.location.lastData.longitude;


		latText.text = gpslat1.ToString () + "";
		longText.text = gpslong1.ToString () + "";

		if (gpslat1 != 0) {
			Input.location.lastData.horizontalAccuracy = 2;
			Input.location.lastData.verticalAccuracy = 2;


			//	gpslat2= gpsActivityJavaClass.CallStatic<double>("getlat");
			//	gpslong2= gpsActivityJav aClass.CallStatic<double>("getlong");
			dlat = (float)((gpslat1 - lat_val[count]) * 1000);
			dlon = (float)((gpslong1 - long_val[count]) * 10000);
			Vector3 newpos = new Vector3 ((float)gpslat1 * 1000, (float)gpslong1 * 1000, -4.0f);
			//	VirtualCamera.transform.position = newpos;
			//	travel=havesin(dlat,dlon,(float)gpslat1,(float)gpslong1,(float)OAT_lat,(float)OAT_lon);

			travel = Mathf.Sqrt (dlat * dlat + dlon * dlon);
			travelText.text = travel.ToString ();
			if (travel > 4) {
				tresure_box1.SetActive (false);
			} 
			else {
				tresure_box1.SetActive (true);
			}
			/*	rayAQ = artificial.ScreenPointToRay (Input.GetTouch (0).position);
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {

					nextLevel (hit.transform.name);
						

				} else {
					Clue.text = "Treasure nearby";
				}
					*/

		//	camX.text = artificial.transform.position.x.ToString ();
		//	camY.text = artificial.transform.position.y.ToString();
		}
		else
		{
			latText.text = "no location";

		}
	}
}