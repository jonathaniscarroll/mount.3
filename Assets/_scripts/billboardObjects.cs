using UnityEngine;
using System.Collections;

public class billboardObjects : MonoBehaviour {

	public Camera mainCamera;



	void Start()
	{
		mainCamera = Camera.main;
	}

	void Update()
	{
		transform.rotation = mainCamera.transform.rotation;
	}
}
