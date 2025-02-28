using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform startPoint = null;
    public Transform checkPointsContainer = null;
    private int lastCheckPointIndex = -1;

    private static GameController instance = null;
    public static GameController Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            instance.Initialize();
        }
    }

    private void OnDestroy()
    {
        SaveManager.Instance.Save();
    }

    public void Initialize()
    {
        SaveManager.Instance.Load();
        GameState gameState = SaveManager.Instance.GetGameState();
        lastCheckPointIndex = gameState.LastCheckpoint;
    }

    public void SetPlayerStartPosition(GameObject player)
    {
        if (startPoint != null)
        {
            SetPlayerPosition(player, startPoint.position);
        }
        else
        {
            SetPlayerPosition(player, Vector3.zero);
        }
    }

    public void PlayerDied(GameObject player)
    {
        Assert.IsNotNull(startPoint, "startPoint was not set in the game controller");

        if (lastCheckPointIndex >= 0)
        {
            Transform checkPoint = checkPointsContainer.GetChild(lastCheckPointIndex);
            SetPlayerPosition(player, checkPoint.position);
        }
        else if (startPoint != null)
        {
            player.transform.position = startPoint.position;
        }
        else
        {
            player.transform.position = Vector3.zero;
        }
    }

    private void SetPlayerPosition(GameObject player, Vector3 position)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.position = position;
        }
        else
        {
            player.transform.position = position;
        }
    }

    public void PlayerHitCheckpoint(Transform checkpoint)
    {
        for (int i = 0; i < checkPointsContainer.childCount; i++)
        {
            if (checkpoint == checkPointsContainer.GetChild(i))
            {
                if (lastCheckPointIndex < i)
                {
                    lastCheckPointIndex = i;
                    SaveManager.Instance.SetLastCheckpoint(i);
                }
                break;
            }
        }
    }
}
