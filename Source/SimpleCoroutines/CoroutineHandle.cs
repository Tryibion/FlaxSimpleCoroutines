using System;
using System.Collections;

namespace SimpleCoroutines;

// A helper class to manage a running coroutine instance, including its current instruction.
public struct CoroutineHandle
{
    public IEnumerator Coroutine;
    public IYieldInstruction CurrentInstruction;
    public object Owner;

    public CoroutineHandle(IEnumerator coroutine, Object owner)
    {
        Coroutine = coroutine;
        CurrentInstruction = null;
        Owner = owner;
    }
}