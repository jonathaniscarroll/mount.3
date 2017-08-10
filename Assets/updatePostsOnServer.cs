using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updatePostsOnServer : MonoBehaviour {

	public static IEnumerator updateServer(string postId, float likes){

		Dictionary<string,float> serverDictionary = game_engine.serverDictionary;
		string userName = game_engine.userName;

		if (serverDictionary.ContainsKey (postId)) {
			//if the server has this post in it, and these are new likes
			serverDictionary[postId] += likes;
		} else {
			//if the server does not have this post in it, new post and new likes
			serverDictionary.Add(postId,likes);
		}
		string serializeUpdate = serializeInfo.Save (serverDictionary);
		string updateUrl = "https://mount.toughguymountain.com/php/updateServer.php?posts=" + serializeUpdate + "&name=" + userName;
		WWW connect = new WWW (updateUrl);
		yield return connect;
		if (!string.IsNullOrEmpty (connect.error)) {
			Debug.Log ("it didn't update the likes on the server");
			Debug.Log ("POST: " + postId + "; LIKES: " + serverDictionary [postId]);
		} else {
			Debug.Log ("POST: " + postId + "; LIKES: " + serverDictionary[postId]);
		}
	}

}
