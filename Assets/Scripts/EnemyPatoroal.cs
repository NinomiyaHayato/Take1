using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatoroal : MonoBehaviour
{
    [SerializeField] Transform[] _target;
    [Tooltip("オブジェクトの移動速度")]
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _moveSpeed2;
    [Tooltip("ターゲットに到達したと判断する距離（単位:メートル）")]
    [SerializeField] float _stoppingDistance = 0.05f;
    [SerializeField] float _stop;
    int _targetindex = 0;
    Transform _player;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        //_player = GameObject.Find("Player").transform.position;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        float _distance = Vector2.Distance(this.transform.position, _target[_targetindex % 3].position);
        if (_player)
        {
            float _distance1 = Vector2.Distance(_player.position, this.transform.position);
            Debug.Log("値が取得できています");
            if (_distance1 > _stop)
            {
                Vector3 dir1 = (_player.position - this.transform.position).normalized * _moveSpeed;
                _rb.velocity = dir1.normalized * _moveSpeed2;
                if(_player.position.x > this.transform.position.x)
                {
                    this.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
                }
                else if(_player.position.x < this.transform.position.x)
                {
                    this.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                }
            }
        }
        if (_distance > _stoppingDistance && _player == null)  // ターゲットに到達するまで処理する
        {
            Vector3 dir = (_target[_targetindex % 3].position - this.transform.position).normalized * _moveSpeed;// 移動方向のベクトルを求める
            _rb.velocity = dir * _moveSpeed;
        }
        else
        {
            _targetindex++;
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
