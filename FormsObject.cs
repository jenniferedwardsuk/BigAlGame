using UnityEngine;
using UnityEngine.UI;

public class FormsObject  {

    // class for applying Windows Forms code to unity targets. Assumes Unity2D/recttransforms.
    RectTransform targettransform;
    SpriteRenderer targetimage;
    Image targetimage2;
    Animator targetimageanimation;

    public FormsObject(string targetobjectname)
    {
        GameObject targetobject = GameObject.Find(targetobjectname);
        if (targetobject != null)
        {
            targettransform = targetobject.GetComponent<RectTransform>();
            if (!targettransform)
            {
                Debug.Log("Warning: transform equivalent not found for conversion object " + targetobject.name);
            }

            targetimage = targetobject.GetComponent<SpriteRenderer>();
            if (!targetimage)
                targetimage2 = targetobject.GetComponent<Image>();
            if (!targetimage && !targetimage2)
            {
                Debug.Log("Warning: no image or sprite found for conversion object " + targetobject.name);
            }

            if (targetimage || targetimage2)
                targetimageanimation = targetobject.GetComponent<Animator>();
        }
        else
        {
            Debug.Log("Error: conversion object not specified.");
        }
    }

    // forms-to-unity conversion functions

    // width/height property
    public Vector2 GetRectWidthHeight()
    {
        return targettransform.sizeDelta;
    }
    public float GetRectWidth()
    {
        return targettransform.sizeDelta.x;
    }
    public float GetRectHeight()
    {
        return targettransform.sizeDelta.y;
    }
    public void SetRectWidthHeight(Vector2 newsize)
    {
        targettransform.sizeDelta = newsize;
    }
    public void SetRectWidth(int newwidth)
    {
        targettransform.sizeDelta = new Vector2(newwidth, targettransform.sizeDelta.y);
    }
    public void SetRectHeight(int newheight)
    {
        targettransform.sizeDelta = new Vector2(targettransform.sizeDelta.x, newheight);
    }

    // location property
    public Vector2 GetRectPosition()
    {
        return targettransform.position;
    }
    public void SetRectPosition(Vector2 newposition)
    {
        targettransform.position = newposition;
    }

    // sprite fetch for enable/disable
    public SpriteRenderer GetSpriteRenderer()
    {
        return targetimage;
    }
    // image fetch for enable/disable
    public Image GetImage()
    {
        return targetimage2;
    }
    public void SetSpriteImage(string filepath)
    {
        if (targetimage != null)
            targetimage.sprite = Resources.Load(filepath, typeof(Sprite)) as Sprite;
        else
            targetimage2.sprite = Resources.Load(filepath, typeof(Sprite)) as Sprite;

    }
    public void SetSpriteColor(Color newcolor)
    {
        if (targetimage != null)
            targetimage.color = newcolor;
        else
            targetimage2.color = newcolor;
    }

    // animation fetch for health images
    public Animator GetAnimator()
    {
        return targetimageanimation;
    }
}
