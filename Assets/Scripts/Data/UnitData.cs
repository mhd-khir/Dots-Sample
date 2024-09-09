
using NUnit.Framework;
using System.Collections.Generic;

[System.Serializable]
public class UnitData
{
    public int HP;
    public int AttackDamage;
    public float AttackSpeed;
    public float AttackRange;
    public float MovemoentSpeed;
}

[System.Serializable]
public class TeamData
{
    public List<UnitData> UnitData;
}