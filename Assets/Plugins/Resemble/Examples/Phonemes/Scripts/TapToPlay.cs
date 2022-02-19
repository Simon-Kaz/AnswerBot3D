using UnityEngine;
using UnityEngine.Events;

public class TapToPlay : MonoBehaviour
{
    public Animator anim;
    public new AudioSource audio;
    public UnityEvent onTrigger;

    private void Update()
    {
        if (audio.isPlaying) return;

        if (Input.GetKeyDown(KeyCode.Space))
            Invoke();

        #if UNITY_ANDROID
        if (Input.touchCount <= 0) return;
        
        var touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Ended)
        {
            Invoke();
        }
        #endif
    }

    public void Invoke()
    {
        audio.Play();
        anim.SetTrigger("Talk");
        onTrigger.Invoke();
    }
}