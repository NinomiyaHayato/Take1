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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _time += Time.deltaTime;
        if(_time >_cooltime)
        {
            if (collision.gameObject.tag == "Player")
            {
                Instantiate(_shotBuleet, _shotposition.transform.position, transform.localRotation);
                _time = 0;
            }
        }
    }
}
