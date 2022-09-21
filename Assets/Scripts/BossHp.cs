using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BossHp : MonoBehaviour
{
    [SerializeField] int _hp = 100;
    [SerializeField] GameObject _deathEffectPrehab;
    [SerializeField] GameObject _background1;
    [SerializeField] GameObject _background2;
    [SerializeField] GameObject _createshot;
    BossMove _cooltime2;
    [SerializeField]AudioSource _audio1;
    [SerializeField]AudioSource _audio2;
    // Start is called before the first frame update
    void Start()
    {
        _cooltime2 = GameObject.FindObjectOfType<BossMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp <= 0)
        {
            Instantiate(_deathEffectPrehab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (_hp <= 50)
        {
            _background1.SetActive(false);
            _background2.SetActive(true);
            _createshot.SetActive(true);
            _cooltime2._cooltime = 2f;
        }
        if(_hp > 50)
        {
            _audio2.Pause();
        }
        else if(_hp < 50)
        {
            _audio1.Stop();
            _audio2.UnPause();
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