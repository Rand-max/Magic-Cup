using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witchController : MonoBehaviour
{
    public int maxSpeed;

    public Animator witchani;

    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = 1;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveVertical ();
        SpellTrigger();
    }
    //idle 時上下浮動，移動速度大於0時則取消該函式
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
    //發射子彈
    void SpellTrigger()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            witchani.SetTrigger("spell");
            //CastSpell();        
        }
    }
}
