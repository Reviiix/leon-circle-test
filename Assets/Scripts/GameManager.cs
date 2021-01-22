using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private static Vector3 _defaultPlayerScale;
    private static float _defaultPlayerTriggerRadius;
    private static MeshRenderer _playerRenderer;
    private static Transform _playerTransform;
    private static SphereCollider _playerCollider;
    private static readonly Vector3 SmallPlayerScale = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Material defaultPlayerMaterial;
    [SerializeField] private Material yellowMaterial;
    [SerializeField] private Material redMaterial;

    private void Awake()
    {
        ResolveDependencies();
    }

    private void ResolveDependencies()
    {
        Instance = this;
        _playerTransform = playerObject.transform;
        _playerRenderer = playerObject.GetComponent<MeshRenderer>();
        _playerCollider = playerObject.GetComponent<SphereCollider>();
        _defaultPlayerScale = _playerRenderer.transform.localScale;
        _defaultPlayerTriggerRadius = _playerCollider.radius;
    }

    public void PlayerEnteredTrigger(TriggerType triggerType = TriggerType.None)
    {
        TextManager.SetDisplayText((int)triggerType);
        
        switch (triggerType)
        {
            case TriggerType.None:
                _playerRenderer.material = defaultPlayerMaterial;
                _playerTransform.localScale = _defaultPlayerScale;
                _playerCollider.radius = _defaultPlayerTriggerRadius;
                break;
            case TriggerType.VolumeOne:
                _playerRenderer.material = yellowMaterial;
                break;
            case TriggerType.VolumeTwo:
                _playerRenderer.material = redMaterial;
                break;
            case TriggerType.VolumeThree:
                _playerTransform.localScale = SmallPlayerScale;
                //POTENTIAL BUG
                //As the player leaves the trigger, there sphere is now bigger and there for is BACK IN TRIGGER because of its bigger size!
                _playerCollider.radius *= 2; //This stops that from happening but means the player stays small for an area outside of the trigger.
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(triggerType), triggerType, null);
        }
    }
}

