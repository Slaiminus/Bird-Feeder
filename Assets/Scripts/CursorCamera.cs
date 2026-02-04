using UnityEngine;

public class CursorCamera : MonoBehaviour // Ётот скрипт дал мне ии гугл из поисковика, помен€л по своему но с нул€ бы такое не написал
{
    [SerializeField] private GameObject target;
    [SerializeField] private float distance;
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;
    [SerializeField] private float yMinLimit;
    [SerializeField] private float yMaxLimit;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float maxDistance;
    [SerializeField] private float minDistance;

    private float x = 0.0f;
    private float y = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void Update()
    {
        if (Input.GetMouseButton(1) || Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);

            distance += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * -1;
            distance = Mathf.Max(minDistance, distance);  //ќграничение зума
            distance = Mathf.Min(maxDistance, distance);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.transform.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
