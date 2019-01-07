<a href="readme"></a>When components keep references to other components, it's easy to end up with null pointer problems. SafeRefs are a simple way to always know whether a component reference is valid.

## Install

From your unity project folder:

    npm init --force # only if you don't yet have a package.json file
    npm install --save beatthat/safe-refs

The package and all its dependencies will be installed under Assets/Plugins/packages.

In case it helps, a quick video of the above: https://youtu.be/Uss_yOiLNw8

## Usage

An instance of SafeRef<MyComponent>.value will be null if the component or its GameObject has been destroyed.

```csharp
MyComponent someComponent = GetComponentsInChildren<MyComponent>();

var ref = new SafeRef<MyComponent>(someComponent);

// ref.value will return someComponent
Destroy(someComponent.gameObject);
// ref.value will return null
```

...SafeRefs are structs to handle them accordingly

```csharp
public class HandlesStructCorrectly
{
  public void SetComponent(MyComponent c) {
    m_ref = new SafeRef<MyComponent>(c);
  }
  private SafeRef<MyComponent> m_ref;
}

public class HandlesStructIncorrectly
{
  public void SetComponent(MyComponent c) {
    var ref = m_ref; // ref is a copy of m_ref, no longer a reference to the same thing
    ref.value = c; // m_ref has not changed

    // the example above is contrived
    // but just to illustrate the point
    // that you need to be careful
    // to avoid editing copies of struct
  }
  private SafeRef<MyComponent> m_ref;
}
```
