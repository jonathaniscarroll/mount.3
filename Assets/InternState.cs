using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternState : MonoBehaviour {

	public TextMesh txtM;

	public void stateState(string state){
		txtM.text = state;
	}
}
