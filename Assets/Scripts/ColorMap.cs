using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMap 
{
    public Color color;
    public enum ColorMapping {White,Red,Green,Blue,Cyan,Magenta,Yellow,Black,Purple,Orange,Brown};
    public ColorMapping colorMap;
    public void SetColorMap(ColorMapping cm)
    {
        if (cm == ColorMapping.White)
        {
            color = Color.white;
        }
        else if (cm == ColorMapping.Red)
        {
            color = Color.red;
        }
        else if (cm == ColorMapping.Green)
        {
            color = Color.green;
        }
        else if (cm == ColorMapping.Blue)
        {
            color = Color.blue;
        }
        else if (cm == ColorMapping.Cyan)
        {
            color = Color.cyan;
        }
        else if (cm == ColorMapping.Magenta)
        {
            color = Color.magenta;
        }
        else if (cm == ColorMapping.Yellow)
        {
            color = Color.yellow;
        }
        else if (cm == ColorMapping.Black)
        {
            color = Color.black;
        }
        else if (cm == ColorMapping.Purple)
        {
            color = Color.magenta;
        }
        else if (cm == ColorMapping.Orange)
        {
            //color = Color.;
        }
    }
    public ColorMapping CombineColors(Color c1, Color c2)
    {
        if (c1 == Color.red && c2 == Color.green || c2 == Color.red && c1 == Color.green)
        {
            return ColorMapping.Yellow;
        }
        if (c1 == Color.red && c2 == Color.blue || c2 == Color.red && c1 == Color.blue)
        {
            return ColorMapping.Purple;
        }
        if (c1 == Color.blue && c2 == Color.green || c2 == Color.blue && c1 == Color.green)
        {
            return ColorMapping.Cyan;
        }
        else
        {
            return ColorMapping.White;
        }
    }
   
}
