using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyShooter : MonoBehaviour
{
    [SerializeField] GameObject _shotBuleet;
    [SerializeField] float _cooltime;
    float _time;
    [SerializeField] GameObject _shotposition;
    Transform _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(_player)
        {
            _time += Time.deltaTime;
            if (_time > _cooltime)
            {
                    Instantiate(_shotBuleet, _shotposition.transform.position, transform.localRotation);
                    _time = 0;
            }
            if(this.transform.position.x < _player.transform.position.x)
            {
                this.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
            }
            else if (this.transform.position.x > _player.transform.position.x)
            {
                this.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _player = collision.gameObject.transform;
        }
    }
}
