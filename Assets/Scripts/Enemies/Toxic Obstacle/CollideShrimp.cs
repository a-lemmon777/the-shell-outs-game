using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CollideShrimp : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var health = other.gameObject.GetComponentInParent<ShrimpHealth>();

        if (health == null) return;

        health.PowerUp.Invoke();

        Destroy(gameObject);
    }
}
