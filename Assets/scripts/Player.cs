using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    int delay = 0;

    GameObject bul;
    public GameObject bullet;
    Rigidbody rb;
    public float health;

    protected Player() { }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bul = transform.Find("bul").gameObject;
    }

    void Start () {
		
	}
	
	void Update () {

        rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * 10, 0));
        rb.AddForce(new Vector3(0, Input.GetAxis("Vertical") * 10));

        if (Input.GetKey(KeyCode.Space)&&delay>10)
        {
            Shoot();
        }
        delay++;
    }

    private void Shoot()
    {
        delay =0;
        Instantiate(bullet, bul.transform.position, Quaternion.identity);
    }

    public void Damage()
    {
        health--;
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
}