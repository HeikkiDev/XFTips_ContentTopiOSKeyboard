using Xamarin.Forms;

namespace ContentTopiOSKeyboard.CustomControls
{
    /// <summary>
    /// Grid that goes up when iOS keyboard appears. Need an AbsoluteLayout as parent.
    /// </summary>
    public class CustomChatGrid : Grid
    {
        public CustomChatGrid()
        {
            AbsoluteLayout.SetLayoutBounds(this, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(this, AbsoluteLayoutFlags.SizeProportional);
        }
    }
}
