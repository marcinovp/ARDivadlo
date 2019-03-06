using EasyAR;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
[RequireComponent(typeof(MeshRenderer))]
public class TargetVideoPlayer : MonoBehaviour
{
    public ImageTargetBaseBehaviour imageTargetBehaviour;

    private VideoPlayer videoPlayer;
    private MeshRenderer meshRenderer;

    void Awake()
    {
        //Debug.Log("Awake");
        videoPlayer = GetComponent<VideoPlayer>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    private void Start()
    {
        //Debug.Log("Start");
        videoPlayer.prepareCompleted += VideoPlayer_prepareCompleted;
        imageTargetBehaviour.TargetFound += ImageTargetBehaviour_TargetFound;
        imageTargetBehaviour.TargetLost += ImageTargetBehaviour_TargetLost;
    }

    private void VideoPlayer_prepareCompleted(VideoPlayer source)
    {
        Debug.Log("VideoPlayer_prepareCompleted");

        meshRenderer.enabled = true;
    }
    
    private void ImageTargetBehaviour_TargetLost(TargetAbstractBehaviour obj)
    {
        Debug.Log("Target lost");
        videoPlayer?.Pause();
        meshRenderer.enabled = false;
    }

    private void ImageTargetBehaviour_TargetFound(TargetAbstractBehaviour obj)
    {
        Debug.Log("Target found");
        videoPlayer.Play();

        if (videoPlayer.isPrepared)
        {
            meshRenderer.enabled = true;
        }
    }
}
