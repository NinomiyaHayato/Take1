using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterSpeed : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] GameObject _impactprehab;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = Vector2.right * _speed;
        _rb.rotation = 180f;
        Destroy(this.gameObject, 3f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(_impactprehab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
