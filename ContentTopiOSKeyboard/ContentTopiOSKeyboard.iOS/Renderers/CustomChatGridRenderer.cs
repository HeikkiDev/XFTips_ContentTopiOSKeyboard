using ContentTopiOSKeyboard.CustomControls;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomChatGrid), typeof(ContentTopiOSKeyboard.iOS.Renderers.CustomChatGridRenderer))]
namespace ContentTopiOSKeyboard.iOS.Renderers
{
    public class CustomChatGridRenderer : ViewRenderer
    {
        NSObject _keyboardShowObserver;
        NSObject _keyboardHideObserver;


        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                RegisterForKeyboardNotifications();
            }
            if (e.OldElement != null)
            {
                UnregisterForKeyboardNotifications();
            }
        }

        private void RegisterForKeyboardNotifications()
        {
            if (_keyboardShowObserver == null)
                _keyboardShowObserver = UIKeyboard.Notifications.ObserveWillShow(OnKeyboardShow);
            if (_keyboardHideObserver == null)
                _keyboardHideObserver = UIKeyboard.Notifications.ObserveWillHide(OnKeyboardHide);
        }

        private void UnregisterForKeyboardNotifications()
        {
            if (_keyboardShowObserver != null)
            {
                _keyboardShowObserver.Dispose();
                _keyboardShowObserver = null;
            }

            if (_keyboardHideObserver != null)
            {
                _keyboardHideObserver.Dispose();
                _keyboardHideObserver = null;
            }
        }

        private void OnKeyboardShow(object sender, UIKeyboardEventArgs args)
        {

            NSValue result = (NSValue)args.Notification.UserInfo.ObjectForKey(new NSString(UIKeyboard.FrameEndUserInfoKey));
            CGSize keyboardSize = result.RectangleFValue.Size;
            if (Element != null)
            {
                // Move the Grid on top of keyboard
                AbsoluteLayout.SetLayoutBounds(Element, new Rectangle(0, -keyboardSize.Height, 1, 1));
                AbsoluteLayout.SetLayoutFlags(Element, AbsoluteLayoutFlags.SizeProportional);
            }
        }

        private void OnKeyboardHide(object sender, UIKeyboardEventArgs args)
        {
            if (Element != null)
            {
                // Reset the Grid to original position
                AbsoluteLayout.SetLayoutBounds(Element, new Rectangle(0, 0, 1, 1));
                AbsoluteLayout.SetLayoutFlags(Element, AbsoluteLayoutFlags.SizeProportional);
            }
        }
    }
}