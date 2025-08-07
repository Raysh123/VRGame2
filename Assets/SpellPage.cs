using UnityEngine;

[CreateAssetMenu(fileName = "SpellPage", menuName = "Scriptable Objects/SpellPage")]
public class SpellPage : ScriptableObject
{
    public GameObject spellPrefab;
    public Spell spellName;
    public float rechargeTime = 1f;
}
