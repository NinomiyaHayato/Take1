using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoeE2 : MonoBehaviour
{
    Transform _player;
    Rigidbody2D _rb;
    [SerializeField] float _stop;
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _moveSpeed2;
    [SerializeField] float _shootstop;
    [SerializeField] GameObject _shotBuleet;
    [SerializeField] float _cooltime;
    float _time;
    [SerializeField] GameObject _shotposition;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player)
        {
            float _distance1 = Vector2.Distance(_player.position, this.transform.position);
            Debug.Log("’l‚ªŽæ“¾‚Å‚«‚Ä‚¢‚Ü‚·");
            if (_distance1 > _stop)
            {
                Vector3 dir1 = (_player.position - this.transform.position).normalized * _moveSpeed;
                _rb.velocity = dir1.normalized * _moveSpeed2;
                if (_player.position.x < this.transform.position.x)
                {
                    this.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
                }
                else if (_player.position.x > this.transform.position.x)
                {
                    this.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                }
            }
            if(_distance1 <_shootstop)
            {
                _rb.velocity = Vector2.zero;
                _time += Time.deltaTime;
                if (_time > _cooltime)
                {
                    Instantiate(_shotBuleet, _shotposition.transform.position, transform.localRotation);
                    _time = 0;
                }
                if (this.transform.position.x < _player.transform.position.x)
                {
                    this.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                }
                else if (this.transform.position.x > _player.transform.position.x)
                {
                    this.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            _player = collision.gameObject.transform;
        }
    }
}
