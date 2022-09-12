using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITween : MonoBehaviour
{
    public static int _gatecount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _gatecount += 1;
        }
    }
}
