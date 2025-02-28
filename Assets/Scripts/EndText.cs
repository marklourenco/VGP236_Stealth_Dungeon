using TMPro;
using UnityEngine;

public class EndText : MonoBehaviour
{
    [SerializeField]
    GameObject text;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Hostile"))
        {
            text.SetActive(true);
        }
    }
}
