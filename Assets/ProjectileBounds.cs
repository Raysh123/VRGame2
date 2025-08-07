using System;
using UnityEngine;

public class ProjectileBounds : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<SpellProjectile>()) return;
        Debug.Log("Destroyed projectile");
        other.GetComponent<SpellProjectile>().Explode();
    }
}
