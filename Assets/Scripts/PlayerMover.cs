using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
	public CharacterController controller;
	public float runSpeed = 25f;
    public Joystick joystick;

    Vector3 touchStart;
    Vector3 touchEnd;
    float touchDistance = 0.1f;

    private void Update()
    {
        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;

        //multiply by fixedDeltaTime = amoutn of time elapsed since last time function was called
        //ENsures we move same amount each time this funcitons is called no matter how many times it is called.
        controller.Move(move * runSpeed * Time.deltaTime);

        //toucher();
    }

    void toucher()
    {
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];

            //Check if the phase of that touch equals Began
            if (myTouch.phase == TouchPhase.Began)
            {
                touchStart = myTouch.position;
                touchEnd = myTouch.position;
            }
            if (myTouch.phase == TouchPhase.Moved)
            {
                touchEnd = myTouch.position;


            }
            if (myTouch.phase == TouchPhase.Ended || Mathf.Abs(Vector3.Distance(touchEnd, touchEnd)) > touchDistance)
            {
                touchEnd = myTouch.position;
                float x = touchEnd.x - touchStart.x;
                float y = touchEnd.y - touchStart.y;

                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    if (x > 0)
                        Debug.Log("Move Right");
                    else
                        Debug.Log("Move Left");
                }
                else
                {
                    if (y > 0)
                        Debug.Log("Move Up");
                    else
                        Debug.Log("Move Down");
                }
            }
        }
    }
}
