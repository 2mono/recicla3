using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TargetBounds : MonoBehaviour
{
    [SerializeField] BoxCollider col;
    [SerializeField] GameObject prefab;
    [SerializeField] private int prefabCount;
    private List<Prefab> prefabList;
    public static TargetBounds Instance;
    public bool spawnerOn = false;


    public class Prefab
    {
        public Vector3 transform;
        public float moveY;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (spawnerOn) 
            Invoke("PrefabInstantiate",2f);
        
    }

    public Vector3 GetRandomPosition()
    {
        Vector3 center = col.center + transform.position;

        float minX = center.x - col.size.x / 2f;
        float maxX = center.x + col.size.x / 2f;

        float minY = center.y - col.size.y / 2f;
        float maxY = center.y + col.size.y / 2f;

        float minZ = center.z - col.size.z / 2f;
        float maxZ = center.z - col.size.z / 2f;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

        return randomPosition;
    }

    public void PrefabInstantiate()
    {
        var prefabPosition = GetRandomPosition();
        Instantiate(prefab, prefabPosition, Quaternion.identity);
    }
}
