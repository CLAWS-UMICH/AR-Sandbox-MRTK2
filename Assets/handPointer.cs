using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class handPointer : MonoBehaviour
{
    void Update()
    {
        double swipeDistance = 0.5;
        foreach(var source in MixedRealityToolkit.InputSystem.DetectedInputSources)
        {
            if (source.SourceType == Microsoft.MixedReality.Toolkit.Input.InputSourceType.Hand)
            {
                foreach (var p in source.Pointers)
                {
                    if (p is IMixedRealityNearPointer)
                    {
                        // Ignore near pointers, we only want the rays
                        continue;
                    }
                    if (p.Result != null)
                    {
                        var startPoint = p.Position;
                        var endPoint = p.Result.Details.Point;
                        var hitObject = p.Result.Details.Object;
                        if (hitObject)
                        {
                            if (startPoint != endPoint)
                            {
                                Debug.Log($"startPos: {startPoint}");
                                Debug.Log($"endPos: {endPoint}");
                            }
                        }
                    }

                }
            }
        }
    }
}
