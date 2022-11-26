using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int startingCells;
    [SerializeField] GameObject cellPrefab;

    [SerializeField] Text cellCounter;
    public int cells;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < startingCells; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), 0.5f, Random.Range(-10, 10));
            GameObject startingCell = Instantiate(cellPrefab, spawnPosition, Quaternion.identity);
            cells++;

            startingCell.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        cellCounter.text = cells.ToString();
    }   
}
