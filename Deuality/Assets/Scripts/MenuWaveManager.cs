using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWaveManager : MonoBehaviour {

	public GameObject wave;
	public float amplitude;
	public float factor;
	float startTime;
	private float spawnDelay;

	// Use this for initialization
	void Start () {
		spawnDelay = Random.Range(2,10);
		InvokeRepeating("SpawnWave", spawnDelay, spawnDelay);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(0, amplitude*Mathf.Sin(factor * (Time.time - startTime)),0);
	}
	void SpawnWave()
     {
         Instantiate (wave, transform.position, transform.rotation);
     }
}
