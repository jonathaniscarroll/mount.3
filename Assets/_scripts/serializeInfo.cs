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

	public static string SaveMessages(Dictionary<string,string> messages){
		string data = "";
		foreach (KeyValuePair<string, string>kvp in messages) {
			data += kvp.Value + "</end>";
		}
		Debug.Log (data);
		return data;
	}

	public static Dictionary<string,float> Load(string saved)
		{
			serverDict = new Dictionary<string,float>();
			StatDictonary postLike = new StatDictonary ();
			postLike = JsonUtility.FromJson<StatDictonary>(saved);
			serverDict = postLike.ToDictionary ();
		
			return serverDict;
		}
}
