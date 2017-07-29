using UnityEngine;
using System.Collections;

public class openingAnimation : MonoBehaviour {

	private Camera cam;
	private AudioSource audioSrc;
	private Vector3 camPos;
	private Vector3 camStart;

//	// Use this for initialization
//	void Start () {
//		cam = Camera.main;
//		audio = GetComponent<AudioSource> ();
//		camPos = cam.transform.position;
//		camStart = new Vector3 (camPos.x,camPos.y + 30,camPos.z);
//		cam.transform.position = camStart;
//		audio.Play ();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		bool hasPlayed = false;
//		if (!hasPlayed) {
//			if (audio.isPlaying) {
//				Debug.Log("still playing");
//			} else if (!audio.isPlaying){
//				Debug.Log("stopped playing");
//				cam.transform.position = Vector3.MoveTowards (camStart, camPos, Time.deltaTime *10);
//				hasPlayed = true;
//			}
//		}
//	}
}
