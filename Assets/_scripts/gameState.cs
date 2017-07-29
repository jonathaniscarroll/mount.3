using UnityEngine;
using System.Collections;

public class gameState : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static public void getState(int state) {
		if (state == 0) {
			//1 box in the warehouse
			warehouse.stockWarehouse(5);
		}
	}
}
