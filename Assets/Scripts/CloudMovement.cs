using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

    public float speed;

    private Transform _transform;

	// Use this for initialization
	void Start () {
        _transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
	}
}
