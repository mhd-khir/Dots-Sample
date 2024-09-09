using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using Unity.Entities;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Rendering;

public class UnitAuthoring : MonoBehaviour
{
    [SerializeField] int UnitIndex;
    [SerializeField] bool isPlayer;
    [SerializeField] int TeamIndex;
    UnitData data;
    int HP, AttackDamage;
    float AttackSpeed, AttackRange, MovemoentSpeed;
    private void Start()
    {
        data = Gamemanager.Instance.GetData(isPlayer, UnitIndex);
        HP = data.HP;
        AttackDamage = data.AttackDamage;
        AttackSpeed = data.AttackSpeed;
        AttackRange = data.AttackRange;
        MovemoentSpeed = data.MovemoentSpeed;
    }
    public class UnitBaker : Baker<UnitAuthoring>
    {
        public override void Bake(UnitAuthoring authoring)
        {
            var entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
            AddComponent(entity, new UnitComponentData
            {
                HP = authoring.HP,
                AttackDamage = authoring.AttackDamage,
                AttackSpeed = authoring.AttackSpeed,
                AttackRange = authoring.AttackRange,
                MovemoentSpeed = authoring.MovemoentSpeed
            });
        }
    }
}

