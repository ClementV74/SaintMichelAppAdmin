package crc64ec3c54a6f007a048;


public class StayOnFrontView
	extends android.widget.FrameLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAttachedToWindow:()V:GetOnAttachedToWindowHandler\n" +
			"n_onDetachedFromWindow:()V:GetOnDetachedFromWindowHandler\n" +
			"";
		mono.android.Runtime.register ("The49.Maui.BottomSheet.StayOnFrontView, The49.Maui.BottomSheet", StayOnFrontView.class, __md_methods);
	}

	public StayOnFrontView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == StayOnFrontView.class) {
			mono.android.TypeManager.Activate ("The49.Maui.BottomSheet.StayOnFrontView, The49.Maui.BottomSheet", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2, p3 });
		}
	}

	public StayOnFrontView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == StayOnFrontView.class) {
			mono.android.TypeManager.Activate ("The49.Maui.BottomSheet.StayOnFrontView, The49.Maui.BottomSheet", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}

	public StayOnFrontView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == StayOnFrontView.class) {
			mono.android.TypeManager.Activate ("The49.Maui.BottomSheet.StayOnFrontView, The49.Maui.BottomSheet", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}

	public StayOnFrontView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == StayOnFrontView.class) {
			mono.android.TypeManager.Activate ("The49.Maui.BottomSheet.StayOnFrontView, The49.Maui.BottomSheet", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}

	public void onAttachedToWindow ()
	{
		n_onAttachedToWindow ();
	}

	private native void n_onAttachedToWindow ();

	public void onDetachedFromWindow ()
	{
		n_onDetachedFromWindow ();
	}

	private native void n_onDetachedFromWindow ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
