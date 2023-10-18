using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoActionZone : MonoBehaviour
{
    private List<MonoBehaviour> playerScripts = new List<MonoBehaviour>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Lấy danh sách tất cả các script MonoBehaviour gắn trên Player
            MonoBehaviour[] scripts = other.GetComponents<MonoBehaviour>();
            
            // Tắt tất cả các script trên Player
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
            
            // Lưu lại danh sách các script của Player để bật lại sau khi ra khỏi vùng Trigger
            playerScripts = new List<MonoBehaviour>(scripts);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Bật lại tất cả các script đã lưu khi Player ra khỏi vùng Trigger
            foreach (MonoBehaviour script in playerScripts)
            {
                script.enabled = true;
            }
            
            // Xóa danh sách script đã lưu
            playerScripts.Clear();
        }
    }
}
