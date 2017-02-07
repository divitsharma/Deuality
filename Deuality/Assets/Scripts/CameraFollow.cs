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

        camera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
	}
}
