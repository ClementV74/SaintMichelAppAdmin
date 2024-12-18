package crc64ec3c54a6f007a048;


public class SheetRadiusDrawable
	extends android.graphics.drawable.GradientDrawable
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("The49.Maui.BottomSheet.SheetRadiusDrawable, The49.Maui.BottomSheet", SheetRadiusDrawable.class, __md_methods);
	}

	public SheetRadiusDrawable ()
	{
		super ();
		if (getClass () == SheetRadiusDrawable.class) {
			mono.android.TypeManager.Activate ("The49.Maui.BottomSheet.SheetRadiusDrawable, The49.Maui.BottomSheet", "", this, new java.lang.Object[] {  });
		}
	}

	public SheetRadiusDrawable (android.graphics.drawable.GradientDrawable.Orientation p0, int[] p1)
	{
		super (p0, p1);
		if (getClass () == SheetRadiusDrawable.class) {
			mono.android.TypeManager.Activate ("The49.Maui.BottomSheet.SheetRadiusDrawable, The49.Maui.BottomSheet", "Android.Graphics.Drawables.GradientDrawable+Orientation, Mono.Android:System.Int32[], System.Private.CoreLib", this, new java.lang.Object[] { p0, p1 });
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
