using UnityEngine;

public class TriggerVolume : MonoBehaviour
{
    [SerializeField] private TriggerType triggerType;

    private void OnTriggerEnter(Collider other)
    {
        TextManager.SetDisplayText((int)triggerType);
    }
}

public enum TriggerType
{
    None = 0,
    VolumeOne = 1,
    VolumeTwo = 2,
    VolumeThree = 3
}
