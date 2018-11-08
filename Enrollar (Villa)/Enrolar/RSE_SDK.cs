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

    public struct RSEType2Info 
    {  
        int recordLength; // read only
        int IDC;
        string systemMaker;
        string systemModel;
        string serialNo;
    };

    public struct RSEPoint
    {
	    int x;
	    int y;
    };

    public struct RSESlapInfo 
    {  
        int fingerType; //
        RSEPoint[] fingerPosition; // the position of the finger  
                                    // in the slap image  
        int imageQuality; // See RSE_GetQualityScore for details
        int rotation; // the rotation angle of the image. It specifies 
                      // the clockwise rotation in degrees.
        int[] reserved; 
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct RSEType1Info
    {
        public int recordLength; // read only

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] versionNumber;

        public int numOfRecord; // read only
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public int[] recordType; // read only
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public int[] recordIDC; // read only

        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] typeOfTranscation;
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public byte[] date;
        
        public int priority; // optional, 0 for none
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] destinationAgencyIdentifier;
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] originatingAgencyIdentifier;
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] transactionControlNumber;
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] transactionControlReferenceNumber; // optional 
        
        //public double nativeScanningResolution;
        
        //public double nominalTransmittingResolution;
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] domainName;	// optional
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] greenwichMeanTime; // optional
        
        public int characterSet;	// optional
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
        public static extern int RSE_CompressWSQ(string filename_bmp, string comment, float ratio, string filename_wsq);

        //[DllImport("RSE_SDK.dll",
        //CharSet = CharSet.Ansi,
        //EntryPoint = "RSE_CompressWSQBuffer")]
        //public static extern int RSE_CompressWSQBuffer(string imageFile, string comment, Double ratio, byte[] wsqData, int wsqDataLen ) ;

        [DllImport("RSE_SDK.dll",
        CharSet = CharSet.Ansi,
        EntryPoint = "RSE_MakeISOImageFile")]
        public static extern int RSE_MakeISOImageFile(string leftSlapImageFile, string rightSlapImageFile, string twoThumbImageFile, int numOfSingleFinger, int[] singleFingerPosition, string[] singleFingerImageFile, int numOfRollFinger, int[] rollFingerPosition, string[] rollFingerImageFile, bool wsqCompression, string outputFile);

 

        [DllImport("RSE_SDK.dll",
        CharSet = CharSet.Ansi,
        EntryPoint = "RSE_SaveRAW")]
        public static extern int RSE_SaveRAW( IntPtr pixelData, int imageWidth, int imageHeight, string filename );


        [DllImport("RSE_SDK.dll",
        CharSet = CharSet.Ansi,
        EntryPoint = "RSE_MakeAN2007File")]
        public static extern int RSE_MakeAN2007File(int DeviceID, string leftSlapImageFile, string rightSlapImageFile, string twoThumbImageFile, int numOfRollFinger, int[] rollFingerType, string[] rollFingerImageFile, string outputFile);
        //public static extern int RSE_MakeAN2007File(string leftSlapImageFile, string rightSlapImageFile, string twoThumbImageFile, int numOfRollFinger, int[] rollFingerType, string[] rollFingerImageFile, string outputFile);


        [DllImport("RSE_SDK.dll",
        CharSet = CharSet.Ansi,
        EntryPoint = "RSE_MakeAN2007FileEx")]
        public static extern int RSE_MakeAN2007FileEx( int deviceID, ref RSEType1Info info, string leftSlapImageFile, string rightSlapImageFile, string twoThumbImageFile, int numOfRollFinger, int[] rollFingerType, string[] rollFingerImageFile, string outputFile );


        [DllImport("RSE_SDK.dll",
        CharSet = CharSet.Ansi,
        EntryPoint = "RSE_SetType1Info")]
        public static extern int RSE_SetType1Info( string TOT, int priority, string DAI, string ORI, string TCN, string TCR, ref RSEType1Info info );


        [DllImport("RSE_SDK.dll",
        CharSet = CharSet.Ansi,
        EntryPoint = "RSE_FreeMemory")]
        public static extern int RSE_FreeMemory(string dataPtr);



        [DllImport("RSE_SDK.dll",
        CharSet = CharSet.Ansi,
        EntryPoint = "RSE_SegmentSlap")]
        public static extern int RSE_SegmentSlap( string slapImageFile, int slapType, ref int numOfFinger, ref RSESlapInfo slapInfo, bool extractImage, string fingerImageFile); 


        [DllImport("RSE_SDK.dll",
        CharSet = CharSet.Ansi,
        EntryPoint = "RSE_Make38104ImageFile")]
        public static extern int RSE_Make38104ImageFile( int CBEFFproductID, int compressionAlgo, int totalNumOfImages, int[] impressionTypes, int[] fingerPalmPositions, string[] fingerPalmFilenames, string outputFile ) ; 
//        RSE_Make38104ImageFile( int CBEFFproductID, int compressionAlgo, int totalNumOfImages, int* impressionTypes, int* fingerPalmPositions, char** fingerPalmFilenames, const char* outputFile ) 




        public const int RSE_ASCII_7bit =	0;
