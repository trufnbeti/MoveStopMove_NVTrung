using UnityEngine;
public class CameraFollow : GameUnit
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;

    private Vector3 desiredPosition;
    
    private void LateUpdate()
    {
        desiredPosition = target.position + offset;
        TF.position = Vector3.Lerp(TF.position, desiredPosition, smoothSpeed);
    }
}