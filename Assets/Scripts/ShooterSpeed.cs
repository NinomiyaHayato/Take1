using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterSpeed : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _speed;
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
}
