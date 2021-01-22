using UnityEngine;

public class TriggerVolume : MonoBehaviour
{
    [SerializeField] private TriggerType triggerType;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        GameManager.Instance.PlayerEnteredTrigger(triggerType);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        GameManager.Instance.PlayerEnteredTrigger();
    }
}

public enum TriggerType
{
    None = 0,
    VolumeOne = 1,
    VolumeTwo = 2,
    VolumeThree = 3
}
