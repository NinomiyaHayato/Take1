using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwtchLight : MonoBehaviour
{
    [SerializeField] GameObject _game;
    [SerializeField] GameObject _game1;
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
            _game.SetActive(true);
            _game1.SetActive(false);
        }
    }
   public  void SceneLord(string name)
    {
        SceneManager.LoadScene(name);
    }
}