public const int RSE_ASCII_8bit	=1;
public const int RSE_UNICODE	=	2;
public const int RSE_UTF8		=3;

// Record types
public const int RSE_TYPE_1_RECORD	=1;
public const int RSE_TYPE_2_RECORD	=2;
public const int RSE_TYPE_4_RECORD	=4;
public const int RSE_TYPE_14_RECORD	=14;

// Image compression codes for ANSI/NIST
public const int RSE_IMG_COMP_NONE	=0;
public const int RSE_IMG_COMP_WSQ20	=1;
public const int RSE_IMG_COMP_JPEGB	=2;
public const int RSE_IMG_COMP_JPEGL	=3;
public const int RSE_IMG_COMP_JP2	=4;
public const int RSE_IMG_COMP_JP2L	=5;
public const int RSE_IMG_COMP_PNG	=6;

// Impression type
public const int RSE_IMP_LIVESCAN_PLAIN	=	0;
public const int RSE_IMP_LIVESCAN_ROLLED	=	1;
public const int RSE_IMP_NON_LIVESCAN_PLAIN		=			2 ;
public const int RSE_IMP_NON_LIVESCAN_ROLLED	=				3 ;
public const int RSE_IMP_LATENT					=			7 ;
public const int RSE_IMP_SWIPE					=			8 ;
public const int RSE_IMP_LIVESCAN_CONTACTLESS	=			9 ;
public const int RSE_IMP_LIVESCAN_OPTICAL_CONTACT_PLAIN	=20;
public const int RSE_IMP_LIVESCAN_OPTICAL_CONTACT_ROLLED=	21;
public const int RSE_IMP_OTHER		=		28;
public const int RSE_IMP_UNKNOWN	=			29;

//
// Finger position
//
public const int RSE_FGP_UNKNOWN	=		0;
public const int RSE_FGP_RIGHT_THUMB	=	1;
public const int RSE_FGP_RIGHT_INDEX	=	2;
public const int RSE_FGP_RIGHT_MIDDLE	=3;
public const int RSE_FGP_RIGHT_RING		=4;
public const int RSE_FGP_RIGHT_LITTLE	=5;
public const int RSE_FGP_LEFT_THUMB		=6;
public const int RSE_FGP_LEFT_INDEX		=7;
public const int RSE_FGP_LEFT_MIDDLE	=	8;
public const int RSE_FGP_LEFT_RING		=9;
public const int RSE_FGP_LEFT_LITTLE	=	10;
public const int RSE_FGP_PLAIN_RIGHT_THUMB	=11;
public const int RSE_FGP_PLAIN_LEFT_THUMB	=12;
public const int RSE_FGP_PLAIN_RIGHT_FOUR	=13;
public const int RSE_FGP_PLAIN_LEFT_FOUR	=	14;
public const int RSE_FGP_PLAIN_TWO_THUMBS=	15;
public const int RSE_FGP_EJI_OR_TIP		=	16;

// Image scanning resolution
public const int RSE_MINIMUM_RESOLUTION	=0;
public const int RSE_NATIVE_RESOLUTION	=1;

// Slap type
public const int RSE_SLAP_LEFT_FOUR		=1;
public const int RSE_SLAP_RIGHT_FOUR	=	2;
public const int RSE_SLAP_FOUR_FINGER=	3;
public const int RSE_SLAP_TWO_THUMB		=4;
public const int RSE_SLAP_TWO_FINGER	=	5;
public const int RSE_SLAP_ONE_FINGER	=	6;

// Image quality
public const int RSE_IMAGE_QUALITY_NOT_REPORTED		=	254 ;
public const int RSE_IMAGE_QUALITY_COMPUTATION_FAIL	=	255;




// Palm position 
public const int RSE_PMP_UNKNOWN					=	20; 
public const int RSE_PMP_RIGHT_FULL					=21 ;
public const int RSE_PMP_RIGHT_WRITER				=22 ;
public const int RSE_PMP_LEFT_FULL					=23 ;
public const int RSE_PMP_LEFT_WRITER			=		24 ;
public const int RSE_PMP_RIGHT_LOWER		=			25 ;
public const int RSE_PMP_RIGHT_UPPER		=			26 ;
public const int RSE_PMP_LEFT_LOWER			=		27 ;
public const int RSE_PMP_LEFT_UPPER			=		28 ;
public const int RSE_PMP_RIGHT_OTHER		=			29 ;
public const int RSE_PMP_LEFT_OTHER			=		30 ;
public const int RSE_PMP_RIGHT_INTERDIGITAL	=		31 ;
public const int RSE_PMP_RIGHT_THENAR		=		32 ;
public const int RSE_PMP_RIGHT_HYPOTHENAR	=		33 ;
public const int RSE_PMP_LEFT_INTERDIGITAL	=		34 ;
public const int RSE_PMP_LEFT_THENAR		=			35 ;
public const int RSE_PMP_LEFT_HYPOTHENAR	=			36 ;

// Template formats							
public const int RSE_TEMP_ORIGINAL			=		0; // Suprema's template format
public const int RSE_TEMP_ISO19794_2		=			1; // ISO 19794-2 template format



    }
}
