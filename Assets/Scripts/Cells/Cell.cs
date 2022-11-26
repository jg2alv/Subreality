using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class Cell : MonoBehaviour
{

    [Header("Cell properties")]
    [SerializeField] float size = 0.5f;
    [SerializeField] float speed = 0.05f;
    [SerializeField] float reproductionSuccessRate = 0.5f;

    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(Random.Range(transform.position.x - 5, transform.position.x + 5), transform.position.y, Random.Range(transform.position.z - 5, transform.position.z + 5));
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
            pos = new Vector3(Random.Range(transform.position.x - 5, transform.position.x + 5), transform.position.y, Random.Range(transform.position.z - 5, transform.position.z + 5));
        }
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Cell")){
            GameObject spawner = GameObject.Find("Spawner");
            float reproduction = Random.Range(0f, 1f);

            if(reproduction < reproductionSuccessRate){
                spawner.GetComponent<Spawner>().cells--;
                Destroy(this.gameObject);
            } else {
                Instantiate(gameObject, new Vector3(Random.Range(-250, 250), 0.5f, Random.Range(-250, 250)), Quaternion.identity);
                spawner.GetComponent<Spawner>().cells++;
            }
        }
    }
}
