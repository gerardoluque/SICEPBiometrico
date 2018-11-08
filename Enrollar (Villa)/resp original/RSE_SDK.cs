using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace RealScanExtend
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]           //SDK Information
    public struct RSESDKInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] product;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] version;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] buildDate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public int[] reserved;
    };

    class RealScanExtendSDK
    {
        //
        // Device APIs
        //
        [DllImport("RSE_SDK.dll",
             CharSet = CharSet.Ansi,
             EntryPoint = "RSE_InitSDK")]
        public static extern int RSE_InitSDK();


        [DllImport("RSE_SDK.dll",
         CharSet = CharSet.Ansi,
         EntryPoint = "RSE_GetSDKInfo")]
        public static extern int RS_GetSDKInfo(ref RSESDKInfo sdkInfo);


        //Generar WSQ con la version extendida del SQK

        [DllImport("RSE_SDK.dll",
        CharSet = CharSet.Ansi,
        EntryPoint = "RSE_CompressWSQ")]
        public static extern int RSE_CompressWSQ(string filename_bmp, string comment, Double ratio, string filename_wsq);

        //[DllImport("RSE_SDK.dll",
        //CharSet = CharSet.Ansi,
        //EntryPoint = "RSE_CompressWSQBuffer")]
        //public static extern int RSE_CompressWSQBuffer(string imageFile, string comment, Double ratio, byte[] wsqData, int wsqDataLen ) ;


        
    }
}
