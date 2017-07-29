using UnityEngine;
using System.Collections;
using System.Collections.Generic; //this is necessary for using lists

public class objectDictionary : MonoBehaviour {

	public List<GameObject> cubicleObjects = new List<GameObject>();

	public Dictionary<int,GameObject> cubobjDictionary;
	public Dictionary<GameObject,float> weightDictionary;

	public objectQuantity quantity;


	private int objectQuant;

	// Use this for initialization
	void Start () {
		quantity = gameObject.GetComponent<objectQuantity> ();
		cubobjDictionary = new Dictionary<int,GameObject>();
		weightDictionary = new Dictionary<GameObject,float> ();
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
			o = Random.Range (i * (10 + i * i) - 10, i * (10 + i * i) + 10);
			cubobjDictionary.Add (o,cubobj);
			//Debug.Log (o + ": " + cubobjDictionary[o]);
			i++;
		}
	}

	public void populateCubicles(int likes){
		
		objectQuant = Random.Range(0, (likes/10));

		//Debug.Log ("Number of objects: " + objectQuant);
		int obj = 0;
		int rand;
		for(int i = 0; i <= objectQuant; i++)
		{
			rand = Random.Range (0, 100);
			if (rand > 50) {
				float randomX = (Mathf.Round ((Random.value * 10.0f)) - 5.0f);
				float randomZ = (Mathf.Round ((Random.value * 10.0f)) - 5.0f);
				Instantiate (cubicleObjects [obj], new Vector3 (randomX, 10, randomZ), Quaternion.Euler (145, -45, 180));
				if (obj >= objectQuant) {
					obj = 0;
				} else {
					obj++;
				}
			}
		}
	}

}
