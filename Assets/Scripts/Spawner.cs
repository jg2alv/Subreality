using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int startingCells;
    [SerializeField] GameObject cellPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < startingCells; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), 0.5f, Random.Range(-10, 10));
            Instantiate(cellPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
