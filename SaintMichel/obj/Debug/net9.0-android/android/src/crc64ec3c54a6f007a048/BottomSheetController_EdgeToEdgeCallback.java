package crc64ec3c54a6f007a048;


public class BottomSheetController_EdgeToEdgeCallback
	extends com.google.android.material.bottomsheet.BottomSheetBehavior.BottomSheetCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onStateChanged:(Landroid/view/View;I)V:GetOnStateChanged_Landroid_view_View_IHandler\n" +
			"n_onSlide:(Landroid/view/View;F)V:GetOnSlide_Landroid_view_View_FHandler\n" +
			"";
		mono.android.Runtime.register ("The49.Maui.BottomSheet.BottomSheetController+EdgeToEdgeCallback, The49.Maui.BottomSheet", BottomSheetController_EdgeToEdgeCallback.class, __md_methods);
	}

	public BottomSheetController_EdgeToEdgeCallback ()
	{
		super ();
		if (getClass () == BottomSheetController_EdgeToEdgeCallback.class) {
			mono.android.TypeManager.Activate ("The49.Maui.BottomSheet.BottomSheetController+EdgeToEdgeCallback, The49.Maui.BottomSheet", "", this, new java.lang.Object[] {  });
		}
	}

	public void onStateChanged (android.view.View p0, int p1)
	{
		n_onStateChanged (p0, p1);
	}

	private native void n_onStateChanged (android.view.View p0, int p1);

	public void onSlide (android.view.View p0, float p1)
	{
		n_onSlide (p0, p1);
	}

	private native void n_onSlide (android.view.View p0, float p1);

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
