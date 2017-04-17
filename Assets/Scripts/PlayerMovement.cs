using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float gravity;
    public float jumpSpeed;
    public Vector3 startPoint;
    public ParticleSystem _particles;

    private Transform _transform;

    private CharacterController _controller;

    private float _inputX;
    private Vector3 _direction;

	// Use this for initialization
	void Start () {

        _transform = GetComponent<Transform>();
        _controller = GetComponent<CharacterController>();
        startPoint = _transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        //if (!GameGlobals.Instance.playerAlive)
        //    return;

        _inputX = Input.GetAxis("Horizontal");

        _direction = new Vector3(_inputX, _direction.y, 0);
        _direction.x *= speed;

        if (_controller.isGrounded)
        {
            _direction.y = -10;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _direction.y = 1 * jumpSpeed;

            }
        }

        if(_direction.y > -10)
        _direction.y -= gravity * Time.deltaTime;

        _controller.Move(_direction * Time.deltaTime);

        if(_transform.position.y <= -4)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(_particles, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        GameGlobals.Instance.playerAlive = false;

        //Respawn();
    }

    private void Respawn()
    {
        _transform.position = startPoint;
        gameObject.SetActive(true);
    }

}
