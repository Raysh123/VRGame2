using System;
using UnityEngine;

public class SpellProjectile : MonoBehaviour, IProjectile
{
    private Rigidbody _rigidbody;

    MeshRenderer _meshRenderer;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        _rigidbody.AddForce(transform.forward * 500);
    }

    private void OnTriggerEnter(Collider other)
    {
        HitEnemy(other);
    }

    public void HitEnemy(Collider other)
    {
        if (!other.gameObject.CompareTag("Enemy")) return;
        other.gameObject.GetComponent<Enemy>()?.Explode();
        Explode();
    }

    public void Explode()
    {
        _meshRenderer.enabled = false;
        Destroy(gameObject);
    }
}
