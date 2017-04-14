using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : Base {



    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        Move();
        UpdateSpeed();

        if (transform.position.z <= endZ)
        {
            Destroy(gameObject);
            _manager.SpawnFloor();
        }
    }

}
