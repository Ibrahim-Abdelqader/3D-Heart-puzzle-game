using UnityEngine;

public class DraggablePiece : MonoBehaviour
{
    public delegate void DragEndedDelegate(Transform transform);
    public DragEndedDelegate dragEndedDelegate;
    
    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 offset;
    
    // Adjustable speeds for dragging, rotation, and Z-axis movement
    private float dragSpeed = 10f;
    private float rotationSpeed = 100f;
    private float zMoveSpeed = 7f; // Speed for Z-axis movement

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        // Calculate offset between object and mouse position
        Vector3 screenPoint = mainCamera.WorldToScreenPoint(transform.position);
        Vector3 mousePoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        offset = transform.position - mainCamera.ScreenToWorldPoint(mousePoint);

        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Dragging the object with the mouse in X and Y
            Vector3 screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.WorldToScreenPoint(transform.position).z);
            Vector3 newWorldPosition = mainCamera.ScreenToWorldPoint(screenPoint) + offset;
            transform.position = newWorldPosition;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        dragEndedDelegate(this.transform);
    }

    void Update()
    {
        if (isDragging)
        {
            // Rotate with W, S, A, D keys when the object is selected
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime, Space.World); // Rotate around X-axis
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(Vector3.right, -rotationSpeed * Time.deltaTime, Space.World); // Rotate around X-axis (opposite)
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World); // Rotate around Y-axis
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime, Space.World); // Rotate around Y-axis (opposite)
            }

            // Move in Z-axis with Q and E keys
            if (Input.GetKey(KeyCode.Q))
            {
                transform.position += Vector3.forward * zMoveSpeed * Time.deltaTime; // Move closer in Z-axis
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.position += Vector3.back * zMoveSpeed * Time.deltaTime; // Move away in Z-axis
            }
        }
    }
}
