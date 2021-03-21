using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "Shadow" || child.gameObject.name == "Hip" || child.gameObject.name == "HP")
            {
                Destroy(child.gameObject);
            }
            else
            {
                child.gameObject.AddComponent<BoxCollider2D>();
                Rigidbody2D rigid = child.gameObject.AddComponent<Rigidbody2D>();
                rigid.AddForce(new Vector3(child.position.x - transform.position.x, child.position.y - transform.position.y, 0) * 1000.0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
