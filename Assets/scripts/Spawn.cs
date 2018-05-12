using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject[] enemies;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnEnemy", 2, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnEnemy()
    {
        Instantiate(enemies[(int)Random.Range(0,enemies.Length)],new Vector3(Random.Range(-6,6),6,0),Quaternion.identity);
    }
}
