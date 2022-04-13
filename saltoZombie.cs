using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saltoZombie : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float JumpForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }

     private void OnCollisionEnter2D(Collision2D other)
    {
        var tag = other.gameObject.name;
        if (tag == "piso")
        {
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }
}
