using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevetorHead : MonoBehaviour
{
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _anim.SetTrigger("Headup");
        }
    }
}
