using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    private GameObject _ghost;
    private bool _isSpawned = false;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _indentY;

    private void Start()
    {
        if (_isSpawned) return;
        _ghost = GameObject.Find("Ghost_1");
        //Instantiate(_ghost, _startPosition.position + new Vector3(0, _indentY, 0), _startPosition.rotation);
        Instantiate(_ghost, _startPosition.position, _startPosition.rotation);
        _ghost.SetActive(false);
        _isSpawned = true;
    }
}