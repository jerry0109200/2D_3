using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ruby rubyGo = collision.GetComponent<Ruby>();
        print("�I�쪺�F��O :" + rubyGo);
        rubyGo.ChangeHealth(-1);
    }
}
