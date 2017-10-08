﻿using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	public Transform head;
	public OnlineBody currentPlayer;
	private bool scanning = true;

	private int layerMask;

	public static PlayerManager s { get; private set; }
	void Awake(){
		s = this;
	}
	// Use this for initialization
	void Start () {
		StartCoroutine (ScanForPlayer (1f));
		//layerMask = 1 << 8;
		//layerMask = ~layerMask;
	}
	
	// Update is called once per frame
	void Update () {

		if (currentPlayer != null) {
			head.position = currentPlayer.parts [24].go.transform.position;

		} else {
			if (scanning == false){
				StartCoroutine (ScanForPlayer (1f));
				scanning = true;
			}
			head.position = Vector3.Lerp(head.position, KinectWorld.s.transform.position, Time.deltaTime);
		}
	
	}


	IEnumerator ScanForPlayer (float time) {
		yield return new WaitForSeconds (time);
		bool ready = false;
		for (int i = 0; i<OnlineBodyView.s.bodies.Length; i++) {
			if (OnlineBodyView.s.bodies[i] != null){
				if (Vector3.Distance(OnlineBodyView.s.bodies[i].go.transform.position, new Vector3(KinectWorld.s.transform.position.x,OnlineBodyView.s.bodies[i].go.transform.position.y,KinectWorld.s.transform.position.z)) < 5f){
					MakePlayer (OnlineBodyView.s.bodies[i]);
					ready = true;
					scanning = false;
					break;
				}
			}
			
		}
		if (!ready) {
			StartCoroutine (ScanForPlayer (time));
		}

	}







	void MakePlayer(OnlineBody body){
		currentPlayer = body;
		// parent to neck

		//head.localPosition = new Vector3 (0, 0, 0);

	}
}
