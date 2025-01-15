using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{
  public Vector2 GetPosition()
  {
    return transform.position;
  }

  public void Interact(Action<IInteractResult[]> onComplete)
  {
    StartCoroutine(DelayInteract(5, onComplete));
  }

  private IEnumerator DelayInteract(float second, Action<IInteractResult[]> onComplete) {
    yield return new WaitForSeconds(second);
    IInteractResult[] results = new IInteractResult[0];
    onComplete?.Invoke(results);
  }
}
