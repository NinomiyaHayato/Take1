using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuleetI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float m_speed = 1f;
    [SerializeField] GameObject _impactprehab;
    void Start()
    {
        // 速度ベクトルを求める
        GameObject _player = GameObject.FindGameObjectWithTag("Player");
        if (_player)
        {
            Vector2 v = _player.transform.position - this.transform.position;
            v = v.normalized * m_speed;

            // 速度ベクトルをセットする
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = v;
            //rb.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        }
        if (_player.transform.position.x > this.transform.position.x)
        {
            this.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else if(_player.transform.position.x < this.transform.position.x)
        {
            this.transform.rotation = new Quaternion(0f,90f, 0f, 0f);
        }
    }
    private void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(_impactprehab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(gameObject, 1f);
        }
    }
}
