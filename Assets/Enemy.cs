using System;
using NUnit.Framework.Constraints;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool canMove = true;
    
    public Transform Target { private get; set; }

    private void Update()
    {
        transform.Rotate(20 * Time.deltaTime, 40 * Time.deltaTime, 30 * Time.deltaTime);
        
        if (!canMove) return;
        
        transform.parent.position = Vector3.Lerp(
            transform.parent.position, 
            Target.position, 
            Time.deltaTime / 2);
    }

    public void Explode()
    {
        Debug.Log("Exploded");
        Invoke(nameof(Deactivate), 0.5f);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
        if (transform.parent.childCount > 0) return;
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
