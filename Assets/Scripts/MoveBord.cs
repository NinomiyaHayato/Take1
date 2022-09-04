using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBord : MonoBehaviour
{
    PlayerWeapon _set;

    // Start is called before the first frame update
    void Start()
    {
        _set = GameObject.FindObjectOfType<PlayerWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(this.transform);
            _set._setParent = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
            _set._setParent = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //_set._setParent = true;
        }
    }
}
