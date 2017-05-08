using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeFlyCamera : MonoBehaviour {

    public float speed,lookSpeed = 1;
    public KeyCode Forward = KeyCode.W,
        Backward = KeyCode.S,
        Up = KeyCode.Space,
        Down = KeyCode.LeftShift,
        Left = KeyCode.A,
        Right=KeyCode.D,
        RollLeft = KeyCode.Q,
        RollRight = KeyCode.E,
        TiltUp = KeyCode.R,
        TiltDown = KeyCode.F,
        EscapeCursor=KeyCode.Escape;

    private Vector3 lastMousePosition;

    void Start()
    {
        lastMousePosition = Input.mousePosition;
        Cursor.visible = false;
    }

	void Update () {
        if (Input.GetKey(Forward))
            transform.position = Vector3.MoveTowards(transform.position, 
                                                     transform.position + transform.forward,
                                                     Time.deltaTime * speed);
        if (Input.GetKey(Backward))
            transform.position = Vector3.MoveTowards(transform.position,
                                                     transform.position - transform.forward,
                                                     Time.deltaTime * speed);
        if (Input.GetKey(Right))
            transform.position = Vector3.MoveTowards(transform.position,
                                                     transform.position + transform.right,
                                                     Time.deltaTime * speed);
        if (Input.GetKey(Left))
            transform.position = Vector3.MoveTowards(transform.position,
                                                     transform.position - transform.right,
                                                     Time.deltaTime * speed);
        if (Input.GetKey(Up))
            transform.position = Vector3.MoveTowards(transform.position,
                                                     transform.position + transform.up,
                                                     Time.deltaTime * speed);
        if (Input.GetKey(Down))
            transform.position = Vector3.MoveTowards(transform.position,
                                                     transform.position - transform.up,
                                                     Time.deltaTime * speed);

        if (Input.GetKey(RollLeft))
            transform.Rotate(Vector3.forward, Time.deltaTime * speed * 0.5f, Space.Self);

        if (Input.GetKey(RollRight))
            transform.Rotate(Vector3.forward, Time.deltaTime * speed * -0.5f, Space.Self);

        if (Input.GetKey(TiltUp))
            transform.Rotate(Vector3.right, Time.deltaTime * speed * 0.5f, Space.Self);

        if (Input.GetKey(TiltDown))
            transform.Rotate(Vector3.right, Time.deltaTime * speed * -0.5f, Space.Self);

        if (Input.GetKeyDown(EscapeCursor))
        {
            Cursor.visible = !Cursor.visible;
            lastMousePosition = Input.mousePosition;
        }

        if (!Cursor.visible)
        {
            Vector3 deltaMousePosition = lastMousePosition - Input.mousePosition;
            if (deltaMousePosition.magnitude > 0)
                transform.Rotate(deltaMousePosition.y * lookSpeed, deltaMousePosition.x * lookSpeed * -1, 0);
            lastMousePosition = Input.mousePosition;
        }
	}
}
