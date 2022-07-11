using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject _player;
    float _attack;
    Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] float _attackrange;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _attack = Vector3.Distance(_player.transform.position, transform.position);
        Attack();
        
    }
    void Attack()
    {
        if(_attack < _attackrange)
        {
            _rb.velocity = Vector2.left.normalized * _speed;
        }
        else if (_attack > _attackrange)
        {
            _rb.velocity = Vector2.zero;
        }
    }
}
