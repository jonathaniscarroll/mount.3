using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPostObject : MonoBehaviour {

	public static Dictionary<string,float> _newLikePosts;
	public static Dictionary<string,string> _postMessages;

	public static int _postsSpawned = 0;

	public GameObject _postObj;

	public static GameObject thisPost;

	void Start(){
		thisPost = GetComponent<spawnPostObject> ()._postObj;
	}

	public static void spawn(string posts,float likes){
		
		GameObject p = (GameObject)Instantiate (thisPost,new Vector3(0,10,0),Quaternion.Euler(new Vector3(0,45,-45))) as GameObject;
		p.GetComponent<postInfo> ().addText(posts,likes);
		_postsSpawned++;
	}

	public static void nextPost(){
		List<string> postList = new List<string> (_newLikePosts.Keys);
		if(_postsSpawned <= postList.Count){
			string postID = postList [_postsSpawned];
			spawn (_postMessages[postID],_newLikePosts[postID]);
		}

	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.P)){
			spawn("test Post HA Ha Ha", 5f);
		}
	}
}
