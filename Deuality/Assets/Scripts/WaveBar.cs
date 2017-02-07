using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBar : MonoBehaviour {

    public PlayerController pc;
    Slider slider;
    float startTime;
    float absStartTime;
    float timer;
    public float cooldown;
    bool started;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //timer += Time.deltaTime;
        //slider.value = Mathf.Clamp(4 - (timer / cooldown * 4), 0, 4);
        if (started && slider.value > 0)
        {
            GoDown();
        }
        else if (started && slider.value <= 0)
        {
            started = false;
            if (!pc.isHuman) pc.Switch();
        }
        else if (!started && slider.value > 4)
        {
            
        }
        else if (!started && slider.value <= 4)
        {
            GoUp();
        }
        
	}

    public void GoUp()
    {
        slider.value += Time.deltaTime;
    }

    public void GoDown()
    {
        slider.value -= 2*Time.deltaTime;
    }

    public void StartTimer()
    {
        started = true;
        timer = 0;
    }
    public void EndTimer()
    {
        started = false;
    }
}
