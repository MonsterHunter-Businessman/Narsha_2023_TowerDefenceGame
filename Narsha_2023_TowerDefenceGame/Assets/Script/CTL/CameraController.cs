using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float CameraMoveSpeedM = 0.5F;
    [SerializeField]
    private float CameraMoveSpeedKB = 0.02F;


    [SerializeField]
    private float CameraZoomRatio = 0.5F;
    private float mMinOrthographicSize = 2.0F;
    private float mMaxOrthographicSize = 10.0F;


    [SerializeField]
    private Tilemap Map;
    private float mMinLimitX = 0.0F;
    private float mMaxLimitX = 0.0F;
    private float mMinLimitY = 0.0F;
    private float mMaxLimitY = 0.0F;


    public void Start()
    {
        if (Map != null)
        {
            Map.CompressBounds();
            setCameraLimit();
        }
    }

    public void LateUpdate()
    {
        // Mouse
        if (Input.GetMouseButton(1))
        {
            Vector3 newPosition = new Vector3(transform.position.x + (-Input.GetAxis("Mouse X") * CameraMoveSpeedM),
                                              transform.position.y + (-Input.GetAxis("Mouse Y") * CameraMoveSpeedM),
                                              transform.position.z);

            newPosition.x = Mathf.Clamp(newPosition.x, mMinLimitX, mMaxLimitX);
            newPosition.y = Mathf.Clamp(newPosition.y, mMinLimitY, mMaxLimitY);

            transform.position = newPosition;
        }


        // Mouse Wheel
        if (Input.GetKey(KeyCode.LeftControl))
        {
            zoomInOut(Input.GetAxis("Mouse ScrollWheel"));
        }


        // Keyboard
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + CameraMoveSpeedKB, transform.position.z);
            newPosition.y = Mathf.Clamp(newPosition.y, mMinLimitY, mMaxLimitY);

            transform.position = newPosition;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y - CameraMoveSpeedKB, transform.position.z);
            newPosition.y = Mathf.Clamp(newPosition.y, mMinLimitY, mMaxLimitY);

            transform.position = newPosition;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 newPosition = new Vector3(transform.position.x - CameraMoveSpeedKB, transform.position.y, transform.position.z);
            newPosition.x = Mathf.Clamp(newPosition.x, mMinLimitX, mMaxLimitX);

            transform.position = newPosition;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 newPosition = new Vector3(transform.position.x + CameraMoveSpeedKB, transform.position.y, transform.position.z);
            newPosition.x = Mathf.Clamp(newPosition.x, mMinLimitX, mMaxLimitX);

            transform.position = newPosition;
        }
    }

    private void zoomInOut(float inputWheel)
    {
        if (inputWheel == 0)
        {
            return;
        }

        // Wheel Up
        if (inputWheel > 0)
        {
            if (mMinOrthographicSize < Camera.main.orthographicSize)
            {
                Camera.main.orthographicSize += -CameraZoomRatio;
            }
        }
        // Wheel Down
        else
        {
            if (mMaxOrthographicSize > Camera.main.orthographicSize)
            {
                Camera.main.orthographicSize += CameraZoomRatio;
            }
        }
    }

    private void setCameraLimit()
    {
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = ((Camera.main.orthographicSize * 2) * Camera.main.aspect) / 2;

        float mapHeight = Map.localBounds.size.y / 2;
        float mapWidht = Map.localBounds.size.x / 2;

        mMinLimitX = (Map.cellBounds.center.x - mapWidht) + cameraWidth;
        mMaxLimitX = (Map.cellBounds.center.x + mapWidht) - cameraWidth;

        mMinLimitY = (Map.cellBounds.center.y - mapHeight) + cameraHeight;
        mMaxLimitY = (Map.cellBounds.center.y + mapHeight) - cameraHeight;
    }
}

