﻿using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

public class AssignPlayerToTargetSystem : SystemBase
{

    protected override void OnStartRunning()
    {
        base.OnStartRunning();
        AssignPlayer();
    }

    protected override void OnUpdate()
    {

    }

    private void AssignPlayer()
    {
        EntityQuery playerQuery = GetEntityQuery(ComponentType.ReadOnly<PlayerTag>());
        Entity playerEntity = playerQuery.GetSingletonEntity();

        Entities.
            WithAll<ChaserTag>().
            ForEach((ref TargetData targetData) =>
            {
                if (playerEntity != Entity.Null)
                {
                    targetData.targetEntity = playerEntity;
                }

            }).Schedule();


    }
}