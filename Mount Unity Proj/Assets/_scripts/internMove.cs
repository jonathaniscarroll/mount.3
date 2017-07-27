using UnityEngine;
using System.Collections;

public class internMove : MonoBehaviour {

	public Vector3 goal;
	public UnityEngine.AI.NavMeshAgent agent;
	public GameObject intern;
	//action bool - if set to 0, walk around, otherwise, perform object related action for 10 seconds
	public bool action;

	public GameObject detection;
	public interaction interacting;

	void Start () {
		action = false;
		newGoal ();
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.destination = goal; 

		interacting = detection.GetComponent<interaction>();
	}

	void Update (){
		if(action == false){
			agent.speed = 3.5f;
			agent.angularSpeed = 120;
			agent.acceleration = 8;
			if (agent.remainingDistance < 0.5f) {
				newGoal ();
				agent.destination = goal;
			} 
		}
			if (action == true){
				newGoal();
				agent.speed = 0.0f;
				agent.angularSpeed = 0;
			}
		if(interacting.counter > 250){
			action = false;
			newGoal();
		}	}

	void newGoal () {
		if(action == false){
			goal = new Vector3 (Random.Range (-5.0f, 5.0f), 0, Random.Range (-5.0f, 5.0f));
		}
		if(action == true){
			goal = new Vector3 (gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
		}
	}
}
