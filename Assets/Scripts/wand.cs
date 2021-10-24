using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class wand : MonoBehaviour
{
    public float cooldownSpeed;

    public float fireRate;

    public float recoilCooldown;

    private float accuracy;

    public float maxSpreadAngle;

    public float timeTillMaxSpread;

    public float waitcd;

    public bool judgecd;

    public GameObject bullet;

    public GameObject shootPoint;

    public AudioSource gunshot;

    public AudioClip singleShot;

    
    // Start is called before the first frame update
    void Start()
    {
        judgecd = false;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownSpeed += Time.deltaTime * 60f;

        if (judgecd)
        {
            waitcd -= Time.deltaTime;
        }

        mate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            judgecd = true;    
        }
        else
        {
            recoilCooldown -= Time.deltaTime;
            if (recoilCooldown <= 1)
            {
                accuracy = 0.0f;
            }
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
    void acc()
    {
        accuracy += Time.deltaTime * 4f;

        if (cooldownSpeed >= fireRate)
        {
            Shoot();
            gunshot.PlayOneShot(singleShot);
            cooldownSpeed = 0;
            recoilCooldown = 1;
        }
    }
    void mate()
    {
        if (waitcd <= 0)
        {
            waitcd = 0;
        }
        if (waitcd == 0)
        {
            acc();
            judgecd = false;
            waitcd = 1.7f;
        }
    }
}