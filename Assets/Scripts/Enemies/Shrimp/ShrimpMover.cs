using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(ShrimpAnimator))]
public class ShrimpMover : MonoBehaviour
{
    [Tooltip("Destination position to move to")]
    public Transform Destination;

    [Tooltip("Speed in units per second")]
    public float Speed = 5;

    private Rigidbody2D _rigidbody2D;

    private ShrimpAnimator _shrimpAnimator;

    // Start is called before the first frame update
    void Start()
    {
        this._rigidbody2D = GetComponent<Rigidbody2D>();
        this._shrimpAnimator = GetComponent<ShrimpAnimator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceLeft = Vector2.Distance(Destination.position, _rigidbody2D.position);

        // the shrimp arrived
        if (distanceLeft <= 0.05f) // proximity threshold, 0.05f makes the shrimp stop on the target
        {
            _rigidbody2D.velocity = Vector2.zero;
            return;
        }

        _rigidbody2D.velocity =
            ((Vector2)Destination.position - _rigidbody2D.position).normalized * Speed
        ;

        // animations
        _shrimpAnimator.HandleMovement(_rigidbody2D.velocity.x);
    }

}
