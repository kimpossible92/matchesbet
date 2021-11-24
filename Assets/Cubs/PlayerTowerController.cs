using Gameplay.ShipSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTowerController : Cubs
{
    private bool jumping = false;
    private Rigidbody rb;


    public LayerMask mask;

    private float CheckExstends=2f;
    public bool spaceNot = false;
    protected override void ProcessHandling(MovementSystem movementSystem)
    {
        float _StoreMaxTime = 0.45f;
        float JumpPower = 0.35f;
       
        float MaxJumpTime = 0.45f;
        var isGround = Physics.Raycast(transform.position, Vector3.down, 1 * 3f, mask);

        
        if (isGround && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            MaxJumpTime = _StoreMaxTime;
        }

        if ((Input.GetKey(KeyCode.Space)||Input.GetMouseButton(0)) && MaxJumpTime > 0&& transform.position.y<=2f)
        {
            MaxJumpTime -= Time.deltaTime;
            transform.position += new Vector3(0, JumpPower, 0.1f);
            //rb.AddForce(new Vector2(0, JumpPower), ForceMode.Impulse);
        }

        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) && !isGround)
        {
            MaxJumpTime = -1f;
        }
    }
    private void jumpdelay()
    {
        spaceNot = true;
    }
    private void jumpdelay2()
    {
        spaceNot = false;
    }
    protected override void ProcessJump(MovementSystem jumpSystem)
    {
       
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //JumpPower = 2.0f;
        //MaxJumpTime = 0.45f;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //JumpPower = 2.0f;
        //MaxJumpTime = 0.45f;
        //_StoreMaxTime = MaxJumpTime;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
