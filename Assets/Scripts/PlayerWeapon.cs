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
    bool _isright = true;

    [SerializeField]public float _movepower;
    Rigidbody2D _rb;
    [SerializeField]public float _jumppower;
    int _count;
    [SerializeField] Text _shot2;
    Vector3 _position;
    List<TotalItem> _itemlist = new List<TotalItem>(); //�ۑ�

    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
        _position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Direction(x);
        _rb.velocity = new Vector2(x, 0) * _movepower;
        JumpPower();
        _shot2.text = "�̂���" + _count;


       if (x == 0 && Input.GetButtonDown("Fire1")) //�e��������
        {
                //�A�j���[�V�����̐؂�ւ�
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

            if (x == 0 && Input.GetButtonDown("Fire2")) //�e��������
            {
                //�A�j���[�V�����̐؂�ւ�
                _animator.SetTrigger("shot");
                Instantiate(_BulletPrehab2, _shotPoint.position, transform.localRotation);
                _count -= 1;
            }

            if (x != 0 && Input.GetButtonDown("Fire2"))
            {
                _animator.SetBool("Run Shot bool", true);
                _animator.SetBool("Run bool", false);
                Debug.Log("test");
                Instantiate(_BulletPrehab2, _shotPoint.position, transform.localRotation);
                _count -= 1;
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
        if(Input.GetKey(KeyCode.Z)) //�ۑ�
        {
            if(_itemlist.Count > 0)
            {
                TotalItem item = _itemlist[0];
                _itemlist.RemoveAt(0);
                item.Activate();
            }
        }
    }
    void Direction(float inputX) //�L�����̌���
    {
        if(_isright == true && inputX < 0)
        {
            this.transform.Rotate(0f, 180f, 0f); //��
            _isright = false;
        }
        if(_isright == false && inputX > 0)
        {
            this.transform.Rotate(0f, 180f, 0f); //�E
            _isright = true;
        }
     
    }
    public void JumpPower()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector2(0,2)*_jumppower;
            _animator.SetBool("Jump bool", true);
            _animator.SetBool("Run bool", false);
            _animator.SetBool("Run Shot bool", false);
        }
        else
        {
            _animator.SetBool("Jump bool", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item")
        {
            _count += 1;
        }
    }
    public void TesetItem(TotalItem item) //�ۑ�
    {
        _itemlist.Add(item);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            SceneManager.LoadScene("BossStage");
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        transform.position = _position;
    }
}
