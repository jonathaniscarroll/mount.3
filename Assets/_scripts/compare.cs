﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class compare : MonoBehaviour {

	public game_engine GameEngine;
	public objectDictionary objDick;
	public static compare compareScript;

	public static float likeTotal;

	public static List<string> newPostIDs;

	// Use this for initialization
	void Start () {

		GameEngine = gameObject.GetComponent<game_engine> ();
		objDick = gameObject.GetComponent<objectDictionary> ();
		compareScript = this;
		newPostIDs = new List<string> ();
	
	}


	public static Dictionary<string, float> CompareDicks (string server)
	{
		Dictionary<string, float> serverDick = serializeInfo.Load (server);
		Dictionary<string, float> facebookDick = fbInit.facebookDict;

//		compare.listDict(serverDick,"server");
//		compare.listDict (facebookDick,"facebook");


		List<string> keys = new List<string> (facebookDick.Keys);

		float oldLikes = 0;
		int count = 0;
		float newLikes = 0;

		foreach (string key in keys) {
			
			int fbval = (int)facebookDick [key];
			if (serverDick.ContainsKey (key)) {
				oldLikes += serverDick[key];
//					Debug.Log(serverDick[key] +  " is different from " + facebookDick[key]);
				if (serverDick[key] != fbval){
					//these are the NEW likes
					newLikes += fbval - serverDick[key];
					Debug.Log ("New Likes: " + newLikes);
				}
				serverDick[key] = fbval;
//					Debug.Log(serverDick[key] +  " now = " + fbval);

			} else if (!serverDick.ContainsKey (key)) {
				newLikes += fbval;
//				Debug.Log ("Server does not contain post, adding");
				serverDick.Add (key, fbval);
//				Debug.Log (serverDick [key]);
				newPostIDs.Add(key);
			}
			count++;

		}

//		Debug.Log ("RAW LIEKS " + newLikes);
		rawLikes.generateLikeTokens (newLikes);
		compareScript.GameEngine.setText ((int)oldLikes);
		likeTotal = newLikes + oldLikes;
		return serverDick;

	}
	//currently displaying only the likes from the most recent facebook grab, why?

	void setLikes(int likes){
		GameEngine.setText (likes);
	}

	public static Dictionary<string,string> compareMessages (Dictionary<string,string> fbDict){

		Dictionary<string, string> servDict = new Dictionary<string,string>();


		List<string> keys = new List<string> (fbDict.Keys);

		foreach (string key in keys) {
			if (!servDict.ContainsKey (key)) {
				servDict.Add (key, fbDict [key]);
			}
		}
		return servDict;
	}

	public static void listDict(Dictionary<string,float> dictionary,string name)
	{
		int i = 0;
		string dict = name + ": ";
		foreach (KeyValuePair<string,float> x in dictionary) {
			dict += " Post: " + x.Key + " Like: " +  x.Value; 
			i++;
		}
		if (i >= dictionary.Count) {
//			Debug.Log (dict);
//			Debug.Log ("there are " + dictionary.Count + "posts in " + name);
		}
	}

}
