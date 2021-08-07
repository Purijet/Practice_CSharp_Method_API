using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour
{
    [Header("移動速度"), Range(0, 50)]
    public float Speed = 20.0f;

    public Rigidbody2D Rig;
    //private Sprite mySprite;
    public SpriteRenderer Sr;
    private float gravity = 1;
    private float hValue;

    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetPlayerInputHorizontal();
        TurnDirection();
    }

    private void FixedUpdate()
    {
        Move(hValue);
    }

    private void GetPlayerInputHorizontal()
    {
        hValue = Input.GetAxis("Horizontal");
    }
    private void Move(float horizontal)
    {
        Vector2 posMove = transform.position + new Vector3(horizontal, -gravity, 0) * Speed * Time.fixedDeltaTime;
        Rig.MovePosition(posMove);
    }

    private void TurnDirection()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
