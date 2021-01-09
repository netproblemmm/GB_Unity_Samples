using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private string _detectTag;
    [SerializeField] private string _triggerOpenDoor;
    [SerializeField] private Animator _doorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_detectTag) == false) return;
        _doorAnimator.ResetTrigger(_triggerOpenDoor);
        _doorAnimator.SetTrigger(_triggerOpenDoor);
    }
}
