using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animacionUi : MonoBehaviour
{
    // Start is called before the first frame update
    public Image m_Image;
    public Sprite[] sprites;
    public float m_Speed = .02f;
    private int m_IndexSprite;
    Coroutine m_CorotineAnim;
    bool IsDone=false;

    public void Func_PlayUIAnim()
    {
        IsDone = false;
        m_CorotineAnim = StartCoroutine(Func_PlayAnimUI());
    }
    public void Func_StopUIAnim()
    {
        IsDone = true;
        StopCoroutine(m_CorotineAnim);
    }
    IEnumerator Func_PlayAnimUI()
    {
        yield return new WaitForSeconds(m_Speed);
        if (m_IndexSprite >= sprites.Length)
        {
            m_IndexSprite = 0;
            IsDone = true;
        }
        else
        {
            IsDone = false;
        }
        m_Image.sprite = sprites[m_IndexSprite];
        m_IndexSprite += 1;
        if (IsDone == false)
        {
            m_CorotineAnim = StartCoroutine(Func_PlayAnimUI());
        }
        else
        {
            Func_StopUIAnim();
        }
    }
}
