using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {

	public float amplitudeY;
	public float amplitudeX;
    public float factorY;
    public float factorX;

    float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(amplitudeX*Mathf.Sin(factorX * (Time.time - startTime)), 
								 amplitudeY*Mathf.Sin(factorY * (Time.time - startTime)), 0);
	}
}
