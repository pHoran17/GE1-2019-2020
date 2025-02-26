﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Collision");
            ExplodeMyParts();
        }
    }

    private void ExplodeMyParts()
    {
        foreach (Transform t in this.GetComponentsInChildren<Transform>())
        {
            Rigidbody rb = t.gameObject.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = t.gameObject.AddComponent<Rigidbody>();
            }
            rb.useGravity = true;
            rb.isKinematic = false;
            Vector3 v = new Vector3(
                Random.Range(-5, 5)
                , Random.Range(5, 10)
                , Random.Range(-5, 5)
                );
            rb.velocity = v;
        }
        Invoke("Sink", 4);
        Destroy(this.gameObject, 7);
    }

    void Sink()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().drag = 1;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
