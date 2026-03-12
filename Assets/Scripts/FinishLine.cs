using UnityEngine;
using TMPro;

public class FinishLine : MonoBehaviour {
    public GameObject levelCompletedImage;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            levelCompletedImage.SetActive(true);
        }
    }
}