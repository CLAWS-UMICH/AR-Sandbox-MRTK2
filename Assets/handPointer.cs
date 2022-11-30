using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class handPointer : MonoBehaviour
{
    void Update()
    {
        double swipeDistance = 0.2;
        foreach(var source in MixedRealityToolkit.InputSystem.DetectedInputSources)
        {
            if (source.SourceType == Microsoft.MixedReality.Toolkit.Input.InputSourceType.Hand)
            {
                foreach (var p in source.Pointers)
                {
                    // if (p is IMixedRealityNearPointer)
                    // {
                    //     // Ignore near pointers, we only want the rays
                    //     continue;
                    // }
                    if (p.Result != null)
                    {
                        var startPointy = p.Position[1];
                        var endPointy = p.Result.Details.Point[1];
                        var startPointx = p.Position[0];
                        var endPointx = p.Result.Details.Point[0];
                        var hitObject = p.Result.Details.Object;
                        if (hitObject)
                        {
                            // Debug.Log($"startPos: {startPoint}");
                            // Debug.Log($"endPos: {endPoint}");
                            if (startPointy + swipeDistance >= endPointy)
                            {
                                Debug.Log("Swiped Up");
                            }
                            if (startPointy + swipeDistance <= endPointy)
                            {
                                Debug.Log("Swiped Down");
                            }
                            if (startPointx + swipeDistance >= endPointx)
                            {
                                Debug.Log("Swiped Right");
                            }
                            if (startPointx + swipeDistance <= endPointx)
                            {
                                Debug.Log("Swiped Left");
                            }
                        }
                    }
                }
            }
        }
    }
}
