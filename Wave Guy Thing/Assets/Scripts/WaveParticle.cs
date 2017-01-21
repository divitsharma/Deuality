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
        //this.transform.position += new Vector3(0.01f, 0, 0);
        //this.transform.Translate(0.1f, 0, 0);
        this.transform.Translate(0, amplitude*Mathf.Sin(Time.time / factor), 0);
        //x = sin(t)
        print(amplitude * Mathf.Sin(Time.time));
    }
}
