using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();

    private GameObject effecttoSpawn;
    // Start is called before the first frame update
    void Start()
    {
        effecttoSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnVfxEffect();
        }
    }
    void SpawnVfxEffect()
    {
        GameObject vfx;
        if (firePoint == null)
        {
            vfx = Instantiate(effecttoSpawn, firePoint.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("no fire");
        }
    }
}
