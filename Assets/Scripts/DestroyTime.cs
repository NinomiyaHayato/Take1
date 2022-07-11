using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour
{
    [SerializeField] float _lefttime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lefttime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
