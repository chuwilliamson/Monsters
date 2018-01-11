using UnityEngine;


[CreateAssetMenu]
class Weapon : ScriptableObject
{
    public float damage;
}

[CreateAssetMenu]
class Consumable : ScriptableObject
{
    public int heal;
}

[CreateAssetMenu]
class KeyItems : ScriptableObject
{
    bool important = false;
}

[CreateAssetMenu]
class Distraction : ScriptableObject
{
    bool distract = false;
}