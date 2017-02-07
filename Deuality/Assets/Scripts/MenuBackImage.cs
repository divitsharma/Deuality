using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackImage : MonoBehaviour {


	private float speed;
	public bool CW;
	// Use this for initialization
	void Start () {
		speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(new Vector3(0f,0f,speed));
		if(CW)speed++;
		else speed--;
		if(speed == 360 || speed == -360) speed = 0;
	}
}
