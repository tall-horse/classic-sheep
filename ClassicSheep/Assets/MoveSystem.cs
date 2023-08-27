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
      position.Value += .1f * math.forward(rotation.Value);
      if (position.Value.z > 50)
        position.Value.z = -50;
    }).ScheduleParallel();
  }
}
