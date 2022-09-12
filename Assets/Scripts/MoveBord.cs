using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBord : MonoBehaviour
{
    PlayerWeapon _set;
    Transform _player;
    // Start is called before the first frame update
    void Start()
    {
        //_set = GameObject.FindObjectOfType<PlayerWeapon>();
        _set = GameObject.Find("Player").GetComponent<PlayerWeapon>();
        _player = GameObject.Find("Main").transform;
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
            collision.gameObject.transform.SetParent(_player);
            
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
