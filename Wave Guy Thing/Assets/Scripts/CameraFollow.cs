using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform camera;

    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(0.1f, 0, 0);
        camera.transform.position = new Vector3(this.transform.position.x, 0, -10);
	}
}
