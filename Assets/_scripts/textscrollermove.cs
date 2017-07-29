using UnityEngine;
using System.Collections;

public class textscrollermove : MonoBehaviour {

	public GameObject starttext;
	//public GameObject endtext;
	public int speed;

	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-0.05f, 0, 0));
		//rb.AddForce(speed,0,0,ForceMode.Force);
		if(transform.position.x <= -10.0f){
			transform.position = starttext.transform.position;
		}
	}
}
