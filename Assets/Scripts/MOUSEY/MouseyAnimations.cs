using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseyAnimations : MonoBehaviour
{
    private ButtonClicked ButtonClicked;
    private Animator MouseyAnimator;

    private bool _wavingdone;
    private bool _pointfdone;
    private bool _pointbdone;
    private bool _talkingdone;

    void Awake()
    {
        MouseyAnimator = FindObjectOfType<Animator>();
        ButtonClicked = FindObjectOfType<ButtonClicked>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonClicked.clickNumber == 0 && !_wavingdone)
        {
            MouseyAnimator.SetTrigger("waving");
            _wavingdone = true;
        }
        if (ButtonClicked.clickNumber == 1 && !_pointbdone)
        {
            MouseyAnimator.SetTrigger("pointback");
            _pointbdone = true;
        }
        if (ButtonClicked.clickNumber == 3 && !_talkingdone)
        {
            MouseyAnimator.SetTrigger("talking");
            _talkingdone = true;
        }
        if (ButtonClicked.clickNumber == 4 && !_pointfdone)
        {
            MouseyAnimator.SetTrigger("pointforward");
            _pointfdone = true;
        }
    }
}
