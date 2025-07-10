using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(20 * Time.deltaTime, 40 * Time.deltaTime, 30 * Time.deltaTime);
    }

    public void Explode()
    {
        Debug.Log("Exploded");
        Invoke(nameof(Deactivate), 0.5f);
    }
    
    private void Deactivate() => gameObject.SetActive(false);
}
