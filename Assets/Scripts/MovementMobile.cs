using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMobile : MonoBehaviour
{
    private bool _isFlat = true;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 tilt = Input.acceleration;

        if (_isFlat)
            tilt = Quaternion.Euler(90, 0, 0) * tilt * 2f;

        _rigidbody.AddForce(tilt * 8);
        Debug.DrawRay(transform.position + Vector3.up, tilt, Color.blue);
    }
}
