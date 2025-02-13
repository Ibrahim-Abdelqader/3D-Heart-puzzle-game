using UnityEngine;

public class RandomizeObjects : MonoBehaviour
{
    public GameObject[] objectsToRandomize; // Array of objects to be randomized
    public Vector3 positionRange = new Vector3(5f, 5f, 5f); // Position randomization range
    public Vector3 rotationRange = new Vector3(360f, 360f, 360f); // Rotation randomization range 

    void Start()
    {
        foreach (GameObject obj in objectsToRandomize)
        {
            // Randomize position
            Vector3 randomPosition = new Vector3(
                Random.Range(-positionRange.x, positionRange.x),
                Random.Range(-positionRange.y, positionRange.y),
                Random.Range(-positionRange.z, positionRange.z)
            );
            obj.transform.position += randomPosition;

            // Randomize rotation
            Vector3 randomRotation = new Vector3(
                Random.Range(0f, rotationRange.x),
                Random.Range(0f, rotationRange.y),
                Random.Range(0f, rotationRange.z)
            );
            obj.transform.eulerAngles = randomRotation;
        }
    }
}
