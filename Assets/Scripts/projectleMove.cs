using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectleMove : MonoBehaviour
{
    public float speed;
    public float firerate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("no speed");
        }
    }
}
