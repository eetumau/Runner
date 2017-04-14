using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float duration;
    public Vector3 rightPoint;
    public Vector3 leftPoint;

    private Transform _transform;
    private float eventTime;

	// Use this for initialization
	void Start () {
        _transform = GetComponent<Transform>();
        eventTime = Time.time;

        rightPoint = new Vector3(Random.Range(0, 3), Random.Range(2, 4), _transform.position.z);
        leftPoint = new Vector3(Random.Range(-3, 1), Random.Range(2, 4), _transform.position.z);
        duration = Random.Range(1, 6);
        //_transform.position = new Vector3(rightPoint.x, rightPoint.y, _transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        float fRatio = (Time.time - eventTime) / duration;
        Vector3 vPos = Vector3.Lerp(leftPoint, rightPoint, Easing.EaseInOut(fRatio, EasingType.Sine, EasingType.Sine));
        vPos.z = _transform.position.z;
        _transform.position = vPos;

        if(fRatio >= 1)
        {
            FlipDirection();
            eventTime = Time.time;
        }
    }

    private void FlipDirection()
    {
        Vector3 vTemp = rightPoint;
        rightPoint = leftPoint;
        leftPoint = vTemp;
    }
}
