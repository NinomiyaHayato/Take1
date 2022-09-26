using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossMove : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _movespeed;
    [SerializeField] GameObject _boss;
    float _posAB;
    Vector3 _posA;
    Vector3 _posB;
    float _posAx;
    float _posBx;
    bool _bosschange = true;
    [SerializeField] float _bossstop;
    Animator _anim;
    [SerializeField] float _attackpoint;
    [SerializeField] GameObject _bossbullet;
    [SerializeField] Transform _shotposition;
    [SerializeField]public float _cooltime;
    float _totaltime;
    [SerializeField] float _bossmoverandom = 0.5f;
    float _addtime;//Playerがずっと近くにいる時のタイム計測
    [SerializeField] float _rimittime;//Playerが近づいていられる限界時間
    [SerializeField] float _rimitM;//PlayerにAddForceをかける距離（Distanceとの比較）
    [SerializeField] float _power;//Playerを突き放す力
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _totaltime = 0;
    }

    // Update is called once per frame
    void Update()
    {
            _posA = _boss.transform.position;
            _posB = GameObject.Find("Player").transform.position;
            _posAB = Vector3.Distance(_posA, _posB);
            if (_posAB < _rimitM)
            {
                _addtime += Time.deltaTime;
                Debug.Log("計測中");
                if (_addtime > _rimittime && _bosschange == true)
                {
                    Rigidbody2D _rbp = GameObject.Find("Player").GetComponent<Rigidbody2D>();
                    _rbp.AddForce(Vector2.right * _power, ForceMode2D.Impulse);
                    _addtime = 0;
                }
                else if (_addtime > _rimittime && _bosschange == false)
                {
                    Rigidbody2D _rbp = GameObject.Find("Player").GetComponent<Rigidbody2D>();
                    _rbp.AddForce(Vector2.left * _power, ForceMode2D.Impulse);
                    _addtime = 0;
                }
            }
            else if (_posAB > _rimitM)
            {
                _addtime = 0;
                Debug.Log("初期値です");
            }
            BossDerection();
            BossBehavior();
            Animations();
    }

    public void BossBehavior()
    {
        _totaltime -= Time.deltaTime;
        if(_totaltime <= 0)
        {
            var randam = Random.Range(0, 1f);
            if(randam > _bossmoverandom )
            {
                if (_posAB >= _bossstop && _bosschange == true)
                {
                    _rb.velocity = Vector2.right * _movespeed;
                    _totaltime = _cooltime;
                }
                else if (_posAB >= _bossstop && _bosschange == false)
                {
                    _rb.velocity = Vector2.left * _movespeed;
                    _totaltime = _cooltime;
                }
            }
            else if(randam < _bossmoverandom)
            {
                _anim.Play("BossAttack");
                Instantiate(_bossbullet, _shotposition.position, transform.localRotation);
                _totaltime = _cooltime;
            }
        }
           
    }
    public void BossDerection() // ボスの向き
    {
        _posAx = _posA.x;
        _posBx = _posB.x;
        if (_bosschange ==true && _posAx >= _posBx)
        {
            this.transform.Rotate(0f, 180f, 0f);
            _bosschange = false;
        }
       else if(_bosschange==false && _posAx <= _posBx)
        {
            this.transform.Rotate(0f, 180f, 0f);
            _bosschange = true;
        }
    }
    public void Animations()
    {
        if (_anim)
        {
            _anim.SetFloat("BossX", Mathf.Abs(_rb.velocity.x));
            _anim.SetBool("Attack", false);
        }
        if (_posAB < _attackpoint)
        {
            _anim.SetBool("Attack", true);
        }
        if(_posAB > _attackpoint)
        {
            _anim.SetBool("Attack", false);
        }
    }
}
