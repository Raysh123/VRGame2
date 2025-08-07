using System;
using System.Net.NetworkInformation;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour, IProjectile
{
    [SerializeField] private float explosionRadius = 50f;
    
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
        ExplodeSurroundingEnemies();
        Explode();
    }

    private void ExplodeSurroundingEnemies()
    {
        Collider[] colliders = Physics.OverlapSphere(
            position: transform.position,
            radius: 50f);

        foreach (Collider c in colliders)
        {
            Debug.Log("Collider hit: " + c.gameObject.name);
            if (c.GetComponent<Enemy>()) c.GetComponent<Enemy>().Explode();
        }
    }

    public void Explode()
    {
        _meshRenderer.enabled = false;
        Destroy(gameObject);
    }
}
