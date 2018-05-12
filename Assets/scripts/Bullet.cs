using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    int dir=1;
    Rigidbody rb;

    private void Start()
    {
        Destroy(gameObject, 1);
    }

    void ChangeDirection()
    {
        dir = -dir;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	void Update () {
        rb.velocity = new Vector3(0,15 * dir,0);
	}

    void OnTriggerEnter(Collider other)
    {
        if (dir == 1)
        {
            if (other.gameObject.tag == "Enemy")
                {
                    other.gameObject.GetComponent<Enemy>().Damage();
                    Destroy(gameObject);;
                }
        }
        else
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Enemy>().Damage();
                Destroy(gameObject); ;
            }
        }
        
    }
}
