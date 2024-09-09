using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

/*public partial struct CubeSystem : ISystem
{ 
    public void OnUpdate(ref SystemState state)
    {
        var job = new CubJob
        {
            deltaTime = SystemAPI.Time.DeltaTime
        };
        job.ScheduleParallel();
    }
}

public partial struct CubJob : IJobEntity
{
    public float deltaTime;
    public void Execute(ref UnitComponentData data , ref LocalTransform localTransform)
    {
        localTransform = localTransform.RotateY(math.radians(cubeData.speed * deltaTime));
    }
}*/


public partial class CubeSystem : SystemBase
{
    float timer;
    protected override void OnUpdate()
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        foreach (var (unit, transform) in SystemAPI.Query<RefRO<UnitComponentData>, RefRW<LocalTransform>>())
        {
            timer = unit.ValueRO.MovemoentSpeed;
            timer -= deltaTime;
            if (timer <= 0)
            {
                transform.ValueRW = transform.ValueRO.Translate(math.radians(unit.ValueRO.MovemoentSpeed * deltaTime));
            }
        }
    }
   
}

