 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLook : MonoBehaviour
{
    public Joystick joystick;
    public float sensitivity = 100f;
    public Transform playerBody;
    public GameObject grenade;
    public Button btn;

    public Camera cam;
    public float throwForce = 20;

    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = joystick.Horizontal * sensitivity * Time.deltaTime;
        float y = joystick.Vertical * sensitivity * Time.deltaTime;

        //Debug.Log("joystick.Horizontal: " + joystick.Horizontal);
        //Debug.Log("joystick.Vertical: " + joystick.Vertical);
        //Debug.Log("x: "+x);
        //Debug.Log("y: " + y);

        xRotation -= y;
        yRotation += x;
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        //playerBody.Rotate(Vector3.up * x);
    }
    //public void fire()
    //{
    //    Debug.Log("Fire");

    //    Vector3 start = new Vector3(playerBody.transform.position.x, playerBody.transform.position.y, playerBody.transform.position.z);

    //    Quaternion r = new Quaternion(playerBody.transform.rotation.x, playerBody.transform.rotation.y, playerBody.transform.rotation.z, playerBody.transform.rotation.w);
    //    GameObject grenadeThing = Instantiate(grenade, start, r);
    //}

    public void fire()
    {
        Vector3 p = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
        GameObject grenadeThing = Instantiate(grenade, p, transform.rotation);
        Rigidbody rb = grenadeThing.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);

    }
}
