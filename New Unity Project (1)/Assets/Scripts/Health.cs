using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject pickE;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(pickE, gameObject.transform.position, Quaternion.identity);

        Ruby rubyGo = collision.GetComponent<Ruby>();

        print("�I�쪺�F��O :" + rubyGo);

        rubyGo.ChangeHealth(1);
        Destroy(gameObject);
    }
}
