using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private bool _isAvailable = true;
    public bool IsAvailable
    {
        get => _isAvailable;
        set
        {
            _isAvailable = value;
            if (value == true) return;
            Invoke(nameof(Reenable), time: 1f);
        }
    }

    private void Reenable() => _isAvailable = true;
}
