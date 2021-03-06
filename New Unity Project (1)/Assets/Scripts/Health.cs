using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject pickE;

    //【產生音效 1】
    public AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(pickE, gameObject.transform.position, Quaternion.identity);

        Ruby rubyGo = collision.GetComponent<Ruby>();

        print("碰到的東西是 :" + rubyGo);

        rubyGo.ChangeHealth(1);

        //【產生音效 2】
        rubyGo.PlaySound(audioClip);

        Destroy(gameObject);
    }
}
