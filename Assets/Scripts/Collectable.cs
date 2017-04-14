using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Base {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        UpdateSpeed();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameGlobals.Instance.coinsCollected += 1;
            Debug.Log("Coins: " + GameGlobals.Instance.coinsCollected);
        }
    }
}
