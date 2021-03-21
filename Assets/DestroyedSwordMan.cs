using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedSwordMan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<BoxCollider2D>();
            Rigidbody2D rigid = child.gameObject.AddComponent<Rigidbody2D>();
            rigid.AddForce(new Vector3(child.position.x - transform.position.x, child.position.y - transform.position.y, 0) * 500.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
