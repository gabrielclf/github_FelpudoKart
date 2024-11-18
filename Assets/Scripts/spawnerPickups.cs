using UnityEngine;

public class spawnerPickups : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f, 1)]
        public float spawnChance;
    }

    public SpawnableObject[] objects;
    public float minSpawn = 1f;
    public float maxSpawn = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawn, maxSpawn));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
       float spawnChance = Random.value;

       foreach(var obj in objects)
       {
        if (spawnChance < obj.spawnChance){
            GameObject fruta = Instantiate(obj.prefab);
            fruta.transform.position += transform.position;
            break;
        }
        spawnChance -=obj.spawnChance;
       }
        Invoke(nameof(Spawn), Random.Range(minSpawn, maxSpawn));
    }
}
