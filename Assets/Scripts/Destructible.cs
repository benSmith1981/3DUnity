using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedBox;

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("OnCollisionEnter"+ collision.relativeVelocity);
        if (collision.relativeVelocity.y  > 15) {
            destroyObject();
        }
    }
     
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");

        //destroyObject();

    }

    public void destroyObject()
    {
        Destroy(gameObject);

        Transform t = gameObject.transform;
        Vector3 pos = new Vector3(t.position.x, t.position.y, t.position.z);
        Quaternion r = new Quaternion(t.rotation.x-90, t.rotation.y, t.rotation.z, t.rotation.w);
        Instantiate(destroyedBox, pos, r);

    }


}
