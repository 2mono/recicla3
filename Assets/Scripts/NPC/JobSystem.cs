using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Jobs;
using UnityEngine;
using Unity.Collections;
using Unity.Burst;
using UnityEngine.Jobs;



public class JobSystem : MonoBehaviour
{
    [SerializeField] private bool useJobs;
    [SerializeField] private Transform prefab;
    [SerializeField] private int prefabCount;
    [SerializeField] private float xLimitL, xLimitR, zLimitL, zLimitR,yRelease;
    [SerializeField] private bool debug;
    private List<Prefab> prefabList;
    

    public class Prefab
    {
        public Transform transform;
        public float moveY;
    }

    private void Start()
    {
        prefabList = new List<Prefab>();
        for (int i = 0; i < prefabCount; i++)
        {
            Transform prefabTransform = Instantiate(prefab, new Vector3(UnityEngine.Random.Range(xLimitL, xLimitR), yRelease, UnityEngine.Random.Range(zLimitL, zLimitR)), Quaternion.identity);
            prefabList.Add(new Prefab
            {
                transform = prefabTransform,
            });
        }
    }

    void Update()
    {
        float startTime = Time.realtimeSinceStartup;
        if (useJobs)
        {
            NativeArray<float> moveYArray = new NativeArray<float>(prefabList.Count, Allocator.TempJob);
            TransformAccessArray transformAccessArray = new TransformAccessArray(prefabList.Count);

            for (int i = 0; i < prefabList.Count; i++)
            {
                moveYArray[i] = prefabList[i].moveY;
                transformAccessArray.Add(prefabList[i].transform);
            }

            SpawnerParallelJobTransform spawnerParallelJobTransform = new SpawnerParallelJobTransform
            {
                deltaTime = Time.deltaTime,
                moveYArray = moveYArray,
            };

            JobHandle jHandle = spawnerParallelJobTransform.Schedule(transformAccessArray);
            jHandle.Complete();
            for (int i = 0; i < prefabList.Count; i++)
            {
                prefabList[i].moveY = moveYArray[i];
            }
            moveYArray.Dispose();
            transformAccessArray.Dispose();
        }
        else
        {
            foreach (Prefab prefab in prefabList)
            {
                prefab.transform.position += new Vector3(0, prefab.moveY * Time.deltaTime);
                if (prefab.transform.position.y > 5f)
                {
                    prefab.moveY = -math.abs(prefab.moveY);
                }
                if (prefab.transform.position.y < -5f)
                {
                    prefab.moveY = +math.abs(prefab.moveY);
                }
                float value = 0f;
                for (int i = 0; i < 1000; i++)
                {
                    value = math.exp10(math.sqrt(value));
                }
            }
        }
        if(debug)Debug.Log(((Time.realtimeSinceStartup - startTime) * 1000f) + "ms");
    }

    [BurstCompile]
    public struct SpawnerParallelJobTransform : IJobParallelForTransform
    {
        public NativeArray<float> moveYArray;
        [ReadOnly] public float deltaTime;
        public void Execute(int index, TransformAccess transform)
        {
            transform.position += new Vector3(0, moveYArray[index] * deltaTime, 0f);
            if (transform.position.y > 5f)
            {
                moveYArray[index] = -math.abs(moveYArray[index]);
            }
            if (transform.position.y < -5f)
            {
                moveYArray[index] = +math.abs(moveYArray[index]);
            }
        }
    }
}

