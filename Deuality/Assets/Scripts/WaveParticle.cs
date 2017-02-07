using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveParticle : MonoBehaviour {

    public float amplitude;
    public float factor;

    float startTime;

    // Use this for initialization
	void Start () {
        startTime = Time.time;
        if (PlayerPrefs.HasKey("freq"))
        {
            amplitude *= PlayerPrefs.GetFloat("freq");
            factor *= PlayerPrefs.GetFloat("freq");
        }
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(0, amplitude*Mathf.Sin(factor * (Time.time - startTime)), 0);
    }
}
