using UnityEngine;

public class AISight : MonoBehaviour
{
    public AIAgent agent;
    public Transform eyes;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        // first check: did it find hostile
        if (other.CompareTag("Hostile"))
        {
            // second check: is there wall between
            RaycastHit hit;
            if (Physics.Linecast(eyes.position, other.transform.position, out hit))
            {
                // Something obstructed view
                Debug.DrawLine(eyes.position, hit.point, Color.red, 3.0f);
                if (hit.transform.tag == "Hostile")
                {
                    Debug.Log("Hostile Spotted!");
                    Debug.DrawLine(eyes.position, other.transform.position, Color.green, 3.0f);
                    agent.HostileSpotted(other.transform);
                }
            }
            else
            {
                // No obstruction found
            }
        }
    }
}