using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked;

    public Transform rightDoorPivot;
    public Transform leftDoorPivot;

    private bool _isOpen;

    private Player _player;

    public float doorCloseDistanceThreshold;

    private void Start()
    {
        _player = GameDirector.instance.player;
    }

    private void Update()
    {
        var distance = (transform.position - _player.transform.position).magnitude;
        if (_isOpen && distance > doorCloseDistanceThreshold)
        {
            CloseDoor();
        }
    }

    public void DoorInteracted(bool haveKey)
    {
        if (_isOpen)
        {
            CloseDoor();
        }
        else if (!isLocked)
        {
            OpenDoor();
        }
        else if (haveKey)
        {
            OpenDoor();
            isLocked = false;
            _player.haveKey = false;
        }
        else
        {
            print("Door is Locked!");
        }
    }

    public void OpenDoor()
    {
        rightDoorPivot.DOKill();
        rightDoorPivot.DOLocalMoveX(1.2f, .2f);
        leftDoorPivot.DOKill();
        leftDoorPivot.DOLocalMoveX(-1.2f, .2f);
        _isOpen = true;
    }

    public void CloseDoor()
    {
        rightDoorPivot.DOKill();
        rightDoorPivot.DOLocalMoveX(0, .2f);
        leftDoorPivot.DOKill();
        leftDoorPivot.DOLocalMoveX(0, .2f);
        _isOpen = false;
    }
}
