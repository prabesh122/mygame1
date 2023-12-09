using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam; // Make the cam variable public

    private void LateUpdate()
    {
        // Check if the cam variable has been assigned
        if (cam != null)
        {
            transform.LookAt(transform.position + cam.forward);
        }
        else
        {
            Debug.LogError("The cam variable has not been assigned.");
        }
    }
}
