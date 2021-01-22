using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const int MovementSpeed = 3;
    private const float MousePlayerMinimumDistance = 0.01f;
    private static float _camerasDistanceFromGame;
    private static Camera _mainCamera;
    private static float MousePlayerActualMinimumDistance => MousePlayerMinimumDistance + _camerasDistanceFromGame;

    private void Awake()
    {
        ResolveDependencies();
    }

    private static void ResolveDependencies()
    {
        _mainCamera = Camera.main;
        _camerasDistanceFromGame = -_mainCamera.transform.position.z;
    }

    private void Update()
    {
        Movement.MoveObjectTowardsPointer(_mainCamera, transform, MovementSpeed, MousePlayerActualMinimumDistance);
    }
}
