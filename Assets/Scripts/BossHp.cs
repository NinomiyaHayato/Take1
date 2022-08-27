using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHp : MonoBehaviour
{
    [SerializeField] int _hp;
    [SerializeField] GameObject _deathEffectPrehab;
    [SerializeField] GameObject _background1;
    [SerializeField] GameObject _background2;
    [SerializeField] GameObject _createshot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp <= 0)
        {
            Instantiate(_deathEffectPrehab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (_hp < 50)
        {
            _background1.SetActive(false);
            _background2.SetActive(true);
            _createshot.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Buleet")
        {
            BossDamage(1);
        }
        else if(collision.gameObject.tag == "Buleet2")
        {
            BossDamage(3);
        }
    }
    public void BossDamage(int hp)
    {
        _hp -= hp;
    }
}