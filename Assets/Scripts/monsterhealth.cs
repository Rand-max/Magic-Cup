using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterhealth : MonoBehaviour
{
    public int currentHealth;
    public float cooldown;
    public GameObject smoke;
    public GameObject kaboom;
    public GameObject par;
    public GameObject groundsmoke;
    public GameObject mark;
    public AudioSource exp;
    public bool alive;

    private GameObject sm;
    private GameObject kb;
    private GameObject pr;
    private GameObject gs;
    private GameObject mk;
    
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {  
        if (currentHealth <= 0)
        {
            countdown();
            if (alive)
            {
                alive = false;
                if (!alive)
                {
                    exp.Play();
                    Create();
                }
            }     
        }     
        if (cooldown<=0)
        {
            erase();
        }
    }
    void Create()
    {
        sm= Instantiate(smoke, this.transform.position, Quaternion.identity);
        kb=Instantiate(kaboom, this.transform.position, Quaternion.identity);
        pr =Instantiate(par, this.transform.position, Quaternion.identity);
        gs =Instantiate(groundsmoke, this.transform.position, Quaternion.identity);
        mk=Instantiate(mark, this.transform.position, Quaternion.identity);
    }
    void countdown()
    {
        cooldown -= Time.deltaTime;
    }
    void erase()
    {
        Destroy(this.gameObject);
        Destroy(sm);
        Destroy(kb);
        Destroy(pr);
        Destroy(gs);
        Destroy(mk);
    }
}