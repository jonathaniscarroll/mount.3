using UnityEngine;
using System.Collections;

public class textscroller : MonoBehaviour {


	public GameObject slidingtext;
	public GameObject starttext;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.T)){
			//Instantiate(slidingtext,starttext.transform.position, Quaternion.identity);
			slidingtext.transform.position = starttext.transform.position;
		}
	}
}
