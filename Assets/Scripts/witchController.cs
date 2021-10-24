using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witchController : MonoBehaviour
{
    public int maxSpeed;
    public float cooldownSpeed;

    public float fireRate;

    public float recoilCooldown;

    private float accuracy;

    public float maxSpreadAngle;

    public float timeTillMaxSpread;

    public GameObject bullet;

    public GameObject shootPoint;

    public AudioSource gunshot;

    public AudioClip singleShot;

    public float countdown;

    public Animator witchani;
    public AudioSource ad;

    private Vector3 startPosition;


    // Use this for initialization
    void Start () 
    {
        maxSpeed = 1;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        MoveVertical ();
        SpellTrigger();
    }

    void MoveVertical()
    {
        
        transform.position = new Vector3(transform.position.x, startPosition.y + Mathf.Sin(Time.time * maxSpeed), transform.position.z);

        if(transform.position.y > 0.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else if(transform.position.y < -0.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
    void Shoot()
    {
        RaycastHit hit;

        Quaternion fireRotation = Quaternion.LookRotation(transform.forward);

        float currentSpread = Mathf.Lerp(0.0f, maxSpreadAngle, accuracy / timeTillMaxSpread);

        fireRotation = Quaternion.RotateTowards(fireRotation, Random.rotation, Random.Range(0.0f, currentSpread));

        if (Physics.Raycast(transform.position, fireRotation * Vector3.forward, out hit, Mathf.Infinity))
        {
            GameObject tempBullet = Instantiate(bullet, shootPoint.transform.position, fireRotation);
            tempBullet.GetComponent<movingspell>().hitPoint = hit.point;
        }
    }
    //void CastSpell()
    //{
    //    accuracy += Time.deltaTime * 4f;
    //    if (cooldownSpeed >= fireRate)
    //    {
    //        Shoot();
    //        gunshot.PlayOneShot(singleShot);
    //        cooldownSpeed = 0;
    //        recoilCooldown = 1;
    //    }
    //    else
    //    {
    //        recoilCooldown -= Time.deltaTime;
    //        if (recoilCooldown <= 1)
    //        {
    //            accuracy = 0.0f;
    //        }
    //    }
    //}
    void SpellTrigger()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            witchani.SetTrigger("spell");
            ad.Play();
            //CastSpell();        
        }
    }
    void County()
    {
        countdown -= Time.deltaTime;
    }
}
