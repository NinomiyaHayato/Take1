using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TotalItem : MonoBehaviour
{
    [SerializeField] Timing _timing = Timing.Use;
    public abstract void Activate();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(_timing == Timing.Use)
            {
                Activate();
                Destroy(this.gameObject, 0.1f);
            }
            else if(_timing == Timing.NotUse)Å@//â€ëË
            {
                collision.gameObject.GetComponent<PlayerWeapon>().TesetItem(this);
                this.transform.position = Camera.main.transform.position;
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }
    // Start is called before the first frame update

    enum Timing //â€ëË
    {
        Use,

        NotUse,
    }
}
