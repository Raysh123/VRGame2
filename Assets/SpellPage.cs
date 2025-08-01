using UnityEngine;

[CreateAssetMenu(fileName = "SpellPage", menuName = "Scriptable Objects/SpellPage")]
public class SpellPage : ScriptableObject
{
    public GameObject spellPrefab;
    public Spell spell;
}
