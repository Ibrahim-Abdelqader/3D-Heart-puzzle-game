using UnityEngine;

public class SnapScript : MonoBehaviour
{
    public Transform snapPoint;         // The snap point of this part 
    public Transform targetSnapPoint;   // The target snap point to align with (e.g., snapPoint5_1 on part5)
    public float snapRange = 2f;      // Distance within which the snap will occur



   void Update()
{
    float distance = Vector3.Distance(snapPoint.position, targetSnapPoint.position);
    Debug.Log("Distance between points: " + distance);

    if (distance <= snapRange)
    {
        Debug.Log("Snapping");
        Vector3 offset = targetSnapPoint.position - snapPoint.position;
        transform.position += offset;
        transform.rotation = targetSnapPoint.rotation;
    }   
}

    void SnapParts()
    {
        // Calculate offset between the two snap points
        Vector3 offset = targetSnapPoint.position - snapPoint.position;

        // Move the current part to align snap points
        transform.position += offset;

        // Optionally, align rotation if needed
        transform.rotation = targetSnapPoint.rotation;

        // Disable script to prevent re-snapping
        enabled = false;
    }
}
