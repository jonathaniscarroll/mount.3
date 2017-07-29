using UnityEngine;
using System.Collections;

public class moveCamera : MonoBehaviour {


	public float transitionSpeed;

	public static Vector3 cameraStart;


	// Use this for initialization
	void Start () {
		cameraStart = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void moveCam(){
		float speed = transitionSpeed * Time.deltaTime;
		Vector3 cam = transform.position;
		Debug.Log (cam);
		Vector3 warehousePos;
		if (cam.y < 40) {
			warehousePos = cam + new Vector3 (0, 20, 0);
		} else {
			warehousePos = cam - new Vector3 (0, 20, 0);
		}

		if (cam.y != warehousePos.y) {
			transform.position = warehousePos;
		}
	}

	public static void followObject(GameObject obj){
		Camera cam = Camera.main;
		while (cam.transform.position.y > cameraStart.y) {
			cam.transform.position = Vector3.MoveTowards (cam.transform.position, cameraStart, Time.deltaTime);
//			cam.transform.position = new Vector3 (cam.transform.position.x, obj.transform.position.y, cam.transform.position.z);
		}
	}
}
