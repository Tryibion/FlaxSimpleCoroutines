# Simple Coroutines for the Flax Engine
This is a plugin project that adds a simple implimentation of coroutines in C# to any Flax Engine project.

Enjoy this plugin? Here is a link to donate on [ko-fi](https://ko-fi.com/tryibion).

## Installation
To add this plugin project to your game, follow the instructions in the [Flax Engine documentation](https://docs.flaxengine.com/manual/scripting/plugins/plugin-project.html#automated-git-cloning) for adding a plugin project automatically using git or manually.

## Setup
1. Install the plugin into the Flax Engine game project.
2. Create a method with `IEnumerator` as a return type. In the method use `yield return` followed by the desired yield instruction. Example: `yield return new WaitForSeconds(5)` to wait 5 seconds.
3. Use the `SimpleCoroutine` static class to start and stop coroutines.

## Examples

### WaitForSeconds
This example shows a simple way to wait 5 seconds in a coroutine method.

```csharp
// Starting the coroutine.
void OnStart()
{
    SimpleCoroutine.StartCoroutine(MyCoroutine(), this);
}

// Coroutine Method
IEnumerator MyCoroutine()
{
     yield return new WaitForSeconds(5);
     Debug.Log("This is called 5 seconds later.");
}
```

### Simple Invoke

This plugin contains a simple way to execute a method after a certain amount of time using the `Invoke` method. Here is an example of how to use it.

```csharp
void OnStart()
{
    SimpleCoroutine.Invoke(MetodCalledIn5Seconds, 5, this);
}

void MethodCalledIn5Seconds()
{
     Debug.Log("This is called 5 seconds later.");
}
```

### Wait Until
This example waits until a specific member variable boolean is true before continuing to execute.

```csharp

private bool ThisNeedsToBeTrueToContinue = false;

// Starting the coroutine.
void OnStart()
{
    SimpleCoroutine.StartCoroutine(MyCoroutine(), this);
}

// Coroutine Method
IEnumerator MyCoroutine()
{
     yield return new WaitUntil(() => ThisNeedsToBeTrueToContinue);
     Debug.Log("This is called after ThisNeedsToBeTrueToContinue boolean is set to true.");
}
```

## Important classes
- `SimpleCoroutine` - a static class used to interact with he ccoroutine system.

## Built in Yield Instructions
- `WaitForSeconds` - waits a defined number of seconds before continuing.
- `WaiForFrames` - waits for a defined number of frames before continuing.
- `WaitForNextFrame` - similar to `yield return null` and waits to continue until the next frame.
- `WaitUntil` - waits until the passed in Func returns true before continuing.
- `WaitWhile` - waits until the passed in Func returns false before continuing.
