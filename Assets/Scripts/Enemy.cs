using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : Base {

    public List<Transform> _particles;

	// Update is called once per frame
	void Update () {

        Move();
        UpdateSpeed();

        if(transform.position.z <= endZ)
        {
            Destroy(gameObject);
            //_manager.SpawnEnemy();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            foreach(Transform psTransform in _particles)
            {
                Instantiate(psTransform, transform.position, psTransform.rotation);
            }
            Destroy(gameObject);
            other.gameObject.GetComponent<PlayerMovement>().Die();

        }
    }


}
