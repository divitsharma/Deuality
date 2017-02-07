using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWave : MonoBehaviour {

	public float speed;
	public float timeAlive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(speed, 0f, 0f);
	}

	void Awake(){
		Destroy(this.gameObject, timeAlive);
	}
}
