using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCreate : MonoBehaviour
{
    [SerializeField] GameObject _sword;
    BoxCollider2D _boxc;

    // Start is called before the first frame update
    void Start()
    {
        _boxc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float _X = Random.Range((-_boxc.size.x) / 2, (_boxc.size.x) / 2);
        float _y = Random.Range((-_boxc.size.y) / 2, (_boxc.size.y) / 2);

        GameObject _create = Instantiate(_sword);
        _create.transform.position = new Vector2(_X + transform.position.x, _y + transform.position.y);
    }
}
