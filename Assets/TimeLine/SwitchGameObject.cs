using UnityEngine;

public class SwitchLevel : MonoBehaviour
{
    public GameObject CameraMain; // Kéo và thả Player chính vào đây trong Inspector.


    // Được gọi khi Timeline kết thúc.
    public void OnTimelineEnd()
    {
        // Tắt Player Clone.
        gameObject.SetActive(false);

        // Bật Player chính tại vị trí spawnPoint.
        CameraMain.SetActive(true);

    }
}