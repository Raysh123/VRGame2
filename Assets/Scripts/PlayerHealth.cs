using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthPointUIParent;
    private int _healthPoints = 3;

    private void OnEnable()
    {
        HitZone.OnHit += RemoveHealthPoint;
    }

    private void RemoveHealthPoint()
    {
        if (GameManager.CurrentGameState != GameState.Start) return;
        _healthPoints--;
        Destroy(healthPointUIParent.transform.GetChild(0).gameObject);
        if (healthPointUIParent.transform.childCount != 1) return;
        GameManager.CurrentGameState = GameState.GameOver;
    }

    private void OnDisable()
    {
        HitZone.OnHit -= RemoveHealthPoint;
    }
}
