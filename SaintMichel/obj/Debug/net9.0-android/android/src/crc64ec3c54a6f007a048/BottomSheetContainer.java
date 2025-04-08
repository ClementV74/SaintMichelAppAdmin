package crc64ec3c54a6f007a048;


public class BottomSheetContainer
	extends android.widget.FrameLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("The49.Maui.BottomSheet.BottomSheetContainer, The49.Maui.BottomSheet", BottomSheetContainer.class, __md_methods);
	}

	public BottomSheetContainer (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == BottomSheetContainer.class) {
			mono.android.TypeManager.Activate ("The49.Maui.BottomSheet.BottomSheetContainer, The49.Maui.BottomSheet", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2, p3 });
		}
	}

	public BottomSheetContainer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == BottomSheetContainer.class) {
			mono.android.TypeManager.Activate ("The49.Maui.BottomSheet.BottomSheetContainer, The49.Maui.BottomSheet", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}

	public BottomSheetContainer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == BottomSheetContainer.class) {
			mono.android.TypeManager.Activate ("The49.Maui.BottomSheet.BottomSheetContainer, The49.Maui.BottomSheet", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}

	public BottomSheetContainer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == BottomSheetContainer.class) {
			mono.android.TypeManager.Activate ("The49.Maui.BottomSheet.BottomSheetContainer, The49.Maui.BottomSheet", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}

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
