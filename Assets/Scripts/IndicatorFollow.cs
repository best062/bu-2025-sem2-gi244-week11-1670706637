using UnityEngine;

public class IndicatorFollow : MonoBehaviour
{
    [Header("Target Setup")]
    public Transform playerTarget; 
    public Vector3 offset;         

    void LateUpdate()
    {
        if (playerTarget != null)
        {
            transform.position = playerTarget.position + offset;
        }
    }
}