using UnityEngine;
using System.Collections;

public class saveItems : MonoBehaviour {

	public GameObject intern;
	public itemLvDetect topLevelToSave;
	public itemLvVars itemLevelToCheck;


	// Use this for initialization
	void Start () {
		topLevelToSave = intern.GetComponent<itemLvDetect>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider col){
		itemLevelToCheck = col.GetComponent<itemLvVars>();
		//Debug.Log("THE " + itemLevelToCheck.itemLevel + " ITEM FELL");
		if(col.tag == "chair"){
			if(itemLevelToCheck.itemLevel >= topLevelToSave.topChairLevel){
				Debug.Log("SAVE IT!");
			} else {
				Debug.Log("DESTROY");
			}
		}
	}
}
