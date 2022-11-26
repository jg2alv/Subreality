using System.Collections;
using System.Collections.Generic;
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
            float reproduction = Random.Range(0f, 1f);

            if(reproduction < reproductionSuccessRate){
                Destroy(this.gameObject);
            } else {
                Instantiate(gameObject, transform.position * 1.1f, Quaternion.identity);
            }
        }
    }
}
