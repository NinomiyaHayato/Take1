using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealItem : MonoBehaviour
{
    public int _itemcount;
    [SerializeField]Text _text;
    AudioSource _audio;
    [SerializeField] AudioClip _catchaudio;
    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _itemcount.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _itemcount += 1;
            _audio.PlayOneShot(_catchaudio);
        }
    }
}
