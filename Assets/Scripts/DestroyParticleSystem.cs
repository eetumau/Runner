using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour {

    private ParticleSystem _ps;
    private Transform _parent;

	// Use this for initialization
	void Start () {
        _ps = GetComponent<ParticleSystem>();
        _parent = GetComponentInParent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!_ps.IsAlive())
        {
            Destroy(gameObject);
        }
	}
}
