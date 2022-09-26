using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SwtchLight : MonoBehaviour
{
    [SerializeField] GameObject _game;
    [SerializeField] GameObject _game1;
    [SerializeField] Image _image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchLight()
    {
        if(_game && _game1)
        {
            _game.SetActive(false);
            _game1.SetActive(true);
        }
    }
   public  void SceneLord(string name)
    {
      this._image.DOFade(2f,2f).SetDelay(1.5f).OnComplete(()=> SceneManager.LoadScene(name));
    }
    public void SceneLord2(string name)
    {
        SceneManager.LoadScene(name);
        GameObject _main = GameObject.Find("Main");
        if(_main)
        {
            Destroy(_main);
        }
    }
}
