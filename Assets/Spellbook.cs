using System;
using System.Collections.Generic;
using UnityEngine;

public class Spellbook : MonoBehaviour
{
    [SerializeField] private List<SpellPage> pages;

    #region Properties

    public Spell CurrentSpell { get; private set; }
    
    private int _currentPage;
    public int CurrentPage
    {
        get => _currentPage;
        set
        {
            if (value < 0 || value >= pages.Count) return;
            _currentPage = value;
            // flip page animation
            CurrentSpell = pages[_currentPage].spell;
        }
    }

    #endregion

    #region Singleton Pattern

    public static Spellbook Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(this);
        
        DontDestroyOnLoad(this);
    }

    #endregion
}

public enum Spell
{
    Fireball,
    Slash,
    Shockwave
}
