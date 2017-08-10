using UnityEngine;
using System.Collections;

public class internMove : MonoBehaviour {

	public GameObject goal;
	public UnityEngine.AI.NavMeshAgent agent;
	public GameObject intern;
	//action bool - if set to 0, walk around, otherwise, perform object related action for 10 seconds
	public bool action;

	public GameObject detection;
	public interaction interacting;

	public internBrain brain;
	public InternState state;

	private GameObject randGoal;

	void Start () {
		state = GetComponent<InternState> ();
		randGoal = new GameObject("randGoal");
		brain = GetComponent<internBrain> ();
		action = false;
		newGoal ();
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.destination = goal.transform.position; 

		interacting = detection.GetComponent<interaction>();
	}

	void Update (){
		if(action == false && goal != null){
			agent.speed = 3.5f;
			agent.angularSpeed = 120;
			agent.acceleration = 8;
			agent.destination = goal.transform.position;
			if(agent.remainingDistance < 0.1){
				newGoal ();
			}
		} else if(goal == null){
			newGoal ();
		} else if(action == true){

		}

	
	}new  

	void newGoal () {
		if(brain.memory.ContainsKey("likeToken")){
			goal = brain.memory["likeToken"][0];
			state.stateState ("I found a like token");
		}
//		else if(){
//			
//		}

		else {
			randGoal.transform.position = new Vector3 (Random.Range(-4,4),0,Random.Range(-4,4));
			state.stateState ("I am walking to a random spot");
			goal = randGoal;
		}
	}
}
