using UnityEngine;
using System.Collections;

public class objectquality : MonoBehaviour {

	public GameObject poorItem;
	public GameObject goodItem;
	public GameObject currentItem;
	private float roll;

	//minimum likes required for goodItem
	public int likeQuantity = 15;

	//reference the name of the script and the variable it is assigned
	public game_engine quality; 

	// Use this for initialization
	void Start () {
		roll = 0;
		currentItem = poorItem;
		//really drive home that this script is refering to the thing you told it to refer to
		quality = gameObject.GetComponent<game_engine>();
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown (KeyCode.Space) ){
			roll = Random.value * 100;
		};

		roll = Random.value * 100;

		//determine if object generated will be high or low quality
		if (quality.posts >= likeQuantity) {
			if(roll < quality.posts){
			currentItem = goodItem;
			} else if(roll > quality.posts){
			currentItem = poorItem;
			}
		}
	
	}


}
