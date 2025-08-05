using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spellbook : MonoBehaviour
{
    [SerializeField] private List<SpellPage> pages;
    [SerializeField] private TextMeshProUGUI debugSpellNameTMP;

    #region Properties

    private Spell _currentSpell;
    public Spell CurrentSpell
    {
        get => _currentSpell;
        private set
        {
            _currentSpell = value;
            debugSpellNameTMP.text = $"Active Spell: {_currentSpell.ToString()}";
        }
    }
    
    private int _currentPage;
    public int CurrentPage
    {
        get => _currentPage;
        set
        {
            if (value < 0 || value >= pages.Count) return;
            _currentPage = value;
            CurrentSpell = pages[_currentPage].spellName;
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

    private void Start()
    {
        CurrentPage = 0;
    }
}

public enum Spell
{
    Fireball,
    Slash,
    Shockwave
}
