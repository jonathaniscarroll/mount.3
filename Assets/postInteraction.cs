using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postInteraction : MonoBehaviour {

	private GameObject intern;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "intern"){
			intern = other.gameObject;
			intern.GetComponent<internMove> ().agent.destination = transform.position + new Vector3(1,0,0);
			if (intern.GetComponent<internMove> ().action == false) {
				intern.GetComponent<internMove> ().action = true;
				beHarvested ();
			}
		}
	}

	void beHarvested(){
		float harvestSpeed = 0.1f;
		if (intern.GetComponent<Inventory> ().stuff.Count != 0) {
			foreach(GameObject item in intern.GetComponent<Inventory> ().stuff){
				harvestSpeed += item.GetComponent<objectProperties> ().thisObjProperties.likesPerSecond;
			}
		}
		StartCoroutine (harvest(harvestSpeed));
	}

	IEnumerator harvest(float speed){
		postInfo post = gameObject.GetComponent<postInfo> ();
		float likesToServer = post.thisInfo.likes;
		string postToServer = post.thisInfo.posts;
		while(post.thisInfo.likes > 0){
			yield return new WaitForSeconds (10 * speed);
			intern.GetComponent<InternState> ().stateState ("I am processing this post");
			rawLikes.generateSingleToken (1);
			post.thisInfo.likes--;
			post.addText (post.thisInfo.posts,post.thisInfo.likes);
		}
		intern.GetComponent<InternState> ().stateState ("I am done processing this post");
		Debug.Log ("finished");
		Destroy(gameObject);
		spawnPostObject.nextPost ();
		StartCoroutine (updatePostsOnServer.updateServer(postToServer,likesToServer));
		intern.GetComponent<internMove> ().action = false;
			
	}
}
