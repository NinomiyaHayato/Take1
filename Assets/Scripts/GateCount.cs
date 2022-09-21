using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCount : MonoBehaviour
{
    public static int _gatecount = 0;
    SpriteRenderer _color;
    // Start is called before the first frame update
    void Start()
    {
        _color = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"||collision.gameObject.tag == "Buleet")
        { 
            _gatecount += 1;
            _color.color = new Color(1.0f, 0f, 0f, 0f);
        }
    }
}
