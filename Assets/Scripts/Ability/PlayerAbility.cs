using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbility : ScriptableObject
{
    public string abilityName;
    public float damage;
    public float speed;
    public AbilityType type;
}

public enum AbilityType
{
    Shoot,
    RotateAround
}
