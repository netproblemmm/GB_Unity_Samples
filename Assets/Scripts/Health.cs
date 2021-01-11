using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _startHealth;
    [SerializeField] private int _healthInCrate;
    [SerializeField] private string _detectTag;
    [SerializeField] private float _delayBeforeDestroy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_detectTag) == false) return;

        var otherBody = other.gameObject.GetComponent<Rigidbody>();
        Destroy(other.gameObject, _delayBeforeDestroy);
        Destroy(gameObject);

        _startHealth += _healthInCrate;
    }
}
