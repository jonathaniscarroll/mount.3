using UnityEngine;
using System.Collections;

public class warehouseObj : MonoBehaviour {

	private GameObject floor;
	public int cost;

	private TextMesh whText;

	// Use this for initialization
	void Start () {
		floor = GameObject.FindGameObjectWithTag ("cubicle");
		whText = transform.parent.gameObject.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		whText.text = gameObject.name + " costs " + cost.ToString () + " likes.";
	}

	void OnMouseDown(){
		
//		gameObject.transform.parent = null;
//		gameObject.GetComponent<Rigidbody> ().isKinematic = false;
//		moveCamera.followObject (gameObject);
		GameObject newObj = (GameObject)Instantiate(gameObject,new Vector3(Random.Range(-5,5),30,Random.Range(-5,5)),Quaternion.Euler (145, -45, 180)) as GameObject;
		Rigidbody rb = newObj.GetComponent<Rigidbody> ();
		rb.isKinematic = false;
		newObj.GetComponent<BoxCollider> ().isTrigger = false;

	}
}
