using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.tag == "Hostile")
        {
            GameController.Instance.PlayerHitCheckpoint(transform);
        }
        else if (other.tag == "Checkpoint" && tag == "Hostile")
        {
            GameController.Instance.PlayerHitCheckpoint(other.transform);
        }
    }
}
