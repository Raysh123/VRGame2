using System.Collections.Generic;
using UnityEngine;

public class Spellbook : MonoBehaviour
{
    [SerializeField] private List<SpellPage> pages;
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
}

public enum Spell
{
    Fireball,
    Slash,
    Shockwave
}
