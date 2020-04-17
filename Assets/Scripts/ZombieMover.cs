using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMover : MonoBehaviour
{
    public CharacterController charController;
    public Animator animator;

    [SerializeField]
    public float walkSpeed = 125f;
    public float runSpeed = 400;

    [SerializeField]
    public float turnSpeed = 5;
    // Start is called before the first frame update
    private void awake()
    {
        //charController = GetComponent<CharacterController>();
        //animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        var horiz = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");
        //Debug.Log("horiz  "+ horiz);

        var movement = new Vector3(horiz, 0f, vert);
        Debug.Log("movement.magnitude  " + movement.magnitude);

        charController.SimpleMove(movement * Time.deltaTime  * runSpeed);
        animator.SetFloat("Speed", movement.magnitude);

        if (movement.magnitude > 0)
        {
            Quaternion newDir = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation , newDir, Time.deltaTime * turnSpeed);
        }
        
    }
}
