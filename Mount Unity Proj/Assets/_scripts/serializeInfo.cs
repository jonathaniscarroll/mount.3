using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class StatDictionary:SerializableDictionary<string,float>{}

public class serializeInfo {

	public static Dictionary<string,float> serverDict;

	public static string Save(Dictionary<string, float> incoming)
	{
		StatDictonary stat = new StatDictonary ();
		string data = "";
		foreach (KeyValuePair<string, float>kvp in incoming) {
			stat.Add (kvp.Key, kvp.Value);
			data += " POST: " + kvp.Key + " LIKE: " + kvp.Value;
		}
		//Debug.Log (data);
		string json = JsonUtility.ToJson(stat);
		//Debug.Log (json);
		return json;
	}

	public static Dictionary<string,float> Load(string saved)
		{
//			Debug.Log ("we are trying to load this string as a dictionary: " + saved);
			serverDict = new Dictionary<string,float>();
			StatDictonary postLike = new StatDictonary ();
			postLike = JsonUtility.FromJson<StatDictonary>(saved);
//		string data = "";
//		foreach (KeyValuePair<string,float> derp in postLike) {
//			data += "POST: " + derp.Key + " LIKE: " + derp.Value;
//		}
//		Debug.Log (data);
			serverDict = postLike.ToDictionary ();

//		foreach(KeyValuePair<string,float> kvp in serverDict)
//			{
//				
//				//Debug.Log ("KEy: " + kvp.Key + " VALUEL: " + kvp.Value);
//			}
//		for (int i = 0; i < serverDict.Count; i++) 
//			{
//				string dlPost = postLike.post [i];
//				int dlLike = postLike.like [i];
//				
//				serverDict.Add (dlPost, dlLike);
//				//Debug.Log ("POST: "+postLike.post[i] + " LIKES: " + postLike.like[i]);
//			}
		
			return serverDict;
		}
}
