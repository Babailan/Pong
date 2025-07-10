using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameField : MonoBehaviour
{
    // 16:9 ratio of court
    public static float courtHeight = 5.0f;
    public static float courtWidth = (16f / 9f) * courtHeight;
    public enum Position
    {
        Top,
        Right,
        Left,
        Bottom
    }

    static private Dictionary<Position, Vector2> PositionMap = new()
    {
        {Position.Top ,Vector2.up},
        {Position.Bottom,Vector2.down},
        {Position.Left,Vector2.left},
        {Position.Right,Vector2.right}
    };

    public Position position;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // setupBoundary();
    }

    void setupBoundary()
    {
        float complementarySize = 0.3f;
        GameObject top = new("TopBoundary");
        GameObject bottom = new("BottomBoundary");
        GameObject left = new("LeftBoundary");
        GameObject right = new("RightBoundary");
        GameObject[] HorizontalBoundary = { top, bottom };
        for (int i = 0; i < HorizontalBoundary.Length; i++)
        {
            SpriteRenderer spriteRenderer = HorizontalBoundary[i].AddComponent<SpriteRenderer>();
            Sprite square = Resources.Load<Sprite>("Square");
            spriteRenderer.sprite = Resources.Load<Sprite>("Square");
            // formula for getting the max width of court is (x/100 ppu = courtWidth) or x= (100*courtwidth) since 100 ppu = 1 units of measurement
            spriteRenderer.drawMode = SpriteDrawMode.Sliced;
            spriteRenderer.size = new Vector2(courtWidth * 2, complementarySize);
        }
        top.transform.position = new Vector2(0, Math.Abs(courtHeight + (complementarySize / 2)));
        bottom.transform.position = new Vector2(0, -Math.Abs(courtHeight + (complementarySize / 2)));
        GameObject[] VerticalBoundary = { left, right };
    }

    // Update is called once per frame
    void Update()
    {
    }
}
