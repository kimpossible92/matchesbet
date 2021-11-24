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
        var isGround = Physics.Raycast(transform.position, Vector3.down, 1 * 0.6f, mask);

        Debug.DrawRay(transform.position, Vector3.down, Color.red,1*0.6f);
        if (isGround && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            MaxJumpTime = _StoreMaxTime;
            transform.Translate(new Vector3(0,1,0.72f) * 2.6f);
        }
        if (transform.position.y >= 1.8f) { MaxJumpTime = -1f; }
        else if ((Input.GetKey(KeyCode.Space)||Input.GetMouseButton(0)) && MaxJumpTime > 0 && transform.position.y<=2f)
        {
            //MaxJumpTime -= Time.deltaTime;
            //transform.position += new Vector3(0, JumpPower, 0.1f);
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
