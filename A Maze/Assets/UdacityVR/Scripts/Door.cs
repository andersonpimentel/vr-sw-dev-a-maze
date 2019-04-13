﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    // TODO: Create variables to reference the game objects we need access to
    // Declare a GameObject named 'leftDoor' and assign the 'Left_Door' game object to the field in Unity
    public GameObject leftDoor;
    // Declare a GameObject named 'rightDoor' and assign the 'Right_Door' game object to the field in Unity
    public GameObject rightDoor;

    // TODO: Create variables to reference the components we need access to
    // Declare an AudioSource named 'audioSource' and get a reference to the audio source in Start()
    private AudioSource audioSource;

	// TODO: Create variables to track the gameplay states
	// Declare a boolean named 'locked' to track if the door has been unlocked and initialize it to 'true'
    private bool locked = true;
    // Declare a boolean named 'opening' to track if the door is opening and initialize it to 'false'
    private bool opening = false;

    // TODO: Create variables to hold rotations used when animating the door opening
    // Declare a Quaternion named 'leftDoorStartRotation' to hold the start rotation of the 'Left_Door' game object
    Quaternion leftDoorStartRotation;
    // Declare a Quaternion named "leftDoorEndRotation" to hold the end rotation of the 'Left_Door' game object
    Quaternion leftDoorEndRotation;
    // Declare a Quaternion named 'rightDoorStartRotation' to hold the start rotation of the 'Right_Door' game object
    Quaternion rightDoorStartRotation;
    // Declare a Quaternion named 'rightDoorEndRotation' to hold the end rotation of the 'Right_Door' game object
    Quaternion rightDoorEndRotation;

    // TODO: Create variables to control the speed of the interpolation when animating the door opening
    // Declare a float named 'timer' to track the Quaternion.Slerp() interpolation and initialize it to for example '0f'
    private float timer = 0.0f;
    // Declare a float named 'rotationTime' to set the Quaternion.Slerp() interpolation speed and initialize it to for example '10f'
    private float rotationTime = 10.0f;


	void Start () {
        // TODO: Get a reference to the audio source
        // Use GetComponent<>() to get a reference to the AudioSource component and assign it to the 'audioSource'
        audioSource = gameObject.GetComponent<AudioSource>();

        // TODO: Set start and end rotation values used when animating the door opening
        // Use 'leftDoor' to get the start rotation of the 'Left_Door' game object and assign it to 'leftDoorStartRotation'
        leftDoorStartRotation = leftDoor.transform.rotation;
        // Use 'leftDoorStartRotation' and Quaternion.Euler() to set the end rotation of the 'Left_Door' game object and assign it to 'leftDoorEndRotation'
        leftDoorEndRotation = leftDoorStartRotation * Quaternion.Euler(0.0f, 0.0f, 90.0f);
        // Use 'rightDoor' to get the start rotation of the 'Right_Door' game object and assign it to 'rightDoorStartRotation'
        rightDoorStartRotation = rightDoor.transform.rotation;
        // Use 'rightDoorStartRotation' and Quaternion.Euler() to set the end rotation of the 'Right_Door' game object and assign it to 'rightDoorEndRotation'
        rightDoorEndRotation = rightDoorStartRotation * Quaternion.Euler(0.0f, 0.0f, -90.0f);
	}


	void Update () {
        // TODO: If the door is opening, animate the 'Left_Door' and 'Right_Door' game objects rotating open
        // Use 'opening' to check if the door is opening...
        if (opening)
        {
            // ... use Quaternion.Slerp() to interpolate from 'leftDoorStartRotation' to 'leftDoorEndRotation' by the interpolation time 'timer / rotationTime' and assign it to the 'leftDoor' rotation
            leftDoor.transform.rotation = Quaternion.Slerp(leftDoorStartRotation, leftDoorEndRotation, timer / rotationTime);
            // ... use Quaternion.Slerp() to interpolate from 'rightDoorStartRotation' to 'rightDoorEndRotation' by the interpolation time 'timer / rotationTime' and assign it to the 'leftDoor' rotation
            rightDoor.transform.rotation = Quaternion.Slerp(rightDoorStartRotation, rightDoorEndRotation, timer / rotationTime);
            // ... use Time.deltaTime to increment 'timer'
            timer += Time.deltaTime;
        }
	}


	public void OnDoorClicked () {
		/// Called when the 'Left_Door' or 'Right_Door' game object is clicked
		/// - Starts opening the door if it has been unlocked
		/// - Plays an audio clip when the door starts opening

		// Prints to the console when the method is called
		Debug.Log ("'Door.OnDoorClicked()' was called");

		// TODO: If the door is unlocked, start animating the door rotating open and play a sound to indicate the door is opening
		// Use 'locked' to check if the door is locked and ...
        if (!locked) {
            // ... start the animation defined in Update() by changing the value of 'opening'
            opening = true;
            // ... use 'audioSource' to play the AudioClip assigned to the AudioSource component
            audioSource.Play();
        }

		// OPTIONAL-CHALLENGE: Prevent the door from being interacted with after it has started opening
		// TIP: You could disable the Event Trigger component, or for an extra challenge, try disabling all the Collider components on all children

		// OPTIONAL-CHALLENGE: Play a different sound if the door is locked
		// TIP: You could get a reference to the 'Door_Locked' audio and play it without assigning it to the AudioSource component
	}


	public void Unlock () {
		/// Called from Key.OnKeyClicked(), i.e. the Key.cs script, when the 'Key' game object is clicked
		/// - Unlocks the door

		// Prints to the console when the method is called
		Debug.Log ("'Door.Unlock()' was called");

        // TODO: Unlock the door 
        // Unlock the door by changing the value of 'locked'
        locked = false;
	}
}
