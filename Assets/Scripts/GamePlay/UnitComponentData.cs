using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Hierarchy;

public struct UnitComponentData : IComponentData
{
    public int HP;
    public int AttackDamage;
    public float AttackSpeed;
    public float AttackRange;
    public float MovemoentSpeed;
    
}
