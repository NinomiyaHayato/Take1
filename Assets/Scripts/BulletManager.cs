using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField]public float _speed;
    Rigidbody2D _rb;
    [SerializeField] GameObject _impactPrehab;
    // Start is called before the first frame update
    void Start()
    {
        _rb = transform.GetComponent<Rigidbody2D>();
        _rb.velocity = transform.right * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy"||collision.gameObject.tag=="Boss2")
        {
            Instantiate(_impactPrehab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
    
}
