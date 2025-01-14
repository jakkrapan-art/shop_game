using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController
{
  private Transform _transform;
  private float _interactRange = .25f;

  public InteractController(float range, Transform characterTransform)
  {
    _interactRange = range;
    _transform = characterTransform;
  }

  public bool IsCanInteract(Vector2 position, Vector2 targetPos, float characterWidth)
  {
    float maxDistance = _interactRange + (characterWidth * 0.5f);
    var distance = Vector2.Distance(position, targetPos);
    return distance <= maxDistance;
  }

  public void InteractTo(IInteractable target)
  {
    if (target == null) return;

    if (IsCanInteract(_transform.position, target.GetPosition(), _transform.lossyScale.x)) return;

    var results = target.Interact();
    foreach (var result in results)
    {
      switch (result)
      {
        case ReceiveItemResult receive:
          ExecuteReceiveItem(receive); break;
        case RemoveItemResult remove:
          ExecuteRemoveItem(remove); break;
      }
    }
  }

  private void ExecuteReceiveItem(ReceiveItemResult receiveRes)
  {

  }

  private void ExecuteRemoveItem(RemoveItemResult removeRes)
  {

  }
}

public interface IInteractable
{
  public IInteractResult[] Interact();
  public Vector2 GetPosition();
}
