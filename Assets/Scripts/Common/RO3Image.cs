using UnityEngine;

namespace Common
{
    public enum SideToAdjust
    {
        Width,
        Height
    }

    public class RO3Image : MonoBehaviour
    {
        public float originalWidth;
        public float originalHeight;

        public SideToAdjust sideToAdjust;

        public bool updateEveryFrame = false;

        private void Awake()
        {
            RuleOfThreeImage();
        }

        private void Update()
        {
            if (updateEveryFrame)
            {
                RuleOfThreeImage();
            }
        }

        private void RuleOfThreeImage()
        {
            Canvas.ForceUpdateCanvases();

            var t = GetComponent<RectTransform>();
            float newLength;
            switch (sideToAdjust)
            {
                case SideToAdjust.Width:
                    newLength = (t.rect.height * originalWidth) / originalHeight;
                    t.sizeDelta = new Vector2(newLength, 0);
                    break;
                case SideToAdjust.Height:
                    newLength = (t.rect.width * originalHeight) / originalWidth;
                    t.sizeDelta = new Vector2(0, newLength);
                    break;
            }

            Canvas.ForceUpdateCanvases();
        }
    }
}