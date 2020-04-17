using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject explosionPrefab;

    public float radius = 10f;
    public float delay = 3f;
    public float explosionForce = 500f;

    float countDown;
    bool hasExploded = false;

    private void Start()
    {
        //Invoke("Explode", 3f);
        countDown = delay;
    }
    private void Update()
    {
        countDown -= Time.deltaTime;
        if(countDown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    public void Explode()
    {
        Transform t = gameObject.transform;
        Vector3 pos = new Vector3(t.position.x, t.position.y, t.position.z);
        Quaternion r = new Quaternion(t.rotation.x, t.rotation.y, t.rotation.z, t.rotation.w);
        GameObject explosionTemp = Instantiate(explosionPrefab, pos, r);

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in collidersToDestroy)
        {
            Destructible dest = nearbyObject.GetComponent<Destructible>();
            if(dest != null) //check it has that script, so it is def destructible!
            {
                dest.destroyObject(); //this destroys them repalces with exploded object
            }
        }
        Collider[] collidersToApplyForce = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider force in collidersToApplyForce)
        {
            Rigidbody rb = force.GetComponent<Rigidbody>();
            if(rb != null) //not all objecst in our sphere will have rigidbody
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius);
            }
        }
            //gameObject.SetActive(false);
        Destroy(gameObject);
        Destroy(explosionTemp, 2f);
    }
}
