using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSS : MonoBehaviour
{
    Rigidbody2D _shot;
    [SerializeField] float _speed;
    [SerializeField] GameObject _impactprehab;
    // Start is called before the first frame update
    void Start()
    {
        _shot = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _shot.velocity = Vector2.down * _speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(_impactprehab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
