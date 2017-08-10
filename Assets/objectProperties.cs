using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectProperties : MonoBehaviour {

	public bool setHandHeld;
	public float setLikesPerSecond;

	public class properties {
		public bool handHeld;
		public float likesPerSecond;

		public properties(bool hand,float lps){
			handHeld = hand;
			likesPerSecond = lps;
		}
	}

	public properties thisObjProperties;

	// Use this for initialization
	void Start () {
		thisObjProperties = new properties (setHandHeld,setLikesPerSecond);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
