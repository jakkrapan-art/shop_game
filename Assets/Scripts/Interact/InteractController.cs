using System;
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

  public bool IsCanInteract(float positionX, float targetPosX, float characterWidth)
  {
    float maxDistance = _interactRange + (characterWidth * 0.5f);
    var distance = Mathf.Abs(positionX - targetPosX);
    return distance <= maxDistance;
  }

  public void InteractTo(IInteractable target, Action onComplete)
  {
    if (target == null) return;

    if (!IsCanInteract(_transform.position.x, target.GetPosition().x, _transform.lossyScale.x)) return;
    target.Interact(res =>
    {
      foreach (var result in res)
      {
        switch (result)
        {
          case ReceiveItemResult receive:
            ExecuteReceiveItem(receive); break;
          case RemoveItemResult remove:
            ExecuteRemoveItem(remove); break;
        }
      }

      onComplete?.Invoke();
    });
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
  public void Interact(Action<IInteractResult[]> onInteractComplete);
  public Vector2 GetPosition();
}
