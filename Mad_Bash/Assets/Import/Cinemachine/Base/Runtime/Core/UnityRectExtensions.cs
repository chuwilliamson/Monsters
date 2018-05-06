using UnityEngine;

namespace Cinemachine.Utility
{
    /// <summary>Ad-hoc xxtentions to the Rect structure, used by Cinemachine</summary>
    public static class UnityRectExtensions
    {
        /// <summary>Inflate a rect</summary>
        /// <param name="r"></param>
        /// <param name="delta">x and y are added/subtracted fto/from the edges of
        /// the rect, inflating it in all directions</param>
        /// <returns>The inflated rect</returns>
        public static Rect Inflated(this Rect r, Vector2 delta)
        {
            return new Rect(
                r.xMin - delta.x, r.yMin - delta.y,
                r.width + delta.x * 2, r.height + delta.y * 2);
        }
    }
}