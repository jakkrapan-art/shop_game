public interface IInteractResult { }

public class ReceiveItemResult : IInteractResult
{
  public string Item { get; private set; }
  public int Amount { get; private set; }

  public ReceiveItemResult(string item, int amount)
  {
    Item = item;
    Amount = amount;
  }
}

public class RemoveItemResult : IInteractResult
{
  public string Item { get; private set; }
  public int Amount { get; private set; }

  public RemoveItemResult(string item, int amount)
  {
    Item = item;
    Amount = amount;
  }
}