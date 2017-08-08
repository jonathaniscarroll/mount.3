using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic; //this is necessary for using lists

public class objectDictionary : MonoBehaviour {

	public List<GameObject> cubicleObjects = new List<GameObject>();

	public Dictionary<GameObject,int> cubobjDictionary;
	public Dictionary<GameObject,float> weightDictionary;

	private List<GameObject> objectList;

	public int height;


	private int objectQuant;

	// Use this for initialization
	void Start () {
//		quantity = gameObject.GetComponent<objectQuantity> ();
		cubobjDictionary = new Dictionary<GameObject,int>();
		weightDictionary = new Dictionary<GameObject,float> ();
		objectList = new List<GameObject> ();
		makeObjectDictionary ();
	}
		
	// Update is called once per frame
	void Update () {

	}


	// each object has a base like level required to spawn that item. This is called in the object quantity script
	void makeObjectDictionary(){
		int i = 1;
		int o;
		foreach(GameObject cubobj in cubicleObjects)
		{
			o = Convert.ToInt32(cubobj.transform.localScale.x);
			cubobjDictionary.Add (cubobj,o);
//			Debug.Log (o + ": " + cubobj.name);
		}
		populateCubicles (cubobjDictionary);
	}

	public void populateCubicles(Dictionary<GameObject,int> objects){

		List<Vector2> positions = new List<Vector2> ();
		int x = -1; int z = -1;
//		for(int i = -1;i<=1;i++){
			for (x = -1;x<=1;x++){
				positions.Add (new Vector2 (x, 1));
			}
			for (x = -1; x <= 1; x++) {
				positions.Add (new Vector2 (x, 0));
			}
			for (x = -1; x <= 1; x++) {
				positions.Add (new Vector2 (x, -1));
			}

//		}
//		y = 0;
		GameObject randObj;
		for(int y = 0;y<positions.Count;y++){
			randObj = cubicleObjects [UnityEngine.Random.Range (0, cubicleObjects.Count)];
			if (objects [randObj] + y <= positions.Count) {
				Instantiate (randObj, new Vector3(positions [y].x, height, positions [y].y) * 3,Quaternion.identity);
				y += objects [randObj];
			} else {
				y++;
			}
		}
//		foreach (Vector2 vect in positions){
//			Debug.Log (vect);
//
//			Instantiate (cubicleObjects [UnityEngine.Random.Range (0, cubicleObjects.Count)], vect, Quaternion.identity);
//		}
//		
//		objectQuant = Random.Range(0, (likes/10));
//
//		//Debug.Log ("Number of objects: " + objectQuant);
//		int obj = 0;
//		int rand;
//		for(int i = 0; i <= objectQuant; i++)
//		{
//			rand = Random.Range (0, 100);
//			if (rand > 50) {
//				float randomX = (Mathf.Round ((Random.value * 10.0f)) - 5.0f);
//				float randomZ = (Mathf.Round ((Random.value * 10.0f)) - 5.0f);
//				Instantiate (cubicleObjects [obj], new Vector3 (randomX, 10, randomZ), Quaternion.Euler (145, -45, 180));
//				if (obj >= objectQuant) {
//					obj = 0;
//				} else {
//					obj++;
//				}
//			}
//		}
	}

}
