using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveParticle : MonoBehaviour {

    public float amplitude;
    public float factor;

    // Use this for initialization
	void Start () {
		//time = Time.time
	}
	
	// Update is called once per frame
	void Update () {
        
        this.transform.Translate(0, amplitude*Mathf.Sin(Time.time / factor), 0);
        
        print("I MADE A CHANGE!");
    }
}
