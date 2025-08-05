using System;
using UnityEngine;

public class SpellProjectile : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.AddForce(transform.forward * 500);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Enemy")) return;
        other.gameObject.GetComponent<Enemy>().Explode();

        Destroy(gameObject); // should be a similar method to Enemy.Destroy instead
    }
}
