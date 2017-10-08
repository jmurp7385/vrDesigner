﻿using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {
	public Material coolMat;
	public Transform hoverboard;

	private static ObjectManager singleton;
	public static ObjectManager s {get {return singleton;}}
	protected void Awake(){
		singleton = this;
	}	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
