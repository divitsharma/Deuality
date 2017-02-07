using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;
    public Transform fpsTarget;
    Rigidbody theRigidbody;
    Renderer myRender;

    // Use this for initialization
    void Start () {
        myRender = GetComponent<Renderer>();
        theRigidbody = GetComponent<Rigidbody>();
        this.transform.Translate(5, 0, 0);	
	}
	
	// Update is called once per frame
	void Update () {
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if(fpsTargetDistance<enemyLookDistance)
        {
            lookAtPlayer();
            print("look");
        }
        if (fpsTargetDistance < attackDistance)
        {
            attackPlease();
            print("Attack");
        }
        else
        {
            myRender.material.color = Color.blue;
        }
		
	}

    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    void attackPlease()
    {
        theRigidbody.AddForce(transform.forward * enemyMovementSpeed);
    }
}
