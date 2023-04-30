using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [Header("Health&Mana")]
    public float _maxHealth;
    public float _currentHealth;
    public float _maxMana;
    public float _currentMana;
    [Header("SpellPowers")]
    public int _spellPower;
    [Header("OtherStats")]
    public int _movementSpeed;
    public float _dashLenght;
    public int _jumpHeight;
    public bool _canUseIce;
    public bool _canUseFire;
    public bool _canDoubleJump;

}
