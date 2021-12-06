using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ruby rubyGo = collision.GetComponent<Ruby>();
        print("碰到的東西是 :" + rubyGo);
        rubyGo.ChangeHealth(-1);
    }
}
