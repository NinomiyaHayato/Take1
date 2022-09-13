using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuleetI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float m_speed = 1f;

    void Start()
    {
        // ���x�x�N�g�������߂�
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            Vector2 v = player.transform.position - this.transform.position;
            v = v.normalized * m_speed;

            // ���x�x�N�g�����Z�b�g����
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = v;
            rb.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        }

    }
    private void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject, 0.5f);
        }
        else
        {
            Destroy(gameObject, 1f);
        }
    }
}
