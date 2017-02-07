using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {


    public float freq;

    public float red;
    public float green;
    public float blue;

    // Use this for initialization
    void Start () {
        var col = GetComponentInChildren<SpriteRenderer>().color;
        red = col.r;
        green = col.g;
        blue = col.b;

    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerPrefs.SetFloat("freq", freq);

        Resources.Load<Material>("CircleMat").color = new Color(red, green, blue);
    }
}
