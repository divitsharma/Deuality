using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float jumpForce;
	public float moveSpeed;
	private float moveVelocity;
    public int health;

	private bool grounded;

	public GameObject human;
	public GameObject wave;
    public WaveBar waveBar;
    GameObject newWave;

    public bool isHuman = true;
    float aniStartTime;

    public Slider healthBar;


    bool aniStarted;

    void Awake()
    {
        health = 100;
    }

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {

        if (aniStarted && Time.time - aniStartTime >= 0.3)
        {
            aniStartTime = 0;
            aniStarted = false;
            human.gameObject.SetActive(false);

            newWave = Instantiate(wave, this.transform.position, this.transform.rotation, gameObject.transform);

            isHuman = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<BoxCollider2D>().isTrigger = true;
            waveBar.StartTimer();
        }

		if (Input.GetKeyDown (KeyCode.W) && isHuman){
			Jump();
		}
		else if (Input.GetKey (KeyCode.A)){
			this.transform.Translate(-moveSpeed, 0, 0);
            if (isHuman)
            {
                if (!GetComponentInChildren<SpriteRenderer>().flipX)
                    GetComponentInChildren<SpriteRenderer>().flipX = true;
                GetComponentInChildren<Animator>().SetInteger("State", 1);
            }
        }
		else if (Input.GetKey (KeyCode.D)){
			this.transform.Translate(moveSpeed, 0, 0);
            if (isHuman)
            {
                if (GetComponentInChildren<SpriteRenderer>().flipX)
                    GetComponentInChildren<SpriteRenderer>().flipX = false;
                GetComponentInChildren<Animator>().SetInteger("State", 1);
            }

        }
        else if (isHuman)
        {
            GetComponentInChildren<Animator>().SetInteger("State", 0);
        }
        if (Input.GetKeyDown (KeyCode.Space)){
			Switch();
		}

	}

	public void Jump(){
        if (grounded)
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
    }
    

	public void Switch(){
		if (isHuman){
            GetComponentInChildren<Animator>().Play("Morph");
            aniStarted = true;
            aniStartTime = Time.time;
		}
		else {

			human.gameObject.SetActive(true);
            GetComponentInChildren<Animator>().Play("Demorph");

            GetComponentInChildren<Animator>().SetInteger("State", 0);
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<BoxCollider2D>().isTrigger = false;

            Destroy(newWave);
			isHuman = true;
            waveBar.EndTimer();
		}
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
            grounded = true;
        else if (col.gameObject.tag == "Enemy")
        {
            health -= 10;
            print(healthBar.transform.localScale);
            healthBar.value = health;
            
            if (Input.GetKey(KeyCode.D))
                GetComponent<Rigidbody2D>().AddForce(new Vector3(-100f, 100));
            else if (Input.GetKey(KeyCode.A)) GetComponent<Rigidbody2D>().AddForce(new Vector3(100f, 100));
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground" || col.gameObject.tag == "wall")
        {
            grounded = false;
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground" || col.gameObject.tag == "wall")
        {
            grounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "wall")
        {
            Switch();
        }
        if (col.tag == "Enemy" && Mathf.RoundToInt(GetComponentInChildren<WaveParticle>().amplitude * 10) != Mathf.RoundToInt(col.GetComponent<Barrier>().freq * 0.2f * 10))
        {
            Switch();
        }
    }
}
