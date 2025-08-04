using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Target { private get; set; }

    private void Update()
    {
        transform.Rotate(20 * Time.deltaTime, 40 * Time.deltaTime, 30 * Time.deltaTime);
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

    private void Deactivate() => gameObject.transform.parent.gameObject.SetActive(false);
}
