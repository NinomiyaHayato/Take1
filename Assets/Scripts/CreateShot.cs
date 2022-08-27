using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShot : MonoBehaviour
{
    [SerializeField] GameObject _createshot;
    BoxCollider2D _boxc;
    [SerializeField] float _cooltime;
    float _time;
    // Start is called before the first frame update
    void Start()
    {
        _boxc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        float _x = Random.Range((-_boxc.size.x) / 2, (_boxc.size.x) / 2);
        float _y = Random.Range((-_boxc.size.y) / 2, (_boxc.size.y) / 2);
        if(_cooltime <= _time)
        {
            GameObject _createshots = Instantiate(_createshot);
            _createshots.transform.position = new Vector2(_x + transform.position.x, _y + transform.position.y);
            _time = 0;
        }
        
    }
}
