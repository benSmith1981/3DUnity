using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject cube;
    public GameObject grenade;
    public Camera cam;
    public float throwForce=20;
    List<GameObject> cubes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            throwGrenade();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 start = new Vector3(cube.transform.position.x, cube.transform.position.y, cube.transform.position.z);

            Quaternion r = new Quaternion(cube.transform.rotation.x, cube.transform.rotation.y, cube.transform.rotation.z, cube.transform.rotation.w);
            Instantiate(cube,start, r);
            GameObject grenadeThing = Instantiate(grenade, start, r);


        }
    }

    void throwGrenade()
    {
        GameObject grenadeThing = Instantiate(grenade, cam.transform.position, cam.transform.rotation);
        Rigidbody rb = grenadeThing.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);

    }
}
