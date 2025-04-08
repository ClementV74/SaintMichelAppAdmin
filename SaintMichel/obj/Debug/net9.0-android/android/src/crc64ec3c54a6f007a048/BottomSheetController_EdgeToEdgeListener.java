package crc64ec3c54a6f007a048;


public class BottomSheetController_EdgeToEdgeListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		androidx.core.view.OnApplyWindowInsetsListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onApplyWindowInsets:(Landroid/view/View;Landroidx/core/view/WindowInsetsCompat;)Landroidx/core/view/WindowInsetsCompat;:GetOnApplyWindowInsets_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat_Handler:AndroidX.Core.View.IOnApplyWindowInsetsListenerInvoker, Xamarin.AndroidX.Core\n" +
			"";
		mono.android.Runtime.register ("The49.Maui.BottomSheet.BottomSheetController+EdgeToEdgeListener, The49.Maui.BottomSheet", BottomSheetController_EdgeToEdgeListener.class, __md_methods);
	}

	public BottomSheetController_EdgeToEdgeListener ()
	{
		super ();
		if (getClass () == BottomSheetController_EdgeToEdgeListener.class) {
			mono.android.TypeManager.Activate ("The49.Maui.BottomSheet.BottomSheetController+EdgeToEdgeListener, The49.Maui.BottomSheet", "", this, new java.lang.Object[] {  });
		}
	}

	public androidx.core.view.WindowInsetsCompat onApplyWindowInsets (android.view.View p0, androidx.core.view.WindowInsetsCompat p1)
	{
		return n_onApplyWindowInsets (p0, p1);
	}

	private native androidx.core.view.WindowInsetsCompat n_onApplyWindowInsets (android.view.View p0, androidx.core.view.WindowInsetsCompat p1);

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
