using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class movingspell : MonoBehaviour
{
    public Vector3 hitPoint;

    public GameObject dirt;

    public GameObject blood;

    public int speed;

    public float jikan;

    //public AudioSource myShot;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce((hitPoint - this.transform.position).normalized * speed);
        jikan = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        jikan -= Time.deltaTime;
        if (jikan == 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<monsterhealth>().currentHealth -= 20;
            GameObject newBlood = Instantiate(blood, this.transform.position, this.transform.rotation);
            newBlood.transform.parent = col.transform;
            Destroy(this.gameObject);
        }
        
        else
        {
            Instantiate(dirt, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }
}