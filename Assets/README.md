BUG: In Unity 2018.3.0f2 on Android, System.Type::GetCustomAttribute<T> throw exception (does not occur in Unity 2018.2.17)

DEVICE INFO:
- SM-G930V (Samsung Galaxy S7)
- Android 7.0 / Kernel 3.18.31

UNITY INFO:
- Unity 2018.3.0f2
- .NET 4

STEPS:

- build apk as bug.apk
- install on device with `adb install bug.apk`

EXPECTED:

- should complete initialization and display GREEN circle

OBSERVED:

- fails to complete initialization (indicated by YELLOW square)
- via `adb logcat | grep Unity`,  the following error is revealed:

```
01-04 16:58:37.053 13355 13371 E Unity   : NotSupportedException: System.Configuration.ConfigurationCollectionAttribute::.ctor
01-04 16:58:37.053 13355 13371 E Unity   :   at System.Configuration.ConfigurationCollectionAttribute..ctor (System.Type itemType) [0x00000] in <00000000000000000000000000000000>:0 
01-04 16:58:37.053 13355 13371 E Unity   :   at System.MonoCustomAttrs.GetCustomAttributesBase (System.Reflection.ICustomAttributeProvider obj, System.Type attributeType, System.Boolean inheritedOnly) [0x00000] in <00000000000000000000000000000000>:0 
01-04 16:58:37.053 13355 13371 E Unity   :   at System.MonoCustomAttrs.GetCustomAttributes (System.Reflection.ICustomAttributeProvider obj, System.Type attributeType, System.Boolean inherit) [0x00000] in <00000000000000000000000000000000>:0 
01-04 16:58:37.053 13355 13371 E Unity   :   at System.Attribute.GetCustomAttributes (System.Reflection.MemberInfo element, System.Type type, System.Boolean inherit) [0x00000] in <00000000000000000000000000000000>:0 
01-04 16:58:37.053 13355 13371 E Unity   :   at System.Attribute.GetCustomAttribute (System.Reflection.MemberInfo element, System.Type attributeType, System.Boolean inherit) [0x00000] in <00000000000000000000000000000000>:0 
01-04 16:58:37.053 13355 13371 E Unity   :   at BeatThat.Service.AutowiredServi
```

WHAT I HAVE TRIED:

- Reproducing the bug on older versions of Unity

The bug does NOT occur on Unity 2018.2.17 or any version I've tested.

- Creating a simpler project that further isolates the cause of the bug

Since the logs suggest a problem with use of System.Type::GetCustomAttribute<T> (an extension function from System.Reflection), I tried to set up a simpler project to reproduce the bug that only defines a custom attribute, MyAttribute, and then calls GetCustomAttribute<MyAttribute>(). So far, I have not been able to reproduce the bug in the simpler-project setting.


