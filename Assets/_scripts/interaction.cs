using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class interaction : MonoBehaviour {
	//to find variables outside of the object you need to define both the game object to search as well as the script
	//"self" is otherwise assumed
	public GameObject intern;
	public internMove acting; 

	public float counter;
	private float roll;

	private int holdingPencil;
	private int holdingCoffee;
	private int holdingPaper;

	//throwing stuff stuff
	public Rigidbody rigidthrow;
	private float randomX;
	private float randomY;
	private float randomZ;

	public Rigidbody rotater;

	public TextMesh textMesh;

	private bool worked;

	//laptop text stuff;
	public Text laptoptext;

	// Use this for initialization
	void Start () {
		acting = intern.GetComponent<internMove>();
		counter = 0;
		holdingPencil = 0;
		holdingCoffee = 0;
		holdingPaper = 0;
//		laptoptext.text = null;

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(acting.action);
		if(acting.action == true){
			counter += 1; 
			if(counter > 250){
				laptoptext.text = null;

				acting.action = false;
				counter = 0;
			}
		}
	}

	void OnTriggerEnter (Collider col) {
		//Debug.Log(col.tag);
		if (worked == false){
			worked = true;
		if(col.tag == "chair"){
			roll = Random.value * 100;
			//Debug.Log(roll);
			if(roll > 50.0f){
			acting.action = true;
			}
		}
		if(col.tag == "pencil"){
			//get collider's game object, put that into pickuphold
			if(holdingPencil == 0){
			PickUpandHold (col.gameObject);
				//render.enabled = true;
			}
			if(holdingPencil == 1){
				ThrowAwayItem ("pencil");
				PickUpandHold (col.gameObject);
			}
			//Debug.Log(col.gameObject);

		} 

		if(col.tag == "coffee"){
			//get collider's game object, put that into pickuphold
			if(holdingCoffee == 0){
				PickUpandHold (col.gameObject);
				//render.enabled = true;
			}
			if(holdingCoffee == 1){
				ThrowAwayItem ("coffee");
				PickUpandHold (col.gameObject);
			}
			//Debug.Log(col.gameObject);

		}

		if(col.tag == "paper"){
			if(holdingPaper == 0){
				PickUpandHold (col.gameObject);
			}
			if(holdingPaper == 1){
				ThrowAwayItem ("paper");
				PickUpandHold (col.gameObject);
			}
		}

		if(col.tag == "laptop"){
			counter = 0;
			roll = Random.value * 100;
			if(roll > 0.0f){
				acting.action = true;
//				laptoptext.text = "laptop works";
				if(counter > 200){
					laptoptext.text = null;
				}
			}
		}

		if(col.tag == "pyramid"){
			counter = 0;
			rotater = col.GetComponent<Rigidbody>();
			//rotater.mass = 0;;
			//col.transform.position = new Vector3(col.transform.position.x, (counter * 0.01f), col.transform.position.z);
			rotater.AddForce(0,500,0, ForceMode.Acceleration);
			rotater.AddTorque(0, 1000, 0, ForceMode.Acceleration);
		}
		}
	}

	void OnTriggerExit (Collider item){
		worked = false;
	}

	void PickUpandHold (GameObject item) {
		Vector3 internPosiHold = new Vector3 (transform.position.x + 1, 2.0f, transform.position.z);

		//item.transform.Translate(internPosiHold * (Time.deltaTime * 0.1f), Space.Self);
	
		//item.transform.position = Vector3.MoveTowards(item.transform.position, internPosiHold, Time.deltaTime * 0.1f);
		item.transform.position = internPosiHold;
		item.transform.rotation = Random.rotation;
		item.transform.SetParent(intern.transform, true);
		item.GetComponent<Rigidbody>().useGravity = false;

		item.GetComponent<Rigidbody>().isKinematic = true;

		if(item.tag == "pencil"){
			holdingPencil = 1;
		}
		if(item.tag == "coffee"){
			holdingCoffee = 1;
		}
		if(item.tag == "paper"){
			holdingPaper = 1;
		}

	}

	void ThrowAwayItem (string oldItemName){
		foreach (Transform iChild in intern.transform){
			if (iChild.tag == oldItemName){

				randomX = (Random.value * 100f)*50;
				//randomY = (Random.value * 360f)*5;
				//randomZ = (Random.value * 360f)*5;
				iChild.GetComponent<Rigidbody>().useGravity = true;

				iChild.GetComponent<Rigidbody>().isKinematic = false;

				rigidthrow = iChild.GetComponent<Rigidbody>();
				rigidthrow.AddForce(intern.transform.forward * randomX, ForceMode.Force);
				iChild.parent = null;

				if(iChild.tag == "pencil"){
					holdingPencil = 0;
				}
				if(iChild.tag == "coffee"){
					holdingCoffee = 0;
				}
				if(iChild.tag == "paper"){
					holdingPaper = 0;
				}
			}
		}
	}
}