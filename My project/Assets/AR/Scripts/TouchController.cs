using UnityEngine;

public class TouchController : MonoBehaviour
{

    [SerializeField] float _rotationSpeed = 100;
    [SerializeField] bool _isRotating;
    [SerializeField] bool mouse;

    Vector3 position;
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        position = transform.position;

    }
    private void Update()
    {
        Touch();
        if(mouse) Mouse();

        transform.position = position;
    }

    private void Touch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
                {
                    _isRotating = true;
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                _isRotating = false;
            }
        }

        if (_isRotating)
        {
            float x = Input.GetTouch(0).deltaPosition.x * Mathf.Deg2Rad * _rotationSpeed * Time.deltaTime;
            float y = Input.GetTouch(0).deltaPosition.y * Mathf.Deg2Rad * _rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.forward, -x, Space.Self);
            transform.Rotate(Vector3.right, y, Space.Self);
        }
    }
    private void Mouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                _isRotating = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isRotating = false;
        }

        if (_isRotating)
        {
            float x = Input.GetAxis("Mouse X") * Mathf.Deg2Rad * _rotationSpeed;
            float y = Input.GetAxis("Mouse Y") * Mathf.Deg2Rad * _rotationSpeed;

            transform.Rotate(Vector3.forward, -x, Space.Self);
            transform.Rotate(Vector3.right, y, Space.Self);
        }
    }
}
