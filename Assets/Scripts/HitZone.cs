using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{

    public delegate void OnHitHandler();
    public static event OnHitHandler OnHit;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (!other.gameObject.CompareTag("Enemy")) return;
        OnHit?.Invoke();
    }
}
