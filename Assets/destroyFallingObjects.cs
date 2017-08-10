using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyFallingObjects : MonoBehaviour {

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "post"){
			Destroy (other.gameObject);
		}
	}
}
