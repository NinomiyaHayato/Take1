using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEfectStop : MonoBehaviour
{
    int _areacount;
    [SerializeField] GameObject _area;
    [SerializeField] GameObject _area1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ITween._gatecount >=1)
        {
            _area.SetActive(false);
            _area1.SetActive(false);
        }
    }
}
