using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class determineNewMessages : MonoBehaviour {

	public static string newMessages(Dictionary<string,string> facebook, string server){
		string messages = "";
		string[] splitString = server.Split (new string[] {"</end>"},StringSplitOptions.None);
		List<string> serverMsgs = splitString.ToList ();

		foreach (KeyValuePair<string,string> kvp in facebook) {
			if(!serverMsgs.Contains(kvp.Value)){
				serverMsgs.Add (kvp.Value);
				//				messages += kvp.Value + "</end>";
			}

		}
		foreach (string mess in serverMsgs) {
			messages += mess + "</end>";
		}
		Debug.Log ("NEW MESSAGES: " + messages);
		return messages;
	}

}
