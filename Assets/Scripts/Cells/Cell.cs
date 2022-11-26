using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class Cell : MonoBehaviour
{

    [Header("Cell properties")]
    [SerializeField] int level = 1;
    [SerializeField] float size = 0.5f;
    [SerializeField] float speed = 0.05f;
    [SerializeField] float reproductionSuccessRate = 0.5f;
    [SerializeField] float radius = 5f;

    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(Random.Range(transform.position.x - radius, transform.position.x + radius), transform.position.y, Random.Range(transform.position.z - radius, transform.position.z + radius));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != pos)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, speed);
        }
        else
        {
            pos = new Vector3(Random.Range(transform.position.x - radius, transform.position.x + radius), transform.position.y, Random.Range(transform.position.z - radius, transform.position.z + radius));
        }
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Cell")){
            GameObject spawner = GameObject.Find("Spawner");
            float reproduction = Random.Range(0f, 1f);

            Cell parent1 = collision.transform.gameObject.GetComponent<Cell>();
            Cell parent2 = this;

            if(reproduction < reproductionSuccessRate){
                spawner.GetComponent<Spawner>().cells--;
                Destroy(this.gameObject);
            } else {
                int numberOfChildren = Random.Range(1, 2);

                for(int i = 0; i < numberOfChildren; i++){
                    Cell newCell = Instantiate(gameObject, new Vector3(Random.Range(-250, 250), 0.5f, Random.Range(-250, 250)), Quaternion.identity).GetComponent<Cell>();
                    float r = (parent1.gameObject.GetComponent<Renderer>().material.color.r + parent2.gameObject.GetComponent<Renderer>().material.color.r)/2;
                    float g = (parent1.gameObject.GetComponent<Renderer>().material.color.g + parent2.gameObject.GetComponent<Renderer>().material.color.g)/2;
                    float b = (parent1.gameObject.GetComponent<Renderer>().material.color.b + parent2.gameObject.GetComponent<Renderer>().material.color.b)/2;
                    
                    newCell.level = parent1.level + parent2.level;
                    newCell.gameObject.GetComponent<Renderer>().material.color = new Color(r, g, b);
                    newCell.radius = Random.Range(parent1.radius, parent1.radius + parent2.radius);
                    spawner.GetComponent<Spawner>().cells++;
                }
            }
        }
    }
}
