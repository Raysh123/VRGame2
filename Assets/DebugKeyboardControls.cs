using System;
using UnityEngine;

public class DebugKeyboardControls : MonoBehaviour
{
    [SerializeField] private Spellbook spellbook;
    // running in update is horrid, but this will all be removed after mapping to oculus
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("pressed Space");
            EnemyManager.SharedInstance.SpawnEnemy();
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Debug.Log("pressed LeftArrow");
            spellbook.CurrentPage--;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Debug.Log("pressed RightArrow");
            spellbook.CurrentPage++;
        }
        else if (Input.GetKeyUp(KeyCode.G))
        {
            spellbook.CastActiveSpell();
        }
    }
}
