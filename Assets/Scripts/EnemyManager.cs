using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] int _hp;
    [SerializeField] GameObject _deathEffectPrehab;
    AudioSource _deathaudio;
    [SerializeField] AudioClip _audio;
    // Start is called before the first frame update
    void Start()
    {
        _deathaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_hp <= 0)
        {
            Instantiate(_deathEffectPrehab, transform.position, transform.rotation);
            _deathaudio.PlayOneShot(_audio);
            Destroy(gameObject,0.1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Buleet")
        {
            Playerdamage(1);
        }
        else if(collision.gameObject.tag == "Buleet2")
        {
            Playerdamage(3);
        }
    }
    public void Playerdamage(int hp)
    {
        _hp -= hp;
    }
}
