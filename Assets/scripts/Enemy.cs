using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Rigidbody rb;

    public float xSpeed;
    public float ySpeed;
    public bool canShoot;
    public float fireRate;
    public float health;
    public GameObject explosion;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update ()
    {
        rb.velocity = new Vector3(xSpeed,-ySpeed);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage();
            Damage();
        }
    }

    public void Damage()
    {
        health--;
        if (health == 0)
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+1);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
