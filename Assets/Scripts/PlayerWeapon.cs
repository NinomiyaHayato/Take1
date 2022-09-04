using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerWeapon : MonoBehaviour
{
    Animator _animator;
    [SerializeField] GameObject _BulletPrehab;
    [SerializeField] GameObject _BulletPrehab2;
    [SerializeField] Transform _shotPoint;
    bool _isright;

    [SerializeField]public float _movepower;
    [SerializeField]public float _jumppower;
    Rigidbody2D _rb;
    Vector2 _vel = default;
    int _count;
    [SerializeField] Text _shot2;
    Vector3 _position;
    bool _canjump = true;
    List<TotalItem> _itemlist = new List<TotalItem>(); //課題
    HealItem _healcount;
    Vector3 _transform;
   public bool _setParent = true;
    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
        _vel = _rb.velocity;
        _position = transform.position;
        _healcount = GameObject.Find("HealItem").GetComponent<HealItem>();
        _transform = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Direction(x);
        _vel.x = x * _movepower;
        _rb.velocity = new Vector2(_vel.x, _rb.velocity.y);
        _shot2.text = "のこり" + _count;
        JumpPower();

        if (x == 0 && Input.GetButtonDown("Fire1")) //銃を撃つ処理
        {
                //アニメーションの切り替え
           _animator.SetTrigger("shot");
           Instantiate(_BulletPrehab, _shotPoint.position, transform.localRotation);
          
        }

        if (x != 0 && Input.GetButtonDown("Fire1"))
        {
            _animator.SetBool("Run Shot bool",true);
            _animator.SetBool("Run bool", false);
            Debug.Log("test");
            Instantiate(_BulletPrehab, _shotPoint.position, transform.localRotation);

        }
        else if(x !=0 && !Input.GetButtonDown("Fire1"))
        {
            _animator.SetBool("Run bool",true);
        }
        else
        {
            _animator.SetBool("Run bool", false);
            _animator.SetBool("Run Shot bool", false);
        }

        if (_count > 0)
        {

            if (x == 0 && Input.GetButtonDown("Fire2")) //銃を撃つ処理
            {
                //アニメーションの切り替え
                _animator.SetTrigger("shot");
                //Instantiate(_BulletPrehab2, _shotPoint.position, transform.localRotation);
                //_count -= 1;
                if (_setParent == true)
                {
                    Instantiate(_BulletPrehab2, _shotPoint.position, transform.localRotation);
                    _count -= 1;
                }
                else if(_isright == true)
                {
                    Instantiate(_BulletPrehab2, _shotPoint.position, Quaternion.Euler(0f, 0f, 180f));
                    _count -= 1;
                }
                else if(_isright == false)
                {
                    Instantiate(_BulletPrehab2, _shotPoint.position, Quaternion.Euler(0f, 0f, 360f));
                    _count -= 1;
                }

            }

            if (x !=0 && Input.GetButtonDown("Fire2"))
            {
                _animator.SetBool("Run Shot bool", true);
                _animator.SetBool("Run bool", false);
                Debug.Log("test");
                //Instantiate(_BulletPrehab2, _shotPoint.position, transform.localRotation);
                //_count -= 1;
                if (_setParent == true)
                {
                    Instantiate(_BulletPrehab2, _shotPoint.position, transform.localRotation);
                    _count -= 1;
                }
                else
                {
                    Instantiate(_BulletPrehab2, _shotPoint.position, Quaternion.Euler(0f, 0f, 180f));
                    _count -= 1;
                }
            }
            else if (x != 0 && !Input.GetButtonDown("Fire2"))
            {
                _animator.SetBool("Run bool", true);
                
            }
            else
            {
                _animator.SetBool("Run bool", false);
                _animator.SetBool("Run Shot bool", false);
            }

        }
        if(Input.GetKey(KeyCode.Z)) //課題
        {
            if(_itemlist.Count > 0)
            {
                TotalItem item = _itemlist[0];
                _itemlist.RemoveAt(0);
                item.Activate();
                _healcount._itemcount -= 1;
            }
        }
       
    }
    void Direction(float inputX) //キャラの向き
    {
        if(_isright == true && inputX > 0)
        {
            this.transform.Rotate(0f, 180f, 0f); //左
            _isright = false;
        }
        if(_isright == false && inputX < 0)
        {
            this.transform.Rotate(0f, 180f, 0f); //右
            _isright = true;
        }
     
    }
    public void JumpPower()
    {
        if(_canjump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.velocity = Vector2.up * _jumppower;
                _animator.SetTrigger("Jump");
                _animator.SetBool("Run bool", false);
                _animator.SetBool("Run Shot bool", false);
                _canjump = false;
                Debug.Log("falseです");
            }
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item")
        {
            _count += 100;
        }
       if(collision.gameObject.tag != "Boss1")
        {
            _canjump = true;
        }
    }
  
    public void TesetItem(TotalItem item) //課題
    {
        _itemlist.Add(item);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            SceneManager.LoadScene("BossStage");
            transform.position = new Vector3(-16.87f, -2.03f, 0);
        }
        else if(collision.gameObject.tag == "Second")
        {
            SceneManager.LoadScene("SecondStage");
            transform.position = new Vector3(-7.81f, -0.86f, 0);
        }
        else if(collision.gameObject.tag == "First")
        {
            SceneManager.LoadScene("Main");
            transform.position = _transform;
        }
        else if(collision.gameObject.tag == "sea")
        {
            transform.position = new Vector3(-7.81f, -0.86f, 0);
        }
        if (collision.gameObject.tag == "Ground")
        {
            _canjump = true;
            Debug.Log("trueです");
        }
        else if (collision.gameObject.tag != "Enemy" || collision.gameObject.tag != "Boss1" || collision.gameObject.tag != "Boss2")
        {
            _canjump = false;
            Debug.Log("falseです");
        }

    }
    private void OnLevelWasLoaded(int level)
    {
        //transform.position = _position;
    }
  
}
