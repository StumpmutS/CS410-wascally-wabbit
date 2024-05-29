using UnityEngine;
using System.Collections;

public class DeactivateAfterTime : MonoBehaviour
{
    public float deactivateTime = 15f; // Time in seconds before deactivation

    private void OnEnable()
    {
        // Start the coroutine to deactivate the GameObject after the specified time
        StartCoroutine(DeactivateAfterDelay());
    }

    private IEnumerator DeactivateAfterDelay()
    {
        // Wait for the specified time
        yield return new WaitForSeconds(deactivateTime);

        // Deactivate the GameObject
        gameObject.SetActive(false);
    }
}