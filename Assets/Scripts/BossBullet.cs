using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] GameObject _impactprehab;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(_impactprehab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
