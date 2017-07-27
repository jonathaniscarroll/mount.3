using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class objectQuantity : MonoBehaviour {

	private float objectProb;
	private GameObject cubicleObject;

	//reference the name of the script and the variable it is assigned
	public game_engine quantity; 

	//get the current quality from quality script
	public objectquality quality;

	//find the object dictionary
	public objectDictionary objectDictionary;

	private float randomX;
	private float randomZ;

	private GameObject[] findItems;

	private int x;

	// Use this for initialization
	void Start () {
		quantity = gameObject.GetComponent<game_engine>();
		quality = gameObject.GetComponent<objectquality> ();
		objectDictionary = gameObject.GetComponent<objectDictionary> ();
		x = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (quantity.timer == 0) {
			//generateObject (quantity.likes);
		}

		if(Input.GetKeyDown ( KeyCode.Space)){
			//generateObject (quantity.likes);
		}
	}

	public void generateObject(int quant){
			
		//Debug.Log ("meta yolo: " + quant);

		if (x <= quant) {

			foreach (KeyValuePair<int,GameObject> cubobj in objectDictionary.cubobjDictionary) {
				//Debug.Log ("meta meta yolo: " + quant);

				if (cubobj.Key <= quantity.likes && x <= quant) {
//					Debug.Log ("meta meta meta yolo: " + quant);
					randomX = (Mathf.Round ((Random.value * 10.0f)) - 5.0f);
					randomZ = (Mathf.Round ((Random.value * 10.0f)) - 5.0f);
//
//				if gameObject object tag exists
//					spawn likleyhood of this and this changes
					
					//findItems = GameObject.FindGameObjectsWithTag();


					Instantiate (cubobj.Value, new Vector3 (randomX, 10, randomZ), Quaternion.Euler(145,-45,180));
					x++;
					//Debug.Log ("x: " + x);
				}

			
			}
		} else {
			//Debug.Log ("DONE");
			return;
		}

//		cubicleObject = quality.currentItem;
//		objectProb = Random.Range (0f, 100f);
//		if (objectProb <= quantity.likes) {
//			Instantiate(cubicleObject, new Vector3(Random.Range (-5f, 5f), 10, Random.Range (-5f, 5f)), Quaternion.identity);
//		}
	}
}
