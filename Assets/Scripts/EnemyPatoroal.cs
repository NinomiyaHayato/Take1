using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatoroal : MonoBehaviour
{
    [SerializeField] Transform[] _target;
    [Tooltip("�I�u�W�F�N�g�̈ړ����x")]
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _moveSpeed2;
    [Tooltip("�^�[�Q�b�g�ɓ��B�����Ɣ��f���鋗���i�P��:���[�g���j")]
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
            Debug.Log("�l���擾�ł��Ă��܂�");
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
        if (_distance > _stoppingDistance && _player == null)  // �^�[�Q�b�g�ɓ��B����܂ŏ�������
        {
            Vector3 dir = (_target[_targetindex % 3].position - this.transform.position).normalized * _moveSpeed;// �ړ������̃x�N�g�������߂�
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
