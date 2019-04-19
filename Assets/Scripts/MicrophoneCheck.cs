using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

/// Checks if the app has Microphone permissions on  the device it's running 
/// on. This check is only necessary on Android devices. If the app doesn't
/// have permission, it will display a dialog asking for Microphone permission.
///
/// author: Akash Eldo (axe1412)
public class MicrophoneCheck : MonoBehaviour 
{
    GameObject dialog = null;
    
    void Start ()
    {
        #if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
        #endif
    }
}