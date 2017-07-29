using UnityEngine;
using System.Collections;

public class faceCamera : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3 (-90,45,0);
	}
}
