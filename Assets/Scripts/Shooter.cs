using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject _autoshot;
    [SerializeField] float _cooltime;
    float _cooltimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _cooltimer += Time.deltaTime;
        if(_cooltime < _cooltimer)
        {
            Instantiate(_autoshot, transform.position, transform.rotation);
            _cooltimer = 0;
        }
    }
}
