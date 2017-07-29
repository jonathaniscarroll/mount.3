using UnityEngine;
using System.Collections;
using System.Collections.Generic; //this is necessary for using lists

public class cubicleGeneration : MonoBehaviour {

	public game_engine GameEngine;
	public List<GameObject> cubicles = new List<GameObject>();

	public GameObject cubicle;
	private GameObject newestCubicle;
	private List<Vector3> directions = new List<Vector3> ();

	private Vector3 cubiclePos;
	private Vector3 newCubiclePos;
	public GameObject pathway;
	private GameObject newPathway;


	// Use this for initialization
	void Start () {
		GameEngine = gameObject.GetComponent<game_engine>();
		cubiclePos = cubicle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetKeyDown (KeyCode.Space))
//			newCubicle ();
	
	}

	public void newCubicle(){
		newDirection ();
		int o = Random.Range (0, 4);
		newCubiclePos = directions [o];
		Instantiate (pathway, newCubiclePos, Quaternion.identity);
		if (o == 0)
		{newCubiclePos = directions [o] + new Vector3 (6, 0, 0);}
		else if(o == 1)
		{newCubiclePos = directions [o] + new Vector3 (-6, 0, 0);}
		else if (o == 2)
		{newCubiclePos = directions [o] + new Vector3 (0, 0, 6);}
		else
		{newCubiclePos = directions [o] + new Vector3 (0, 0, -6);};
		newestCubicle = Instantiate (cubicle, newCubiclePos, Quaternion.identity) as GameObject;
		cubiclePos = newestCubicle.transform.position;
		directions.Clear();
		//Debug.Log (cubiclePos);
	}

	void newDirection(){
		directions.Add (cubiclePos + new Vector3 (6, 0, 0));
		directions.Add (cubiclePos + new Vector3 (-6, 0, 0));
		directions.Add (cubiclePos + new Vector3 (0, 0, 6));
		directions.Add (cubiclePos + new Vector3 (0, 0, -6));
	}
}
