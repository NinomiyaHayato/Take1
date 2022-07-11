using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]public  float _hp = 100;
    [SerializeField] Text _gauge;
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Damage(1);
        }
        if(collision.gameObject.tag == "Enemy2")
        {
            Damage(2);
        }
    }
    public void Damage(int damage)
    {
        _hp -= damage;
    }
}
