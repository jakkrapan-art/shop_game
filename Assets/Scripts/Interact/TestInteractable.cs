using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{
  public Vector2 GetPosition()
  {
    return transform.position;
  }

  public IInteractResult[] Interact()
  {
    IInteractResult[] results = new IInteractResult[2];
    return results;
  }
}
