using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Jobs;

public partial class MoveSystem : SystemBase
{
  protected override void OnUpdate()
  {
    List<Entity> entities = new();
    Entities.WithName("MoveSystem").ForEach((ref Translation position, ref Rotation rotation) =>
    {
      position.Value.y += .1f;
      if (position.Value.y > 100)
        position.Value.y = 0;
    }).ScheduleParallel();
  }
}
