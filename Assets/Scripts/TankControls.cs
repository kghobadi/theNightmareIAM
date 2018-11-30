using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour {
    public float moveSpeedForward, moveSpeedBackward, rotationSpeed;
    CharacterController character;

	void Start () {
        character = GetComponent<CharacterController>();
	}
	
	void Update () {
        //forward
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 fwd = transform.forward * moveSpeedForward * Time.deltaTime;
            character.Move(fwd);
        }
        //backward
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 bkwd = transform.forward * moveSpeedBackward * Time.deltaTime;
            character.Move(bkwd);
        }

        //rotate left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, Time.deltaTime * -rotationSpeed, 0);
        }
        //rotate right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
        }
    }
}
