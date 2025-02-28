using UnityEngine;

public class KillLight : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.tag == "Hostile")
        {
            GameController.Instance.PlayerDied(other.gameObject);
        }
    }
}
