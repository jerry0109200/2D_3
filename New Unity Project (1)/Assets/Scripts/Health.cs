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

        print("碰到的東西是 :" + rubyGo);

        rubyGo.ChangeHealth(1);
        Destroy(gameObject);
    }
}
