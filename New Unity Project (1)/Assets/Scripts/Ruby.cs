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
    public int currentHealth;

    //【新增音效 1】
    private AudioSource audioSource;

    //【受傷音效 1】
    public AudioClip playerHit;

    //【發射音效 2】
    public AudioClip playershot;

    //【發射子彈 1】
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        rubyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //【血量控制 2/4】
        currentHealth = maxHealth;
        print("Ruby當前血量為:" + currentHealth);

        //【新增音效 2】
        audioSource = GetComponent<AudioSource>();

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
        if (currentHealth == 0)
        {
            Application.LoadLevel("Week12_Health-2_damage");
        }

        //【發射子彈 3/3】設定發射行為的按鍵
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();

            PlaySound(playershot);
        }
    }

    //【血量控制 3/4】
    public void ChangeHealth(int amout)
    {
        currentHealth = currentHealth + amout;
        print("Ruby 當前血量為:" + currentHealth);

        //【判斷是否受傷】
        if (amout < 0)
        {
            //【受傷音效 2】
            PlaySound(playerHit);
        }
    }

    //【發射子彈 2/3】
    public void Launch()
    {
        GameObject projectileOnject = Instantiate(projectilePrefab,
            rb.position, Quaternion.identity);

        Bullet bullet = projectileOnject.GetComponent<Bullet>();

        bullet.Launch(lookDirection, 300);

        rubyAnimator.SetTrigger("Launch");
    }
    //【新增音效 3】
    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
