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

    //�i��q���� 1/4�j
    [Header("�̰���q")]
    public int maxHealth = 5;

    [Header("��e��q"), Range(0, 5)]
    public int currentHealth;

    //�i�o�g�l�u 1�j
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        rubyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //�i��q���� 2/4�j
        currentHealth = maxHealth;
        print("Ruby��e��q��:" + currentHealth);
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


        //�i��q���� 4/4�j���q��0�ɡA���s�C�����d (Ū�����d)
        if (currentHealth == 0)
        {
            Application.LoadLevel("Week12_Health-2_damage");
        }

        //�i�o�g�l�u 3/3�j�]�w�o�g�欰������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
    }

    //�i��q���� 3/4�j
    public void ChangeHealth(int amout)
    {
        currentHealth = currentHealth + amout;
        print("Ruby ��e��q��:" + currentHealth);
    }

    //�i�o�g�l�u 2/3�j
    public void Launch()
    {
        GameObject projectileOnject = Instantiate(projectilePrefab,
            rb.position, Quaternion.identity);

        Bullet bullet = projectileOnject.GetComponent<Bullet>();

        bullet.Launch(lookDirection, 300);


        rubyAnimator.SetTrigger("Launch");

    }
}
