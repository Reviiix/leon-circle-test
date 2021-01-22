using UnityEngine;

public static class Movement 
{
    public static void MoveObjectTowardsPointer(Camera camera, Transform transformToMove, float moveSpeed, float remainingDistance)
    {
        var position = transformToMove.position;
        var targetPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        
        if  (Vector3.Distance(position, targetPosition) < remainingDistance) return;
        
        targetPosition.z = position.z;
        position = Vector3.MoveTowards(position, targetPosition, moveSpeed * Time.deltaTime);
        
        transformToMove.position = position;
    }
}
