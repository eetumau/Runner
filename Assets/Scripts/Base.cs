using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

    public float endZ = -10;
    public float startZ = 0;
    public float speed = 5;


    protected Transform _transform;
    private float _newZ;
    protected FloorManager _manager;

    // Use this for initialization
    void Awake () {

        _manager = FindObjectOfType<FloorManager>();

    }
	
    protected void Move()
    {
        _newZ = transform.position.z - (speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, _newZ);

    }


    protected void UpdateSpeed()
    {

        speed = _manager.speed;
    }
}
