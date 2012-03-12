using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace CodeAssassin
{
    public class InternetSecurityManager
    {
        private const string CLSID_InternetSecurityManager = "7b8a2d94-0ac9-11d1-896c-00c04fb6bfc4";

        public static UrlZone MapUrlToZone(string url)
        {
            var ismType = Type.GetTypeFromCLSID(new Guid(CLSID_InternetSecurityManager));
            var ism = (IInternetSecurityManager)Activator.CreateInstance(ismType);

            uint zone;
            ism.MapUrlToZone(url, out zone, 0);

            return (UrlZone) zone;
        }
    }

    [ComImport]
    [Guid("79EAC9EE-BAF9-11CE-8C82-00AA004BA90B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInternetSecurityManager
    {

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetSecuritySite([In] IntPtr pSite);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetSecuritySite([Out] IntPtr pSite);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int MapUrlToZone([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl, [Out]out UInt32 pdwZone, UInt32 dwFlags);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetSecurityId([MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
                  [MarshalAs(UnmanagedType.LPArray)] byte[] pbSecurityId,
                  ref UInt32 pcbSecurityId, uint dwReserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ProcessUrlAction([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
                     UInt32 dwAction, out byte pPolicy, UInt32 cbPolicy,
                     byte pContext, UInt32 cbContext, UInt32 dwFlags,
                     UInt32 dwReserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int QueryCustomPolicy([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
                  ref Guid guidKey, ref byte ppPolicy, ref UInt32 pcbPolicy,
                  ref byte pContext, UInt32 cbContext, UInt32 dwReserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetZoneMapping(UInt32 dwZone,
                   [In, MarshalAs(UnmanagedType.LPWStr)] string lpszPattern,
                   UInt32 dwFlags);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetZoneMappings(UInt32 dwZone, out IEnumString ppenumString,
                    UInt32 dwFlags);
    }

    
}
