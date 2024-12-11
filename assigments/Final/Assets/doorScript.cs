using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private float openAngle = 90f;
    private float closeAngle = 0f; // Angle to close the door
    private float openSpeed = 2f; // Speed at which the door opens/closes
    private bool isLocked = true; // Is the door locked initially?

    private bool isOpen = false; // Is the door currently open?
    private Quaternion openRotation; // Target rotation for opening
    private Quaternion closeRotation; // Target rotation for closing

    private void Start()
    {
        // Set initial door rotations based on the pivot point
        closeRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + openAngle, transform.eulerAngles.z);
    }

    private void Update()
    {
        // Smoothly rotate the door towards its target rotation
        if (isOpen)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, closeRotation, Time.deltaTime * openSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isLocked)
            {
                Debug.Log("The door is locked. Find the key!");
            }
            else
            {
                isOpen = !isOpen; // Toggle door state
            }
        }
    }

    public void UnlockDoor()
    {
        isLocked = false; // Unlock the door
        Debug.Log("The door is now unlocked!");
    }
}

