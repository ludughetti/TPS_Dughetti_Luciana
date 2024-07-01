using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private float doorSpeed = 2f;
    [SerializeField] private float closeDoorTime = 3f;
    [SerializeField] private float openVerticalPosition = 0f;
    [SerializeField] private float closeVerticalPosition = 0f;

    private bool _triggerClose = false;
    private float _currentVerticalPosition = 0f;
    private float _nextVerticalPosition = 0f;

    private void Update()
    {
        if(_triggerClose)
            CloseDoor();
    }

    public void OpenDoor()
    {
        _nextVerticalPosition = openVerticalPosition;
        StartCoroutine(HandleOpenDoor());
    }

    private void CloseDoor()
    {
        _nextVerticalPosition = closeVerticalPosition;
        StartCoroutine(HandleCloseDoor());
    }

    private IEnumerator HandleOpenDoor()
    {
        while(_currentVerticalPosition > _nextVerticalPosition)
        {
            _currentVerticalPosition -= Time.deltaTime * doorSpeed;
           
            if(_currentVerticalPosition <= _nextVerticalPosition)
                _currentVerticalPosition = _nextVerticalPosition;

            UpdateDoorPosition();

            yield return null;
        }

        // Wait for close door time then change bool to trigger CloseDoor()
        yield return new WaitForSeconds(closeDoorTime);
        _triggerClose = true;
    }

    private IEnumerator HandleCloseDoor()
    {
        while (_currentVerticalPosition < _nextVerticalPosition)
        {
            _currentVerticalPosition += Time.deltaTime * doorSpeed;

            if (_currentVerticalPosition >= _nextVerticalPosition)
                _currentVerticalPosition = _nextVerticalPosition;

            UpdateDoorPosition();

            yield return null;
        }
    }

    private void UpdateDoorPosition()
    {
        Vector3 position = door.transform.position;
        position.y = _currentVerticalPosition;
        door.transform.position = position;
    }
}
