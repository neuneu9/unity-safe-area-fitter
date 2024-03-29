# Unity Safe Area Fitter

## What’s this?

'Unity Safe Area Fitter' provides safe area RectTransform with Unity.  

## Supported Unity versions

Unity 2021.3 or higher.  

## Installation

Via Package Manager.  
Open the Package Manager window in your Unity editor, select `Add package from git URL...` from the `+` button in the top left, enter following and press the `Add` button.  

```text
https://github.com/neuneu9/unity-safe-area-fitter.git?path=Packages/jp.neuneu9.safe-area-fitter
```

Or open the `Packages/manifest.json` file and add an item like the following to the `dependencies` field.  

```json
"jp.neuneu9.safe-area-fitter": "https://github.com/neuneu9/unity-safe-area-fitter.git?path=Packages/jp.neuneu9.safe-area-fitter",
```

## How to use

### Acquire a Rect Transform that matches the safe area

Just press the Add Component button on any GameObject that has a Rect Transform and select `Safe Area Fitter`.  

### Acquire a Rect Transform that is same the canvas wherever

You can also fit children of `Safe Area Fitter` to the canvas.  
Just press the Add Component button on any GameObject that has a Rect Transform and select `Canvas Fitter`.  
