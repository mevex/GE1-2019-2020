using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    Transform child;
    // Start is called before the first frame update
    void Start()
    {
        child = transform.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {
            transform.Translate(Random.Range(-0.3f, 0.3f), Random.Range(10.0f, 100.0f) * Time.deltaTime, Random.Range(-0.3f, 0.3f));
            child.transform.Translate(Random.Range(-0.3f, 0.3f), Random.Range(10.0f, 100.0f) * Time.deltaTime, Random.Range(-0.3f, 0.3f));
            child.gameObject.AddComponent<Rigidbody>();
            child.transform.parent = null;

            Invoke("FallAndDestroy", 2);
        }
    }

    void FallAndDestroy()
    {
        Destroy(GetComponent<BoxCollider>());
        Destroy(child.gameObject, 2);
        Destroy(gameObject, 2);
    }
}
