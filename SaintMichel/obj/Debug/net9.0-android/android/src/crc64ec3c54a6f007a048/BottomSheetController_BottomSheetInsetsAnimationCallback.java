package crc64ec3c54a6f007a048;


public class BottomSheetController_BottomSheetInsetsAnimationCallback
	extends androidx.core.view.WindowInsetsAnimationCompat.Callback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onStart:(Landroidx/core/view/WindowInsetsAnimationCompat;Landroidx/core/view/WindowInsetsAnimationCompat$BoundsCompat;)Landroidx/core/view/WindowInsetsAnimationCompat$BoundsCompat;:GetOnStart_Landroidx_core_view_WindowInsetsAnimationCompat_Landroidx_core_view_WindowInsetsAnimationCompat_BoundsCompat_Handler\n" +
			"n_onPrepare:(Landroidx/core/view/WindowInsetsAnimationCompat;)V:GetOnPrepare_Landroidx_core_view_WindowInsetsAnimationCompat_Handler\n" +
			"n_onProgress:(Landroidx/core/view/WindowInsetsCompat;Ljava/util/List;)Landroidx/core/view/WindowInsetsCompat;:GetOnProgress_Landroidx_core_view_WindowInsetsCompat_Ljava_util_List_Handler\n" +
			"";
		mono.android.Runtime.register ("The49.Maui.BottomSheet.BottomSheetController+BottomSheetInsetsAnimationCallback, The49.Maui.BottomSheet", BottomSheetController_BottomSheetInsetsAnimationCallback.class, __md_methods);
	}

	public BottomSheetController_BottomSheetInsetsAnimationCallback (int p0)
	{
		super (p0);
		if (getClass () == BottomSheetController_BottomSheetInsetsAnimationCallback.class) {
			mono.android.TypeManager.Activate ("The49.Maui.BottomSheet.BottomSheetController+BottomSheetInsetsAnimationCallback, The49.Maui.BottomSheet", "System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0 });
		}
	}

	public androidx.core.view.WindowInsetsAnimationCompat.BoundsCompat onStart (androidx.core.view.WindowInsetsAnimationCompat p0, androidx.core.view.WindowInsetsAnimationCompat.BoundsCompat p1)
	{
		return n_onStart (p0, p1);
	}

	private native androidx.core.view.WindowInsetsAnimationCompat.BoundsCompat n_onStart (androidx.core.view.WindowInsetsAnimationCompat p0, androidx.core.view.WindowInsetsAnimationCompat.BoundsCompat p1);

	public void onPrepare (androidx.core.view.WindowInsetsAnimationCompat p0)
	{
		n_onPrepare (p0);
	}

	private native void n_onPrepare (androidx.core.view.WindowInsetsAnimationCompat p0);

	public androidx.core.view.WindowInsetsCompat onProgress (androidx.core.view.WindowInsetsCompat p0, java.util.List p1)
	{
		return n_onProgress (p0, p1);
	}

	private native androidx.core.view.WindowInsetsCompat n_onProgress (androidx.core.view.WindowInsetsCompat p0, java.util.List p1);

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
