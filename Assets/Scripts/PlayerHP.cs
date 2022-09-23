using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]public  float _hp = 100;
    [SerializeField] Text _gauge;
    [SerializeField] GameObject _plyerdestroy;
    float _addcooltime;
    [SerializeField] float _lordcooltime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _gauge.text = $"ENERUGY:{_hp}";
        if(_hp > 100)
        {
            _hp = 100;
        }
        if(_hp <= 0)
        {
            _addcooltime += Time.deltaTime;
            Instantiate(_plyerdestroy, transform.position, transform.rotation);
            Destroy(gameObject,0.6f);
            if(_addcooltime >= _lordcooltime)
            {
                SceneManager.LoadScene("GameOver");
            } 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Damage(3);
        }
        if(collision.gameObject.tag == "Enemy2")
        {
            Damage(3);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Boss1")
        {
            Damage(5);
        }
        else if(collision.gameObject.tag == "Boss2")
        {
            Damage(5);
        }
        else if(collision.gameObject.tag == "sea")
        {
            Damage(10);
        }
        else if(collision.gameObject.tag == "Auto")
        {
            Damage(5);
            Destroy(collision.gameObject);
        }
    }
    public void Damage(int damage)
    {
        _hp -= damage;
    }
}
