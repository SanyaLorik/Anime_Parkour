public static class AsyncExtension
{
    public static int ToDelayMillisecond(this float number) =>
        (int)(number * 1000);
}
