using System.Collections.Generic;

public struct _BinBase
{
    private readonly IEnumerable<Ground> _grounds;
    private readonly int _totalCount;
    private int _passedCounter;

    public _BinBase(IEnumerable<Ground> grounds, int totalCount)
    {
        _grounds = grounds;
        _totalCount = totalCount;
        _passedCounter = 0;
    }

    public bool IsSecondlast => _passedCounter == _totalCount - 1;

    public bool IsReady => _passedCounter <= 0;

    public void Enable()
    {

    }

    public void Disable()
    {

    }
}