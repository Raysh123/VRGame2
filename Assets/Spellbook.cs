using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spellbook : MonoBehaviour
{
    [SerializeField] private List<SpellPage> pages;
    [SerializeField] private TextMeshProUGUI debugSpellNameTMP;
    [SerializeField] private GameObject rightHand;
    [SerializeField] Animator spellbookAnimator;

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
            
            // TODO: string lookup SUCKS, hash this or something
            spellbookAnimator.Play(value > _currentPage ? "FlipForward" : "FlipBackward");
            
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
        _currentPage = 0;
        CurrentSpell = pages[_currentPage].spellName;
    }

    // make private and use event subscription instead
    public void CastActiveSpell()
    {
        Debug.Log("Casting active spell");
        Instantiate(
            original: pages[CurrentPage].spellPrefab, 
            position: rightHand.transform.position + new Vector3(0.1f, 0, 0.25f), 
            rotation: rightHand.transform.rotation, 
            parent: transform.parent);
    }
}

public enum Spell
{
    Fireball,
    Slash,
    Shockwave
}
