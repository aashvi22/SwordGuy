using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{

    Animator a;
    bool b = false;
    public GameObject White;
    private float health = 3;
    public GameObject destroyer;
    public GameObject DarkKnight;
    public GameObject Ninja;
    bool alive = true;
    bool swing = false;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
        InvokeRepeating("Spawn", 0.0f, 10.0f);
        gameObject.layer = LayerMask.NameToLayer("Default");
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            a.SetBool("attack", true);
            //gameObject.layer = LayerMask.NameToLayer("Collision");
            swing = true;
        }
        else
        {
            a.SetBool("attack", false);
            //gameObject.layer = LayerMask.NameToLayer("Default");
            swing = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            a.SetTrigger("jump");
            Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(transform.up * 500000000);
        }

        if (Input.GetKey("left"))
        {
            if (b == true)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                b = false;
            }
            a.SetTrigger("run");
            transform.Translate(new Vector3(-3, 0, 0) * Time.deltaTime);
        }

        if (Input.GetKey("right"))
        {
            if (b == false)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                b = true;
            }
            a.SetTrigger("run");
            transform.Translate(new Vector3(3, 0, 0) * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D Col)
    {
        ////Debug.Log(Col.collider.gameObject.transform.parent.name);
        //if (Col.collider.gameObject.name != "Sword" && Col.collider.gameObject.name != "SwordL" && Col.collider.gameObject.name != "SwordR")
        //{
        //    return;
        //}
        //if (Col.contacts[0].collider.transform.gameObject.name == "Weapon-Sword") return;
        //    health -= .1f;
        //RenderHealth();
        //if (health > 0) return;
        //if (alive == false)
        //{
        //    text.SetActive(true);
        //    return;
        //}
        //alive = false;
        //Instantiate(destroyer, transform.position, transform.rotation);
        //Destroy(gameObject);
        //Destroy(this);


        if (Col.collider.gameObject.name == "Sword" || Col.collider.gameObject.name == "SwordL" || Col.collider.gameObject.name == "SwordR")
        {
            health-=0.1f;
            RenderHealth();
        }
        if (health < 0.1f)
        {
            text.SetActive(true); 
            Instantiate(destroyer, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(this);
        }
    }

    void RenderHealth()
    {
        White.transform.localScale = new Vector3(health, 1, 1);
    }
    public bool GetSwing()
    {
        return swing;
    }
    void Spawn()
    {
        float randomx = Random.Range(-14, 14);
        if (Random.Range(-1.0f, 1.0f) > 0)
        {
            Instantiate(DarkKnight, new Vector3(randomx, -3.8f, -2), Quaternion.identity);
        }
        else
        {
            Instantiate(Ninja, new Vector3(randomx, -3.8f, -2), Quaternion.identity);
        }
    }
}
