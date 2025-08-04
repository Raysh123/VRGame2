using System;
using UnityEngine;

public class DebugKeyboardControls : MonoBehaviour
{
    // running in update is horrid, but this will all be removed after mapping to oculus
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("pressed Space");
            EnemyManager.SharedInstance.SpawnEnemy();
        }
    }
}
