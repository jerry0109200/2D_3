using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyMove_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rubyPosition = transform.position;
        rubyPosition.x = rubyPosition.x + 0.01f;
        transform.position = rubyPosition;
    }
}
