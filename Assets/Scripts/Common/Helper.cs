namespace Common
{
    public enum TestType
    {
        Theory,
        Pratical
    }

    public enum VideoDirection
    {
        Forward,
        Backwards
    }

    public enum GoodsState
    {
        Good,
        Damaged
    }

    public enum Character
    {
        Man,
        Woman,
        None
    }

    public static class Helper
    {
        public static float RemapNumber(float num, float low1, float high1, float low2, float high2)
        {
            return low2 + (num - low1) * (high2 - low2) / (high1 - low1);
        }
    }
}
