using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TPSCharaterController : MonoBehaviour
{
    [SerializeField] private Transform characterBody;
    [SerializeField] private Transform cameraArm;

    private Animator animator;
    public float movespeed = 0f;
    void Start()
    {
        animator = characterBody.GetComponent<Animator>();
    }

    
    void Update()
    {
        LookAround();
        Move();
    }


    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        animator.SetFloat("speed", movespeed);
        if (isMove)
        {
            if (moveInput.x == 0 && Input.GetKey(KeyCode.LeftControl))
            {
                movespeed = 6;
            }
            else
            {
                movespeed = 3;
            }
            
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;
            
            characterBody.forward = moveDir;
            transform.position += moveDir * (Time.deltaTime * movespeed);
        }
        else movespeed = 0;

        // Debug.DrawRay(cameraArm.position, new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized , Color.red);
    }
    
    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) ;
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;
            
        if (x < 180)
        {
            x = Mathf.Clamp(x, -1f, 55f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }
        
        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }

    // private void jump()
    // {
    //     bool isJump = Input.GetKeyDown(KeyCode.Space);
    //     animator.SetBool("isJump", isJump);
    //
    //     if (isJump)
    //     {
    //         
    //     }
    // }
}
