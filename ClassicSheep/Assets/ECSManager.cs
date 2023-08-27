using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Rendering;

public class ECSManager : MonoBehaviour
{
  EntityManager manager;
  public GameObject sheepPrefab;
  const int numSheep = 15000;
  // Start is called before the first frame update
  void Start()
  {
    manager = World.DefaultGameObjectInjectionWorld.EntityManager;
    var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
    var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(sheepPrefab, settings);

    for (int i = 0; i < numSheep; i++)
    {
       var instance = manager.Instantiate(prefab);
    //   instance = manager.CreateEntity(
    //   ComponentType.ReadOnly<LocalToWorld>(),
    //   ComponentType.ReadOnly<RenderMesh>(),
    //   ComponentType.ReadOnly<RenderBounds>(),
    //   ComponentType.ReadWrite<Translation>(),
    //   ComponentType.ReadWrite<Rotation>()
    //   );
    //   manager.SetComponentData(
    //   instance,
    //   new RenderBounds
    //   {
    //     Value = new AABB()
    //   });
       var position = transform.TransformPoint(new float3(UnityEngine.Random.Range(-50, 50), 0, UnityEngine.Random.Range(-50, 50)));
       manager.SetComponentData(instance, new Translation { Value = position });
       manager.SetComponentData(instance, new Rotation { Value = new quaternion(0, 0, 0, 0) });
    //manager.SetComponentData(entity, new Translation { Value = position });

      //
      //var blobAssetStore = new BlobAssetStore();
    //GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(defaultWorld, blobAssetStore);
    //Entity entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(sheepPrefab, settings);
    //Entity entity = manager.Instantiate(prefab);
      //Debug.Log("pup man");
    }
  }
//   private void InstantiateEntity(float3 position)
//   {
//     var blobAssetStore = new BlobAssetStore();
//     GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(defaultWorld, blobAssetStore);
//     Entity entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(gameObjectPrefab, settings);
//     Entity entity = entityManager.Instantiate(entityPrefab);
//     entityManager.SetComponentData(entity, new Translation { Value = position });
//   }
}
