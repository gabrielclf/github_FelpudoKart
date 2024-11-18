using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoSpawner : MonoBehaviour
{
    public GameObject inimigo;
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
        float chanceSpawn = Random.value;
        if (chanceSpawn > 0.7f)
        {
            GameObject obstaculo = Instantiate(inimigo);
            obstaculo.transform.position += transform.position;
        }
    Invoke(nameof(Spawn),Random.Range(minSpawn,maxSpawn));
    }
}