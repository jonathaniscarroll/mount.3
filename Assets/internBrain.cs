using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class internBrain : MonoBehaviour {

	public Dictionary<string,List<GameObject>> memory;

	// Use this for initialization
	void Start () {
		memory = new Dictionary<string,List<GameObject>> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other){
		if (memory.ContainsKey (other.gameObject.tag)) {
			//check if intern knows object type is in cubicle
			memory[other.gameObject.tag].Add(other.gameObject);
			Debug.Log ("Adding object" + other.gameObject.tag);
		} else {
			//intern seeing this objectType for first time
			memory.Add(other.gameObject.tag,new List<GameObject>());
			memory [other.gameObject.tag].Add (other.gameObject);
			Debug.Log ("Adding object" + other.gameObject.tag);
		}
	}
}
