using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEfectStop : MonoBehaviour
{
    [SerializeField] GameObject _area;
    [SerializeField] GameObject _area1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(GateCount._gatecount > 0)
        {
            _area.SetActive(false);
            _area1.SetActive(false);
        }
    }
}
