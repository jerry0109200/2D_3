using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyMove : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rubPosition = transform.position;
        rubPosition.x = rubPosition.x + moveSpeed * Input.GetAxis("Horizontal");
        rubPosition.y = rubPosition.y + moveSpeed * Input.GetAxis("Vertical");
        rb.MovePosition(rubPosition);
    }
}
