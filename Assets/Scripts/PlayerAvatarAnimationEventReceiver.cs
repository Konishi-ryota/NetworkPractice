using UnityEngine;

public class PlayerAvatarAnimationEventReceiver : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] footstepAudioClipArray;

    [SerializeField]
    private AudioClip landingAudioClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnFootstep(AnimationEvent animationEvent)
    {

    }
}
