using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninjaController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private Animator _animator;
    private static readonly string ANIMATOR_STATE = "Estado";
    public static readonly int ANIMATION_SALTAR = 1;
    private static readonly int ANIMATION_RUN = 2;
    private static readonly int ANIMATION_MUERTE = 3;
    //private static readonly int ANIMATION_IDLE = 0;
    public float Velocidad = 10;
    public float JumpForce = 10;
    private static readonly int RIGHT = 1;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Desplazarse(RIGHT);

        if(Input.GetKeyUp(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            ChangeAnimation(ANIMATION_SALTAR);
        }

    }

    private void ChangeAnimation(int animation)
    {
        _animator.SetInteger(ANIMATOR_STATE, animation);
    }
    private void Desplazarse(int position)
    {
        _rb.velocity = new Vector2(Velocidad * position, _rb.velocity.y);
        ChangeAnimation(ANIMATION_RUN);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        var tag = other.gameObject.tag;
        if(tag == "Zombie")
        {
           ChangeAnimation(ANIMATION_MUERTE);
        }    
    }

}
