using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public LayerMask hitLayer;
    public GameObject destroyer; // drag your explosion prefab here
    Animator c;
    bool left = true;
    int health = 5;
    public GameObject white;
    public GameObject swordman;
    float cooldown = 1.0f;
    string[] possibleSwords = { "SwordL", "Sword", "SwordR" };
   

    // Start is called before the first frame update
    void Start()
    {
        swordman = GameObject.Find("sword_man");
        c = GetComponent<Animator>();
        InvokeRepeating("changedirection", 0f, 5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        c.SetBool("walk", true);
        if (left)
        {
            transform.Translate(new Vector3(-2, 0, 0) * Time.deltaTime);
            if (transform.position.x - swordman.transform.position.x < 3 && transform.position.x - swordman.transform.position.x > 0 && cooldown < 0)
            {
                c.SetTrigger("attack");
                cooldown = 1;
            }
        }
        else
        {
            transform.Translate(new Vector3(2, 0, 0) * Time.deltaTime);
            if (swordman.transform.position.x  - transform.position.x < 3 && swordman.transform.position.x - transform.position.x > 0 && cooldown < 0)
            {
                c.SetTrigger("attack");
                cooldown = 1;
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, 5);
    //}

    void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.collider.gameObject.name == "Weapon-Sword" && swordman.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            health--;
        }
        RenderHealth();
        if (health == 0)
        {
            Instantiate(destroyer, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(this);
        }
        

        //Destroy(gameObject); // destroy the grenade
        //Destroy(expl, 3); // delete the explosion after 3 seconds


    }

    void RenderHealth()
    {
        white.transform.localScale = new Vector3(health, 1, 1);
    }

    public void changedirection()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        left = !left;
    }
}
