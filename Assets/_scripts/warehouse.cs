using UnityEngine;
using System.Collections;
using System.Collections.Generic; //this is necessary for using lists

public class warehouse : MonoBehaviour {

	public objectDictionary objDict;

	public static List<GameObject> cubObjs;

	public static GameObject wareHouseObj;

	// Use this for initialization
	void Start () {
		objDict = GameObject.FindGameObjectWithTag ("GameController").GetComponent<objectDictionary>();
		cubObjs = objDict.cubicleObjects;
		wareHouseObj = gameObject;
		stockWarehouse (5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void stockWarehouse(int stock) {
		Vector3 objPos = new Vector3(-5,2,0);
		GameObject currentObj;
		for (int i = 0; i <= stock; i++) {
			objPos += new Vector3(2.5f,0,0);
			int x = Random.Range (0, cubObjs.Count);
//			currentObj = (GameObject)Instantiate (cubObjs[x],Vector3.zero,Quaternion.Euler (145, -45, 180),wareHouseObj.transform) as GameObject;
//			currentObj.transform.localPosition = objPos;
//			currentObj.GetComponent<Rigidbody> ().isKinematic = true;
//			currentObj.GetComponent<BoxCollider> ().isTrigger = true;
//			warehouseObj whobj = currentObj.AddComponent<warehouseObj> ();
//			whobj.cost = x * 10;
		}
	}


}
