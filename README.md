# JsonMask

將Json內的Value隱碼或是加密

[參考來源](https://github.com/ThiagoBarradas/jsonmasking)

## How Use?

```csharp

blacklist : 關鍵字
mask : 隱藏字碼

using JsonMask;

 public static string MaskFields(
    this string json, string[] blacklist, string mask)

 public static string EncryptFields(this string json, string[] blacklist)

Example : 

string JsonStr = @$"[{{""text"": ""This is the text""}}]";
string[] blacklist = { "text" };

jsonstr.MaskFields(blacklist,"***")

jsonstr.EncryptFields(blacklist)
```


| Version  | Author  | Dependencies |  Last updated   | 說明 |
| ------------| ------------|------------|------------ | ------------ |
| 1.0.0  | Tedlin | netstandard2.0 <br> NewtonsoftJson:13.0.3 | 2024/02/07 | |
