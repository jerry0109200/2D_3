using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    private Vector2 lookDirection;
    private Vector2 rubyPosition;
    private Vector2 rubyMove;

    public Animator rubyAnimator;
    public Rigidbody2D rb;

    public float speed = 3;

    //【血量控制 1/4】
    [Header("最高血量")]
    public int maxHealth = 5;

    [Header("當前血量"), Range(0, 5)]
    public int currentHelath;

    // Start is called before the first frame update
    void Start()
    {
        rubyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //【血量控制 2/4】
        currentHelath = maxHealth;
        print("Ruby當前血量為:" + currentHelath);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rubyPosition = transform.position;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        print("Horizontal is:" + horizontal);
        print("Vertical is:" + vertical);

        rubyMove = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(rubyMove.x, 0) || !Mathf.Approximately(rubyMove.y, 0))
        {
            lookDirection = rubyMove;
            lookDirection.Normalize();
        }


        rubyAnimator.SetFloat("LookX", lookDirection.x);
        rubyAnimator.SetFloat("LookY", lookDirection.y);
        rubyAnimator.SetFloat("Speed", rubyMove.magnitude);


        rubyPosition = rubyPosition + speed * rubyMove * Time.deltaTime;
        rb.MovePosition(rubyPosition);


        //【血量控制 4/4】當血量為0時，重新遊戲關卡 (讀取關卡)
        if (currentHelath == 0)
        {
            Application.LoadLevel("Week12_Health-2_damage");
        }
    }

    //【血量控制 3/4】
    public void ChangeHealth(int amout)
    {
        currentHelath = currentHelath + amout;
        print("Ruby 當前血量為:" + currentHelath);
    }
}
