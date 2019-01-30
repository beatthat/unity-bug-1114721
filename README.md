BUG: In Unity 2019.1.0b1 on Android, System.Type::GetCustomAttribute<T> throw exception (does not occur in Unity 2018.2.17)

DEVICE INFO:
- SM-G930V (Samsung Galaxy S7)
- Android 7.0 / Kernel 3.18.31

UNITY INFO:
- Unity 2019.1.0b1s
- .NET 4

STEPS:

- build apk as bug.apk
- install on device with `adb install bug.apk`
- launch the ‘Bug’ app on devices

EXPECTED:

- should complete initialization and display GREEN circle

OBSERVED:

- fails to complete initialization (indicated by YELLOW square on screen instead of GREEN circle)
- via `adb logcat | grep Unity`,  the following error is revealed:

```
01-30 11:47:04.016 11059 11097 E Unity  : NotSupportedException: System.Configuration.ConfigurationCollectionAttribute::set_CollectionType
01-30 11:47:04.016 11059 11097 E Unity  :  at System.MonoCustomAttrs.GetCustomAttributesBase (System.Reflection.ICustomAttributeProvider obj, System.Type attributeType, System.Boolean inheritedOnly) [0x00000] in <00000000000000000000000000000000>:0 
01-30 11:47:04.016 11059 11097 E Unity  :  at System.MonoCustomAttrs.GetCustomAttributes (System.Reflection.ICustomAttributeProvider obj, System.Type attributeType, System.Boolean inherit) [0x00000] in <00000000000000000000000000000000>:0 
01-30 11:47:04.016 11059 11097 E Unity  :  at System.Attribute.GetCustomAttributes (System.Reflection.MemberInfo element, System.Type type, System.Boolean inherit) [0x00000] in <00000000000000000000000000000000>:0 
01-30 11:47:04.016 11059 11097 E Unity  :  at System.Attribute.GetCustomAttribute (System.Reflection.MemberInfo element, System.Type attributeType, System.Boolean inherit) [0x00000] in <00000000000000000000000000000000>:0 
01-30 11:47:04.016 11059 11097 E Unity  :  at BeatThat.Service.AutowiredServiceRegistrations.LoadWiringsByInterface () [0x00000] in <00000000000000000000000000000000>:0 
01-30 11:47:04.016 11059 11097 E Unity  :  at BeatThat.Service.AutowiredSe
```
