; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [334 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [662 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 68
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 67
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 108
	i32 29184114, ; 3: Syncfusion.Maui.Toolkit.resources.dll => 0x1bd5072 => 194
	i32 32687329, ; 4: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 251
	i32 34715100, ; 5: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 288
	i32 34839235, ; 6: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 48
	i32 39485524, ; 7: System.Net.WebSockets.dll => 0x25a8054 => 80
	i32 42639949, ; 8: System.Threading.Thread => 0x28aa24d => 145
	i32 66541672, ; 9: System.Diagnostics.StackTrace => 0x3f75868 => 30
	i32 67008169, ; 10: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 329
	i32 68219467, ; 11: System.Security.Cryptography.Primitives => 0x410f24b => 124
	i32 72070932, ; 12: Microsoft.Maui.Graphics.dll => 0x44bb714 => 189
	i32 82292897, ; 13: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 102
	i32 101534019, ; 14: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 270
	i32 117431740, ; 15: System.Runtime.InteropServices => 0x6ffddbc => 107
	i32 120558881, ; 16: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 270
	i32 122350210, ; 17: System.Threading.Channels.dll => 0x74aea82 => 139
	i32 134690465, ; 18: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 292
	i32 142721839, ; 19: System.Net.WebHeaderCollection => 0x881c32f => 77
	i32 149972175, ; 20: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 124
	i32 159306688, ; 21: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 22: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 225
	i32 172961045, ; 23: Syncfusion.Maui.Core.dll => 0xa4f2d15 => 192
	i32 176265551, ; 24: System.ServiceProcess => 0xa81994f => 132
	i32 182336117, ; 25: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 272
	i32 184328833, ; 26: System.ValueTuple.dll => 0xafca281 => 151
	i32 195452805, ; 27: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 326
	i32 199333315, ; 28: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 327
	i32 205061960, ; 29: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 30: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 223
	i32 220171995, ; 31: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 230216969, ; 32: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 245
	i32 230752869, ; 33: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 34: System.Linq.Parallel => 0xdcb05c4 => 59
	i32 231814094, ; 35: System.Globalization => 0xdd133ce => 42
	i32 246610117, ; 36: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 91
	i32 259487786, ; 37: Syncfusion.Maui.Charts => 0xf77782a => 191
	i32 261689757, ; 38: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 228
	i32 266337479, ; 39: Xamarin.Google.Guava.FailureAccess.dll => 0xfdffcc7 => 287
	i32 276479776, ; 40: System.Threading.Timer.dll => 0x107abf20 => 147
	i32 278686392, ; 41: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 247
	i32 280482487, ; 42: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 244
	i32 280992041, ; 43: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 298
	i32 291076382, ; 44: System.IO.Pipes.AccessControl.dll => 0x1159791e => 54
	i32 293579439, ; 45: ExoPlayer.Dash.dll => 0x117faaaf => 199
	i32 298918909, ; 46: System.Net.Ping.dll => 0x11d123fd => 69
	i32 317674968, ; 47: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 326
	i32 318968648, ; 48: Xamarin.AndroidX.Activity.dll => 0x13031348 => 214
	i32 321597661, ; 49: System.Numerics => 0x132b30dd => 83
	i32 336156722, ; 50: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 311
	i32 342366114, ; 51: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 246
	i32 356389973, ; 52: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 310
	i32 360082299, ; 53: System.ServiceModel.Web => 0x15766b7b => 131
	i32 367780167, ; 54: System.IO.Pipes => 0x15ebe147 => 55
	i32 374914964, ; 55: System.Transactions.Local => 0x1658bf94 => 149
	i32 375677976, ; 56: System.Net.ServicePoint.dll => 0x16646418 => 74
	i32 379916513, ; 57: System.Threading.Thread.dll => 0x16a510e1 => 145
	i32 385762202, ; 58: System.Memory.dll => 0x16fe439a => 62
	i32 392610295, ; 59: System.Threading.ThreadPool.dll => 0x1766c1f7 => 146
	i32 395744057, ; 60: _Microsoft.Android.Resource.Designer => 0x17969339 => 330
	i32 403441872, ; 61: WindowsBase => 0x180c08d0 => 165
	i32 435591531, ; 62: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 322
	i32 441335492, ; 63: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 229
	i32 442565967, ; 64: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 65: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 242
	i32 451504562, ; 66: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 125
	i32 452127346, ; 67: ExoPlayer.Database.dll => 0x1af2ea72 => 200
	i32 456227837, ; 68: System.Web.HttpUtility.dll => 0x1b317bfd => 152
	i32 459347974, ; 69: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 113
	i32 465846621, ; 70: mscorlib => 0x1bc4415d => 166
	i32 469710990, ; 71: System.dll => 0x1bff388e => 164
	i32 476646585, ; 72: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 244
	i32 486930444, ; 73: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 257
	i32 498788369, ; 74: System.ObjectModel => 0x1dbae811 => 84
	i32 500358224, ; 75: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 309
	i32 503918385, ; 76: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 303
	i32 513247710, ; 77: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 183
	i32 526420162, ; 78: System.Transactions.dll => 0x1f6088c2 => 150
	i32 527452488, ; 79: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 292
	i32 530272170, ; 80: System.Linq.Queryable => 0x1f9b4faa => 60
	i32 539058512, ; 81: Microsoft.Extensions.Logging => 0x20216150 => 179
	i32 540030774, ; 82: System.IO.FileSystem.dll => 0x20303736 => 51
	i32 545304856, ; 83: System.Runtime.Extensions => 0x2080b118 => 103
	i32 546455878, ; 84: System.Runtime.Serialization.Xml => 0x20924146 => 114
	i32 549171840, ; 85: System.Globalization.Calendars => 0x20bbb280 => 40
	i32 557405415, ; 86: Jsr305Binding => 0x213954e7 => 283
	i32 569601784, ; 87: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 281
	i32 577335427, ; 88: System.Security.Cryptography.Cng => 0x22697083 => 120
	i32 592146354, ; 89: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 317
	i32 601371474, ; 90: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 605376203, ; 91: System.IO.Compression.FileSystem => 0x24154ecb => 44
	i32 613668793, ; 92: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 119
	i32 626887733, ; 93: ExoPlayer.Container => 0x255d8c35 => 197
	i32 627609679, ; 94: Xamarin.AndroidX.CustomView => 0x2568904f => 234
	i32 627931235, ; 95: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 315
	i32 639843206, ; 96: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 240
	i32 643868501, ; 97: System.Net => 0x2660a755 => 81
	i32 662205335, ; 98: System.Text.Encodings.Web.dll => 0x27787397 => 136
	i32 663517072, ; 99: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 277
	i32 666292255, ; 100: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 221
	i32 672442732, ; 101: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 102: System.Net.Security => 0x28bdabca => 73
	i32 688181140, ; 103: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 297
	i32 690569205, ; 104: System.Xml.Linq.dll => 0x29293ff5 => 155
	i32 691348768, ; 105: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 294
	i32 693804605, ; 106: System.Windows => 0x295a9e3d => 154
	i32 699345723, ; 107: System.Reflection.Emit => 0x29af2b3b => 92
	i32 700284507, ; 108: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 289
	i32 700358131, ; 109: System.IO.Compression.ZipFile => 0x29be9df3 => 45
	i32 706645707, ; 110: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 312
	i32 709557578, ; 111: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 300
	i32 720511267, ; 112: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 293
	i32 722857257, ; 113: System.Runtime.Loader.dll => 0x2b15ed29 => 109
	i32 735137430, ; 114: System.Security.SecureString.dll => 0x2bd14e96 => 129
	i32 752232764, ; 115: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 116: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 211
	i32 759454413, ; 117: System.Net.Requests => 0x2d445acd => 72
	i32 762598435, ; 118: System.IO.Pipes.dll => 0x2d745423 => 55
	i32 775507847, ; 119: System.IO.Compression => 0x2e394f87 => 46
	i32 777317022, ; 120: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 321
	i32 789151979, ; 121: Microsoft.Extensions.Options => 0x2f0980eb => 182
	i32 790371945, ; 122: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 235
	i32 804715423, ; 123: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 124: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 249
	i32 812693636, ; 125: ExoPlayer.Dash => 0x3070b884 => 199
	i32 823281589, ; 126: System.Private.Uri.dll => 0x311247b5 => 86
	i32 830298997, ; 127: System.IO.Compression.Brotli => 0x317d5b75 => 43
	i32 832635846, ; 128: System.Xml.XPath.dll => 0x31a103c6 => 160
	i32 834051424, ; 129: System.Net.Quic => 0x31b69d60 => 71
	i32 843511501, ; 130: Xamarin.AndroidX.Print => 0x3246f6cd => 263
	i32 873119928, ; 131: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 132: System.Globalization.dll => 0x34505120 => 42
	i32 878954865, ; 133: System.Net.Http.Json => 0x3463c971 => 63
	i32 904024072, ; 134: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 911108515, ; 135: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 53
	i32 915551335, ; 136: ExoPlayer.Ext.MediaSession => 0x36923467 => 205
	i32 926902833, ; 137: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 324
	i32 928116545, ; 138: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 288
	i32 939704684, ; 139: ExoPlayer.Extractor => 0x3802c16c => 203
	i32 952186615, ; 140: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 105
	i32 956575887, ; 141: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 293
	i32 966729478, ; 142: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 284
	i32 967690846, ; 143: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 246
	i32 975236339, ; 144: System.Diagnostics.Tracing => 0x3a20ecf3 => 34
	i32 975874589, ; 145: System.Xml.XDocument => 0x3a2aaa1d => 158
	i32 986514023, ; 146: System.Private.DataContractSerialization.dll => 0x3acd0267 => 85
	i32 987214855, ; 147: System.Diagnostics.Tools => 0x3ad7b407 => 32
	i32 992768348, ; 148: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 149: System.IO.FileSystem => 0x3b45fb35 => 51
	i32 1001831731, ; 150: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 56
	i32 1012816738, ; 151: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 267
	i32 1019214401, ; 152: System.Drawing => 0x3cbffa41 => 36
	i32 1028013380, ; 153: ExoPlayer.UI.dll => 0x3d463d44 => 209
	i32 1028951442, ; 154: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 178
	i32 1029334545, ; 155: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 299
	i32 1031528504, ; 156: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 285
	i32 1035644815, ; 157: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 219
	i32 1036536393, ; 158: System.Drawing.Primitives.dll => 0x3dc84a49 => 35
	i32 1044663988, ; 159: System.Linq.Expressions.dll => 0x3e444eb4 => 58
	i32 1052210849, ; 160: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 253
	i32 1067306892, ; 161: GoogleGson => 0x3f9dcf8c => 174
	i32 1082857460, ; 162: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 163: Xamarin.Kotlin.StdLib => 0x409e66d8 => 290
	i32 1098259244, ; 164: System => 0x41761b2c => 164
	i32 1118262833, ; 165: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 312
	i32 1121599056, ; 166: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 252
	i32 1127624469, ; 167: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 181
	i32 1149092582, ; 168: Xamarin.AndroidX.Window => 0x447dc2e6 => 280
	i32 1151313727, ; 169: ExoPlayer.Rtsp => 0x449fa73f => 206
	i32 1168523401, ; 170: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 318
	i32 1170634674, ; 171: System.Web.dll => 0x45c677b2 => 153
	i32 1175144683, ; 172: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 276
	i32 1178241025, ; 173: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 261
	i32 1203215381, ; 174: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 316
	i32 1204270330, ; 175: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 221
	i32 1208641965, ; 176: System.Diagnostics.Process => 0x480a69ad => 29
	i32 1219128291, ; 177: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1234928153, ; 178: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 314
	i32 1243150071, ; 179: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 281
	i32 1253011324, ; 180: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1260983243, ; 181: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 298
	i32 1263886435, ; 182: Xamarin.Google.Guava.dll => 0x4b556063 => 286
	i32 1264511973, ; 183: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 271
	i32 1267360935, ; 184: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 275
	i32 1273260888, ; 185: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 226
	i32 1275534314, ; 186: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 294
	i32 1278448581, ; 187: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 218
	i32 1293217323, ; 188: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 237
	i32 1309188875, ; 189: System.Private.DataContractSerialization => 0x4e08a30b => 85
	i32 1309209905, ; 190: ExoPlayer.DataSource => 0x4e08f531 => 201
	i32 1322716291, ; 191: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 280
	i32 1324164729, ; 192: System.Linq => 0x4eed2679 => 61
	i32 1335329327, ; 193: System.Runtime.Serialization.Json.dll => 0x4f97822f => 112
	i32 1364015309, ; 194: System.IO => 0x514d38cd => 57
	i32 1373134921, ; 195: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 328
	i32 1376866003, ; 196: Xamarin.AndroidX.SavedState => 0x52114ed3 => 267
	i32 1379779777, ; 197: System.Resources.ResourceManager => 0x523dc4c1 => 99
	i32 1395857551, ; 198: Xamarin.AndroidX.Media.dll => 0x5333188f => 258
	i32 1402170036, ; 199: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 200: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 230
	i32 1406299041, ; 201: Xamarin.Google.Guava.FailureAccess => 0x53d26ba1 => 287
	i32 1408764838, ; 202: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 111
	i32 1411638395, ; 203: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 101
	i32 1422545099, ; 204: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 102
	i32 1430672901, ; 205: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 296
	i32 1434145427, ; 206: System.Runtime.Handles => 0x557b5293 => 104
	i32 1435222561, ; 207: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 284
	i32 1439761251, ; 208: System.Net.Quic.dll => 0x55d10363 => 71
	i32 1452070440, ; 209: System.Formats.Asn1.dll => 0x568cd628 => 38
	i32 1453312822, ; 210: System.Diagnostics.Tools.dll => 0x569fcb36 => 32
	i32 1453641697, ; 211: Syncfusion.Maui.Toolkit.dll => 0x56a4cfe1 => 193
	i32 1457743152, ; 212: System.Runtime.Extensions.dll => 0x56e36530 => 103
	i32 1458022317, ; 213: System.Net.Security.dll => 0x56e7a7ad => 73
	i32 1461004990, ; 214: es\Microsoft.Maui.Controls.resources => 0x57152abe => 302
	i32 1461234159, ; 215: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 216: System.Security.Cryptography.OpenSsl => 0x57201017 => 123
	i32 1462112819, ; 217: System.IO.Compression.dll => 0x57261233 => 46
	i32 1469204771, ; 218: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 220
	i32 1470490898, ; 219: Microsoft.Extensions.Primitives => 0x57a5e912 => 183
	i32 1479771757, ; 220: System.Collections.Immutable => 0x5833866d => 9
	i32 1480156764, ; 221: ExoPlayer.DataSource.dll => 0x5839665c => 201
	i32 1480492111, ; 222: System.IO.Compression.Brotli.dll => 0x583e844f => 43
	i32 1487239319, ; 223: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1490025113, ; 224: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 268
	i32 1493001747, ; 225: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 306
	i32 1514721132, ; 226: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 301
	i32 1536373174, ; 227: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 31
	i32 1543031311, ; 228: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 138
	i32 1543355203, ; 229: System.Reflection.Emit.dll => 0x5bfdbb43 => 92
	i32 1550322496, ; 230: System.Reflection.Extensions.dll => 0x5c680b40 => 93
	i32 1551623176, ; 231: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 321
	i32 1565862583, ; 232: System.IO.FileSystem.Primitives => 0x5d552ab7 => 49
	i32 1566207040, ; 233: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 141
	i32 1573704789, ; 234: System.Runtime.Serialization.Json => 0x5dccd455 => 112
	i32 1577960976, ; 235: CachaPlagas => 0x5e0dc610 => 0
	i32 1580037396, ; 236: System.Threading.Overlapped => 0x5e2d7514 => 140
	i32 1582372066, ; 237: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 236
	i32 1592978981, ; 238: System.Runtime.Serialization.dll => 0x5ef2ee25 => 115
	i32 1597949149, ; 239: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 285
	i32 1601112923, ; 240: System.Xml.Serialization => 0x5f6f0b5b => 157
	i32 1604827217, ; 241: System.Net.WebClient => 0x5fa7b851 => 76
	i32 1618516317, ; 242: System.Net.WebSockets.Client.dll => 0x6078995d => 79
	i32 1622152042, ; 243: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 256
	i32 1622358360, ; 244: System.Dynamic.Runtime => 0x60b33958 => 37
	i32 1624863272, ; 245: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 279
	i32 1635184631, ; 246: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 240
	i32 1636350590, ; 247: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 233
	i32 1638652436, ; 248: CommunityToolkit.Maui.MediaElement => 0x61abda14 => 173
	i32 1639515021, ; 249: System.Net.Http.dll => 0x61b9038d => 64
	i32 1639986890, ; 250: System.Text.RegularExpressions => 0x61c036ca => 138
	i32 1641389582, ; 251: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1657153582, ; 252: System.Runtime => 0x62c6282e => 116
	i32 1658241508, ; 253: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 273
	i32 1658251792, ; 254: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 282
	i32 1670060433, ; 255: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 228
	i32 1675553242, ; 256: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 48
	i32 1677501392, ; 257: System.Net.Primitives.dll => 0x63fca3d0 => 70
	i32 1678508291, ; 258: System.Net.WebSockets => 0x640c0103 => 80
	i32 1679769178, ; 259: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1691477237, ; 260: System.Reflection.Metadata => 0x64d1e4f5 => 94
	i32 1696967625, ; 261: System.Security.Cryptography.Csp => 0x6525abc9 => 121
	i32 1698840827, ; 262: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 291
	i32 1700397376, ; 263: ExoPlayer.Transformer => 0x655a0140 => 208
	i32 1701541528, ; 264: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1720223769, ; 265: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 249
	i32 1726116996, ; 266: System.Reflection.dll => 0x66e27484 => 97
	i32 1728033016, ; 267: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 28
	i32 1729485958, ; 268: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 224
	i32 1736233607, ; 269: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 319
	i32 1743415430, ; 270: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 297
	i32 1744735666, ; 271: System.Transactions.Local.dll => 0x67fe8db2 => 149
	i32 1746316138, ; 272: Mono.Android.Export => 0x6816ab6a => 169
	i32 1750313021, ; 273: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 274: System.Resources.Reader.dll => 0x68cc9d1e => 98
	i32 1763938596, ; 275: System.Diagnostics.TraceSource.dll => 0x69239124 => 33
	i32 1765620304, ; 276: ExoPlayer.Core => 0x693d3a50 => 198
	i32 1765942094, ; 277: System.Reflection.Extensions => 0x6942234e => 93
	i32 1766324549, ; 278: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 272
	i32 1770582343, ; 279: Microsoft.Extensions.Logging.dll => 0x6988f147 => 179
	i32 1773867521, ; 280: CachaPlagas.dll => 0x69bb1201 => 0
	i32 1776026572, ; 281: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 282: System.Globalization.Extensions.dll => 0x69ec0683 => 41
	i32 1780572499, ; 283: Mono.Android.Runtime.dll => 0x6a216153 => 170
	i32 1782862114, ; 284: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 313
	i32 1788241197, ; 285: Xamarin.AndroidX.Fragment => 0x6a96652d => 242
	i32 1793755602, ; 286: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 305
	i32 1808609942, ; 287: Xamarin.AndroidX.Loader => 0x6bcd3296 => 256
	i32 1813058853, ; 288: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 290
	i32 1813201214, ; 289: Xamarin.Google.Android.Material => 0x6c13413e => 282
	i32 1818569960, ; 290: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 262
	i32 1818787751, ; 291: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1824175904, ; 292: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 293: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 111
	i32 1828688058, ; 294: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 180
	i32 1842015223, ; 295: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 325
	i32 1847515442, ; 296: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 211
	i32 1853025655, ; 297: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 322
	i32 1858542181, ; 298: System.Linq.Expressions => 0x6ec71a65 => 58
	i32 1870277092, ; 299: System.Reflection.Primitives => 0x6f7a29e4 => 95
	i32 1875935024, ; 300: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 304
	i32 1879696579, ; 301: System.Formats.Tar.dll => 0x7009e4c3 => 39
	i32 1885316902, ; 302: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 222
	i32 1888955245, ; 303: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 304: System.Reflection.Metadata.dll => 0x70a66bdd => 94
	i32 1898237753, ; 305: System.Reflection.DispatchProxy => 0x7124cf39 => 89
	i32 1900610850, ; 306: System.Resources.ResourceManager.dll => 0x71490522 => 99
	i32 1910275211, ; 307: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1926145099, ; 308: ExoPlayer.Container.dll => 0x72cea44b => 197
	i32 1939592360, ; 309: System.Private.Xml.Linq => 0x739bd4a8 => 87
	i32 1956758971, ; 310: System.Resources.Writer => 0x74a1c5bb => 100
	i32 1961813231, ; 311: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 269
	i32 1968388702, ; 312: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 175
	i32 1983156543, ; 313: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 291
	i32 1984283898, ; 314: ExoPlayer.Ext.MediaSession.dll => 0x7645c4fa => 205
	i32 1985761444, ; 315: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 213
	i32 2003115576, ; 316: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 301
	i32 2011961780, ; 317: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2019465201, ; 318: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 253
	i32 2025202353, ; 319: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 296
	i32 2031763787, ; 320: Xamarin.Android.Glide => 0x791a414b => 210
	i32 2045470958, ; 321: System.Private.Xml => 0x79eb68ee => 88
	i32 2055257422, ; 322: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 248
	i32 2060060697, ; 323: System.Windows.dll => 0x7aca0819 => 154
	i32 2066184531, ; 324: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 300
	i32 2070888862, ; 325: System.Diagnostics.TraceSource => 0x7b6f419e => 33
	i32 2079903147, ; 326: System.Runtime.dll => 0x7bf8cdab => 116
	i32 2090596640, ; 327: System.Numerics.Vectors => 0x7c9bf920 => 82
	i32 2106312818, ; 328: ExoPlayer.Decoder => 0x7d8bc872 => 202
	i32 2113912252, ; 329: ExoPlayer.UI => 0x7dffbdbc => 209
	i32 2127167465, ; 330: System.Console => 0x7ec9ffe9 => 20
	i32 2142473426, ; 331: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 332: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 162
	i32 2146852085, ; 333: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2159891885, ; 334: Microsoft.Maui => 0x80bd55ad => 187
	i32 2169148018, ; 335: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 308
	i32 2181898931, ; 336: Microsoft.Extensions.Options.dll => 0x820d22b3 => 182
	i32 2192057212, ; 337: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 180
	i32 2193016926, ; 338: System.ObjectModel.dll => 0x82b6c85e => 84
	i32 2201107256, ; 339: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 295
	i32 2201231467, ; 340: System.Net.Http => 0x8334206b => 64
	i32 2202964214, ; 341: ExoPlayer.dll => 0x834e90f6 => 195
	i32 2207618523, ; 342: it\Microsoft.Maui.Controls.resources => 0x839595db => 310
	i32 2217644978, ; 343: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 276
	i32 2222056684, ; 344: System.Threading.Tasks.Parallel => 0x8471e4ec => 143
	i32 2239138732, ; 345: ExoPlayer.SmoothStreaming => 0x85768bac => 207
	i32 2244775296, ; 346: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 257
	i32 2252106437, ; 347: System.Xml.Serialization.dll => 0x863c6ac5 => 157
	i32 2256313426, ; 348: System.Globalization.Extensions => 0x867c9c52 => 41
	i32 2265110946, ; 349: System.Security.AccessControl.dll => 0x8702d9a2 => 117
	i32 2266799131, ; 350: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 176
	i32 2267999099, ; 351: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 212
	i32 2270573516, ; 352: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 304
	i32 2279755925, ; 353: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 265
	i32 2293034957, ; 354: System.ServiceModel.Web.dll => 0x88acefcd => 131
	i32 2295906218, ; 355: System.Net.Sockets => 0x88d8bfaa => 75
	i32 2298471582, ; 356: System.Net.Mail => 0x88ffe49e => 66
	i32 2303942373, ; 357: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 314
	i32 2305521784, ; 358: System.Private.CoreLib.dll => 0x896b7878 => 172
	i32 2315684594, ; 359: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 216
	i32 2320631194, ; 360: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 143
	i32 2340441535, ; 361: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 106
	i32 2344264397, ; 362: System.ValueTuple => 0x8bbaa2cd => 151
	i32 2353062107, ; 363: System.Net.Primitives => 0x8c40e0db => 70
	i32 2354730003, ; 364: Syncfusion.Licensing => 0x8c5a5413 => 190
	i32 2368005991, ; 365: System.Xml.ReaderWriter.dll => 0x8d24e767 => 156
	i32 2371007202, ; 366: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 175
	i32 2378619854, ; 367: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 121
	i32 2383496789, ; 368: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2395872292, ; 369: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 309
	i32 2401565422, ; 370: System.Web.HttpUtility => 0x8f24faee => 152
	i32 2403452196, ; 371: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 239
	i32 2421380589, ; 372: System.Threading.Tasks.Dataflow => 0x905355ed => 141
	i32 2423080555, ; 373: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 226
	i32 2427813419, ; 374: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 306
	i32 2435356389, ; 375: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 376: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2437192331, ; 377: CommunityToolkit.Maui.MediaElement.dll => 0x91449a8b => 173
	i32 2454642406, ; 378: System.Text.Encoding.dll => 0x924edee6 => 135
	i32 2458678730, ; 379: System.Net.Sockets.dll => 0x928c75ca => 75
	i32 2459001652, ; 380: System.Linq.Parallel.dll => 0x92916334 => 59
	i32 2465532216, ; 381: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 229
	i32 2471841756, ; 382: netstandard.dll => 0x93554fdc => 167
	i32 2475788418, ; 383: Java.Interop.dll => 0x93918882 => 168
	i32 2476233210, ; 384: ExoPlayer => 0x939851fa => 195
	i32 2480646305, ; 385: Microsoft.Maui.Controls => 0x93dba8a1 => 185
	i32 2483903535, ; 386: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 387: System.Net.ServicePoint => 0x94147f61 => 74
	i32 2490993605, ; 388: System.AppContext.dll => 0x94798bc5 => 6
	i32 2501346920, ; 389: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2505896520, ; 390: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 251
	i32 2515854816, ; 391: ExoPlayer.Common => 0x95f4e5e0 => 196
	i32 2522472828, ; 392: Xamarin.Android.Glide.dll => 0x9659e17c => 210
	i32 2538310050, ; 393: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 91
	i32 2550873716, ; 394: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 307
	i32 2562349572, ; 395: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 396: System.Text.Encodings.Web => 0x9930ee42 => 136
	i32 2581783588, ; 397: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 252
	i32 2581819634, ; 398: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 275
	i32 2585220780, ; 399: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2585805581, ; 400: System.Net.Ping => 0x9a20430d => 69
	i32 2589602615, ; 401: System.Threading.ThreadPool => 0x9a5a3337 => 146
	i32 2593496499, ; 402: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 316
	i32 2605712449, ; 403: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 295
	i32 2615233544, ; 404: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 243
	i32 2616218305, ; 405: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 181
	i32 2617129537, ; 406: System.Private.Xml.dll => 0x9bfe3a41 => 88
	i32 2618712057, ; 407: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 96
	i32 2620871830, ; 408: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 233
	i32 2624644809, ; 409: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 238
	i32 2626028643, ; 410: ExoPlayer.Rtsp.dll => 0x9c860463 => 206
	i32 2626831493, ; 411: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 311
	i32 2627185994, ; 412: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 31
	i32 2629843544, ; 413: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 45
	i32 2633051222, ; 414: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 247
	i32 2663391936, ; 415: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 212
	i32 2663698177, ; 416: System.Runtime.Loader => 0x9ec4cf01 => 109
	i32 2664396074, ; 417: System.Xml.XDocument.dll => 0x9ecf752a => 158
	i32 2665622720, ; 418: System.Drawing.Primitives => 0x9ee22cc0 => 35
	i32 2676780864, ; 419: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 420: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 114
	i32 2693849962, ; 421: System.IO.dll => 0xa090e36a => 57
	i32 2701096212, ; 422: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 273
	i32 2713040075, ; 423: ExoPlayer.Hls => 0xa1b5b4cb => 204
	i32 2715334215, ; 424: System.Threading.Tasks.dll => 0xa1d8b647 => 144
	i32 2717744543, ; 425: System.Security.Claims => 0xa1fd7d9f => 118
	i32 2719963679, ; 426: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 120
	i32 2724373263, ; 427: System.Runtime.Numerics.dll => 0xa262a30f => 110
	i32 2732626843, ; 428: Xamarin.AndroidX.Activity => 0xa2e0939b => 214
	i32 2735172069, ; 429: System.Threading.Channels => 0xa30769e5 => 139
	i32 2737747696, ; 430: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 220
	i32 2740948882, ; 431: System.IO.Pipes.AccessControl => 0xa35f8f92 => 54
	i32 2748088231, ; 432: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 105
	i32 2752995522, ; 433: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 317
	i32 2758225723, ; 434: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 186
	i32 2764765095, ; 435: Microsoft.Maui.dll => 0xa4caf7a7 => 187
	i32 2765824710, ; 436: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 133
	i32 2770495804, ; 437: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 289
	i32 2778768386, ; 438: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 278
	i32 2779977773, ; 439: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 266
	i32 2785988530, ; 440: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 323
	i32 2788224221, ; 441: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 243
	i32 2796087574, ; 442: ExoPlayer.Extractor.dll => 0xa6a8e916 => 203
	i32 2801831435, ; 443: Microsoft.Maui.Graphics => 0xa7008e0b => 189
	i32 2803228030, ; 444: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 159
	i32 2806116107, ; 445: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 302
	i32 2810250172, ; 446: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 230
	i32 2819470561, ; 447: System.Xml.dll => 0xa80db4e1 => 163
	i32 2821205001, ; 448: System.ServiceProcess.dll => 0xa8282c09 => 132
	i32 2821294376, ; 449: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 266
	i32 2824502124, ; 450: System.Xml.XmlDocument => 0xa85a7b6c => 161
	i32 2831556043, ; 451: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 315
	i32 2838993487, ; 452: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 254
	i32 2849599387, ; 453: System.Threading.Overlapped.dll => 0xa9d96f9b => 140
	i32 2853208004, ; 454: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 278
	i32 2855708567, ; 455: Xamarin.AndroidX.Transition => 0xaa36a797 => 274
	i32 2861098320, ; 456: Mono.Android.Export.dll => 0xaa88e550 => 169
	i32 2861189240, ; 457: Microsoft.Maui.Essentials => 0xaa8a4878 => 188
	i32 2868557005, ; 458: Syncfusion.Licensing.dll => 0xaafab4cd => 190
	i32 2870099610, ; 459: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 215
	i32 2871867422, ; 460: Syncfusion.Maui.Toolkit => 0xab2d381e => 193
	i32 2875164099, ; 461: Jsr305Binding.dll => 0xab5f85c3 => 283
	i32 2875220617, ; 462: System.Globalization.Calendars.dll => 0xab606289 => 40
	i32 2884993177, ; 463: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 241
	i32 2887636118, ; 464: System.Net.dll => 0xac1dd496 => 81
	i32 2899753641, ; 465: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 56
	i32 2900621748, ; 466: System.Dynamic.Runtime.dll => 0xace3f9b4 => 37
	i32 2901442782, ; 467: System.Reflection => 0xacf080de => 97
	i32 2905242038, ; 468: mscorlib.dll => 0xad2a79b6 => 166
	i32 2909740682, ; 469: System.Private.CoreLib => 0xad6f1e8a => 172
	i32 2916838712, ; 470: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 279
	i32 2919462931, ; 471: System.Numerics.Vectors.dll => 0xae037813 => 82
	i32 2921128767, ; 472: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 217
	i32 2936416060, ; 473: System.Resources.Reader => 0xaf06273c => 98
	i32 2940926066, ; 474: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 30
	i32 2942453041, ; 475: System.Xml.XPath.XDocument => 0xaf624531 => 159
	i32 2959614098, ; 476: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2960379616, ; 477: Xamarin.Google.Guava => 0xb073cee0 => 286
	i32 2968338931, ; 478: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2972252294, ; 479: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 119
	i32 2978675010, ; 480: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 237
	i32 2987532451, ; 481: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 269
	i32 2996846495, ; 482: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 250
	i32 3016983068, ; 483: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 271
	i32 3023353419, ; 484: WindowsBase.dll => 0xb434b64b => 165
	i32 3024354802, ; 485: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 245
	i32 3027462113, ; 486: ExoPlayer.Common.dll => 0xb47367e1 => 196
	i32 3038032645, ; 487: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 330
	i32 3056245963, ; 488: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 268
	i32 3057625584, ; 489: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 259
	i32 3059408633, ; 490: Mono.Android.Runtime => 0xb65adef9 => 170
	i32 3059793426, ; 491: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3075834255, ; 492: System.Threading.Tasks => 0xb755818f => 144
	i32 3077302341, ; 493: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 308
	i32 3090735792, ; 494: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 125
	i32 3099732863, ; 495: System.Security.Claims.dll => 0xb8c22b7f => 118
	i32 3103600923, ; 496: System.Formats.Asn1 => 0xb8fd311b => 38
	i32 3111772706, ; 497: System.Runtime.Serialization => 0xb979e222 => 115
	i32 3121463068, ; 498: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 47
	i32 3124832203, ; 499: System.Threading.Tasks.Extensions => 0xba4127cb => 142
	i32 3132293585, ; 500: System.Security.AccessControl => 0xbab301d1 => 117
	i32 3144327419, ; 501: ExoPlayer.Hls.dll => 0xbb6aa0fb => 204
	i32 3147165239, ; 502: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 34
	i32 3147228406, ; 503: Syncfusion.Maui.Core => 0xbb96e4f6 => 192
	i32 3148237826, ; 504: GoogleGson.dll => 0xbba64c02 => 174
	i32 3159123045, ; 505: System.Reflection.Primitives.dll => 0xbc4c6465 => 95
	i32 3160747431, ; 506: System.IO.MemoryMappedFiles => 0xbc652da7 => 53
	i32 3178803400, ; 507: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 260
	i32 3190271366, ; 508: ExoPlayer.Decoder.dll => 0xbe27ad86 => 202
	i32 3192346100, ; 509: System.Security.SecureString => 0xbe4755f4 => 129
	i32 3193515020, ; 510: System.Web => 0xbe592c0c => 153
	i32 3204380047, ; 511: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 512: System.Xml.XmlDocument.dll => 0xbf506931 => 161
	i32 3211777861, ; 513: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 236
	i32 3220365878, ; 514: System.Threading => 0xbff2e236 => 148
	i32 3226221578, ; 515: System.Runtime.Handles.dll => 0xc04c3c0a => 104
	i32 3245644316, ; 516: Syncfusion.Maui.Charts.dll => 0xc1749a1c => 191
	i32 3251039220, ; 517: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 89
	i32 3258312781, ; 518: Xamarin.AndroidX.CardView => 0xc235e84d => 224
	i32 3265493905, ; 519: System.Linq.Queryable.dll => 0xc2a37b91 => 60
	i32 3265893370, ; 520: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 142
	i32 3277815716, ; 521: System.Resources.Writer.dll => 0xc35f7fa4 => 100
	i32 3279906254, ; 522: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 523: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3290767353, ; 524: System.Security.Cryptography.Encoding => 0xc4251ff9 => 122
	i32 3299363146, ; 525: System.Text.Encoding => 0xc4a8494a => 135
	i32 3303498502, ; 526: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 28
	i32 3305363605, ; 527: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 303
	i32 3316684772, ; 528: System.Net.Requests.dll => 0xc5b097e4 => 72
	i32 3317135071, ; 529: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 234
	i32 3317144872, ; 530: System.Data => 0xc5b79d28 => 24
	i32 3329734229, ; 531: ExoPlayer.Database => 0xc677b655 => 200
	i32 3340431453, ; 532: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 222
	i32 3345895724, ; 533: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 264
	i32 3346324047, ; 534: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 261
	i32 3357674450, ; 535: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 320
	i32 3358260929, ; 536: System.Text.Json => 0xc82afec1 => 137
	i32 3362336904, ; 537: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 215
	i32 3362522851, ; 538: Xamarin.AndroidX.Core => 0xc86c06e3 => 231
	i32 3366347497, ; 539: Java.Interop => 0xc8a662e9 => 168
	i32 3374999561, ; 540: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 265
	i32 3381016424, ; 541: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 299
	i32 3395150330, ; 542: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 101
	i32 3396979385, ; 543: ExoPlayer.Transformer.dll => 0xca79cab9 => 208
	i32 3403906625, ; 544: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 123
	i32 3405233483, ; 545: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 235
	i32 3428513518, ; 546: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 177
	i32 3429136800, ; 547: System.Xml => 0xcc6479a0 => 163
	i32 3430777524, ; 548: netstandard => 0xcc7d82b4 => 167
	i32 3441283291, ; 549: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 238
	i32 3445260447, ; 550: System.Formats.Tar => 0xcd5a809f => 39
	i32 3452344032, ; 551: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 184
	i32 3463511458, ; 552: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 307
	i32 3471940407, ; 553: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 554: Mono.Android => 0xcf3163e6 => 171
	i32 3479583265, ; 555: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 320
	i32 3484440000, ; 556: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 319
	i32 3485117614, ; 557: System.Text.Json.dll => 0xcfbaacae => 137
	i32 3486566296, ; 558: System.Transactions => 0xcfd0c798 => 150
	i32 3493954962, ; 559: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 227
	i32 3509114376, ; 560: System.Xml.Linq => 0xd128d608 => 155
	i32 3515174580, ; 561: System.Security.dll => 0xd1854eb4 => 130
	i32 3530912306, ; 562: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 563: System.Net.HttpListener => 0xd2ff69f1 => 65
	i32 3560100363, ; 564: System.Threading.Timer => 0xd432d20b => 147
	i32 3570554715, ; 565: System.IO.FileSystem.AccessControl => 0xd4d2575b => 47
	i32 3580758918, ; 566: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 327
	i32 3597029428, ; 567: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 213
	i32 3598340787, ; 568: System.Net.WebSockets.Client => 0xd67a52b3 => 79
	i32 3608519521, ; 569: System.Linq.dll => 0xd715a361 => 61
	i32 3624195450, ; 570: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 106
	i32 3627220390, ; 571: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 263
	i32 3633644679, ; 572: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 217
	i32 3638274909, ; 573: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 49
	i32 3641597786, ; 574: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 248
	i32 3643446276, ; 575: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 324
	i32 3643854240, ; 576: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 260
	i32 3645089577, ; 577: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3657292374, ; 578: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 176
	i32 3660523487, ; 579: System.Net.NetworkInformation => 0xda2f27df => 68
	i32 3672681054, ; 580: Mono.Android.dll => 0xdae8aa5e => 171
	i32 3682565725, ; 581: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 223
	i32 3684561358, ; 582: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 227
	i32 3697841164, ; 583: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 329
	i32 3700866549, ; 584: System.Net.WebProxy.dll => 0xdc96bdf5 => 78
	i32 3706696989, ; 585: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 232
	i32 3716563718, ; 586: System.Runtime.Intrinsics => 0xdd864306 => 108
	i32 3718780102, ; 587: Xamarin.AndroidX.Annotation => 0xdda814c6 => 216
	i32 3724971120, ; 588: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 259
	i32 3732100267, ; 589: System.Net.NameResolution => 0xde7354ab => 67
	i32 3737834244, ; 590: System.Net.Http.Json.dll => 0xdecad304 => 63
	i32 3748608112, ; 591: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3751444290, ; 592: System.Xml.XPath => 0xdf9a7f42 => 160
	i32 3772175043, ; 593: Syncfusion.Maui.Toolkit.resources => 0xe0d6d2c3 => 194
	i32 3786282454, ; 594: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 225
	i32 3792276235, ; 595: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3800979733, ; 596: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 184
	i32 3802395368, ; 597: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3819260425, ; 598: System.Net.WebProxy => 0xe3a54a09 => 78
	i32 3822602673, ; 599: Xamarin.AndroidX.Media => 0xe3d849b1 => 258
	i32 3823082795, ; 600: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3829621856, ; 601: System.Numerics.dll => 0xe4436460 => 83
	i32 3841636137, ; 602: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 178
	i32 3844307129, ; 603: System.Net.Mail.dll => 0xe52378b9 => 66
	i32 3849253459, ; 604: System.Runtime.InteropServices.dll => 0xe56ef253 => 107
	i32 3870376305, ; 605: System.Net.HttpListener.dll => 0xe6b14171 => 65
	i32 3873536506, ; 606: System.Security.Principal => 0xe6e179fa => 128
	i32 3875112723, ; 607: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 122
	i32 3885497537, ; 608: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 77
	i32 3885922214, ; 609: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 274
	i32 3888767677, ; 610: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 264
	i32 3889960447, ; 611: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 328
	i32 3896106733, ; 612: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 613: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 231
	i32 3901907137, ; 614: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3920810846, ; 615: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 44
	i32 3921031405, ; 616: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 277
	i32 3928044579, ; 617: System.Xml.ReaderWriter => 0xea213423 => 156
	i32 3930554604, ; 618: System.Security.Principal.dll => 0xea4780ec => 128
	i32 3931092270, ; 619: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 262
	i32 3945713374, ; 620: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 621: System.Text.Encoding.CodePages => 0xebac8bfe => 133
	i32 3955647286, ; 622: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 219
	i32 3959773229, ; 623: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 250
	i32 3980434154, ; 624: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 323
	i32 3987592930, ; 625: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 305
	i32 4003436829, ; 626: System.Diagnostics.Process.dll => 0xee9f991d => 29
	i32 4015948917, ; 627: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 218
	i32 4025784931, ; 628: System.Memory => 0xeff49a63 => 62
	i32 4046471985, ; 629: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 186
	i32 4054681211, ; 630: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 90
	i32 4068434129, ; 631: System.Private.Xml.Linq.dll => 0xf27f60d1 => 87
	i32 4073602200, ; 632: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4094352644, ; 633: Microsoft.Maui.Essentials.dll => 0xf40add04 => 188
	i32 4099507663, ; 634: System.Drawing.dll => 0xf45985cf => 36
	i32 4100113165, ; 635: System.Private.Uri => 0xf462c30d => 86
	i32 4101593132, ; 636: Xamarin.AndroidX.Emoji2 => 0xf479582c => 239
	i32 4102112229, ; 637: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 318
	i32 4125707920, ; 638: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 313
	i32 4126470640, ; 639: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 177
	i32 4127667938, ; 640: System.IO.FileSystem.Watcher => 0xf60736e2 => 50
	i32 4130442656, ; 641: System.AppContext => 0xf6318da0 => 6
	i32 4147896353, ; 642: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 90
	i32 4150914736, ; 643: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 325
	i32 4151237749, ; 644: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 645: System.Xml.XmlSerializer => 0xf7e95c85 => 162
	i32 4161255271, ; 646: System.Reflection.TypeExtensions => 0xf807b767 => 96
	i32 4164802419, ; 647: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 50
	i32 4173364138, ; 648: ExoPlayer.SmoothStreaming.dll => 0xf8c07baa => 207
	i32 4181436372, ; 649: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 113
	i32 4182413190, ; 650: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 255
	i32 4185676441, ; 651: System.Security => 0xf97c5a99 => 130
	i32 4190597220, ; 652: ExoPlayer.Core.dll => 0xf9c77064 => 198
	i32 4196529839, ; 653: System.Net.WebClient.dll => 0xfa21f6af => 76
	i32 4213026141, ; 654: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4256097574, ; 655: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 232
	i32 4258378803, ; 656: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 254
	i32 4260525087, ; 657: System.Buffers => 0xfdf2741f => 7
	i32 4271975918, ; 658: Microsoft.Maui.Controls.dll => 0xfea12dee => 185
	i32 4274976490, ; 659: System.Runtime.Numerics => 0xfecef6ea => 110
	i32 4292120959, ; 660: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 255
	i32 4294763496 ; 661: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 241
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [662 x i32] [
	i32 68, ; 0
	i32 67, ; 1
	i32 108, ; 2
	i32 194, ; 3
	i32 251, ; 4
	i32 288, ; 5
	i32 48, ; 6
	i32 80, ; 7
	i32 145, ; 8
	i32 30, ; 9
	i32 329, ; 10
	i32 124, ; 11
	i32 189, ; 12
	i32 102, ; 13
	i32 270, ; 14
	i32 107, ; 15
	i32 270, ; 16
	i32 139, ; 17
	i32 292, ; 18
	i32 77, ; 19
	i32 124, ; 20
	i32 13, ; 21
	i32 225, ; 22
	i32 192, ; 23
	i32 132, ; 24
	i32 272, ; 25
	i32 151, ; 26
	i32 326, ; 27
	i32 327, ; 28
	i32 18, ; 29
	i32 223, ; 30
	i32 26, ; 31
	i32 245, ; 32
	i32 1, ; 33
	i32 59, ; 34
	i32 42, ; 35
	i32 91, ; 36
	i32 191, ; 37
	i32 228, ; 38
	i32 287, ; 39
	i32 147, ; 40
	i32 247, ; 41
	i32 244, ; 42
	i32 298, ; 43
	i32 54, ; 44
	i32 199, ; 45
	i32 69, ; 46
	i32 326, ; 47
	i32 214, ; 48
	i32 83, ; 49
	i32 311, ; 50
	i32 246, ; 51
	i32 310, ; 52
	i32 131, ; 53
	i32 55, ; 54
	i32 149, ; 55
	i32 74, ; 56
	i32 145, ; 57
	i32 62, ; 58
	i32 146, ; 59
	i32 330, ; 60
	i32 165, ; 61
	i32 322, ; 62
	i32 229, ; 63
	i32 12, ; 64
	i32 242, ; 65
	i32 125, ; 66
	i32 200, ; 67
	i32 152, ; 68
	i32 113, ; 69
	i32 166, ; 70
	i32 164, ; 71
	i32 244, ; 72
	i32 257, ; 73
	i32 84, ; 74
	i32 309, ; 75
	i32 303, ; 76
	i32 183, ; 77
	i32 150, ; 78
	i32 292, ; 79
	i32 60, ; 80
	i32 179, ; 81
	i32 51, ; 82
	i32 103, ; 83
	i32 114, ; 84
	i32 40, ; 85
	i32 283, ; 86
	i32 281, ; 87
	i32 120, ; 88
	i32 317, ; 89
	i32 52, ; 90
	i32 44, ; 91
	i32 119, ; 92
	i32 197, ; 93
	i32 234, ; 94
	i32 315, ; 95
	i32 240, ; 96
	i32 81, ; 97
	i32 136, ; 98
	i32 277, ; 99
	i32 221, ; 100
	i32 8, ; 101
	i32 73, ; 102
	i32 297, ; 103
	i32 155, ; 104
	i32 294, ; 105
	i32 154, ; 106
	i32 92, ; 107
	i32 289, ; 108
	i32 45, ; 109
	i32 312, ; 110
	i32 300, ; 111
	i32 293, ; 112
	i32 109, ; 113
	i32 129, ; 114
	i32 25, ; 115
	i32 211, ; 116
	i32 72, ; 117
	i32 55, ; 118
	i32 46, ; 119
	i32 321, ; 120
	i32 182, ; 121
	i32 235, ; 122
	i32 22, ; 123
	i32 249, ; 124
	i32 199, ; 125
	i32 86, ; 126
	i32 43, ; 127
	i32 160, ; 128
	i32 71, ; 129
	i32 263, ; 130
	i32 3, ; 131
	i32 42, ; 132
	i32 63, ; 133
	i32 16, ; 134
	i32 53, ; 135
	i32 205, ; 136
	i32 324, ; 137
	i32 288, ; 138
	i32 203, ; 139
	i32 105, ; 140
	i32 293, ; 141
	i32 284, ; 142
	i32 246, ; 143
	i32 34, ; 144
	i32 158, ; 145
	i32 85, ; 146
	i32 32, ; 147
	i32 12, ; 148
	i32 51, ; 149
	i32 56, ; 150
	i32 267, ; 151
	i32 36, ; 152
	i32 209, ; 153
	i32 178, ; 154
	i32 299, ; 155
	i32 285, ; 156
	i32 219, ; 157
	i32 35, ; 158
	i32 58, ; 159
	i32 253, ; 160
	i32 174, ; 161
	i32 17, ; 162
	i32 290, ; 163
	i32 164, ; 164
	i32 312, ; 165
	i32 252, ; 166
	i32 181, ; 167
	i32 280, ; 168
	i32 206, ; 169
	i32 318, ; 170
	i32 153, ; 171
	i32 276, ; 172
	i32 261, ; 173
	i32 316, ; 174
	i32 221, ; 175
	i32 29, ; 176
	i32 52, ; 177
	i32 314, ; 178
	i32 281, ; 179
	i32 5, ; 180
	i32 298, ; 181
	i32 286, ; 182
	i32 271, ; 183
	i32 275, ; 184
	i32 226, ; 185
	i32 294, ; 186
	i32 218, ; 187
	i32 237, ; 188
	i32 85, ; 189
	i32 201, ; 190
	i32 280, ; 191
	i32 61, ; 192
	i32 112, ; 193
	i32 57, ; 194
	i32 328, ; 195
	i32 267, ; 196
	i32 99, ; 197
	i32 258, ; 198
	i32 19, ; 199
	i32 230, ; 200
	i32 287, ; 201
	i32 111, ; 202
	i32 101, ; 203
	i32 102, ; 204
	i32 296, ; 205
	i32 104, ; 206
	i32 284, ; 207
	i32 71, ; 208
	i32 38, ; 209
	i32 32, ; 210
	i32 193, ; 211
	i32 103, ; 212
	i32 73, ; 213
	i32 302, ; 214
	i32 9, ; 215
	i32 123, ; 216
	i32 46, ; 217
	i32 220, ; 218
	i32 183, ; 219
	i32 9, ; 220
	i32 201, ; 221
	i32 43, ; 222
	i32 4, ; 223
	i32 268, ; 224
	i32 306, ; 225
	i32 301, ; 226
	i32 31, ; 227
	i32 138, ; 228
	i32 92, ; 229
	i32 93, ; 230
	i32 321, ; 231
	i32 49, ; 232
	i32 141, ; 233
	i32 112, ; 234
	i32 0, ; 235
	i32 140, ; 236
	i32 236, ; 237
	i32 115, ; 238
	i32 285, ; 239
	i32 157, ; 240
	i32 76, ; 241
	i32 79, ; 242
	i32 256, ; 243
	i32 37, ; 244
	i32 279, ; 245
	i32 240, ; 246
	i32 233, ; 247
	i32 173, ; 248
	i32 64, ; 249
	i32 138, ; 250
	i32 15, ; 251
	i32 116, ; 252
	i32 273, ; 253
	i32 282, ; 254
	i32 228, ; 255
	i32 48, ; 256
	i32 70, ; 257
	i32 80, ; 258
	i32 126, ; 259
	i32 94, ; 260
	i32 121, ; 261
	i32 291, ; 262
	i32 208, ; 263
	i32 26, ; 264
	i32 249, ; 265
	i32 97, ; 266
	i32 28, ; 267
	i32 224, ; 268
	i32 319, ; 269
	i32 297, ; 270
	i32 149, ; 271
	i32 169, ; 272
	i32 4, ; 273
	i32 98, ; 274
	i32 33, ; 275
	i32 198, ; 276
	i32 93, ; 277
	i32 272, ; 278
	i32 179, ; 279
	i32 0, ; 280
	i32 21, ; 281
	i32 41, ; 282
	i32 170, ; 283
	i32 313, ; 284
	i32 242, ; 285
	i32 305, ; 286
	i32 256, ; 287
	i32 290, ; 288
	i32 282, ; 289
	i32 262, ; 290
	i32 2, ; 291
	i32 134, ; 292
	i32 111, ; 293
	i32 180, ; 294
	i32 325, ; 295
	i32 211, ; 296
	i32 322, ; 297
	i32 58, ; 298
	i32 95, ; 299
	i32 304, ; 300
	i32 39, ; 301
	i32 222, ; 302
	i32 25, ; 303
	i32 94, ; 304
	i32 89, ; 305
	i32 99, ; 306
	i32 10, ; 307
	i32 197, ; 308
	i32 87, ; 309
	i32 100, ; 310
	i32 269, ; 311
	i32 175, ; 312
	i32 291, ; 313
	i32 205, ; 314
	i32 213, ; 315
	i32 301, ; 316
	i32 7, ; 317
	i32 253, ; 318
	i32 296, ; 319
	i32 210, ; 320
	i32 88, ; 321
	i32 248, ; 322
	i32 154, ; 323
	i32 300, ; 324
	i32 33, ; 325
	i32 116, ; 326
	i32 82, ; 327
	i32 202, ; 328
	i32 209, ; 329
	i32 20, ; 330
	i32 11, ; 331
	i32 162, ; 332
	i32 3, ; 333
	i32 187, ; 334
	i32 308, ; 335
	i32 182, ; 336
	i32 180, ; 337
	i32 84, ; 338
	i32 295, ; 339
	i32 64, ; 340
	i32 195, ; 341
	i32 310, ; 342
	i32 276, ; 343
	i32 143, ; 344
	i32 207, ; 345
	i32 257, ; 346
	i32 157, ; 347
	i32 41, ; 348
	i32 117, ; 349
	i32 176, ; 350
	i32 212, ; 351
	i32 304, ; 352
	i32 265, ; 353
	i32 131, ; 354
	i32 75, ; 355
	i32 66, ; 356
	i32 314, ; 357
	i32 172, ; 358
	i32 216, ; 359
	i32 143, ; 360
	i32 106, ; 361
	i32 151, ; 362
	i32 70, ; 363
	i32 190, ; 364
	i32 156, ; 365
	i32 175, ; 366
	i32 121, ; 367
	i32 127, ; 368
	i32 309, ; 369
	i32 152, ; 370
	i32 239, ; 371
	i32 141, ; 372
	i32 226, ; 373
	i32 306, ; 374
	i32 20, ; 375
	i32 14, ; 376
	i32 173, ; 377
	i32 135, ; 378
	i32 75, ; 379
	i32 59, ; 380
	i32 229, ; 381
	i32 167, ; 382
	i32 168, ; 383
	i32 195, ; 384
	i32 185, ; 385
	i32 15, ; 386
	i32 74, ; 387
	i32 6, ; 388
	i32 23, ; 389
	i32 251, ; 390
	i32 196, ; 391
	i32 210, ; 392
	i32 91, ; 393
	i32 307, ; 394
	i32 1, ; 395
	i32 136, ; 396
	i32 252, ; 397
	i32 275, ; 398
	i32 134, ; 399
	i32 69, ; 400
	i32 146, ; 401
	i32 316, ; 402
	i32 295, ; 403
	i32 243, ; 404
	i32 181, ; 405
	i32 88, ; 406
	i32 96, ; 407
	i32 233, ; 408
	i32 238, ; 409
	i32 206, ; 410
	i32 311, ; 411
	i32 31, ; 412
	i32 45, ; 413
	i32 247, ; 414
	i32 212, ; 415
	i32 109, ; 416
	i32 158, ; 417
	i32 35, ; 418
	i32 22, ; 419
	i32 114, ; 420
	i32 57, ; 421
	i32 273, ; 422
	i32 204, ; 423
	i32 144, ; 424
	i32 118, ; 425
	i32 120, ; 426
	i32 110, ; 427
	i32 214, ; 428
	i32 139, ; 429
	i32 220, ; 430
	i32 54, ; 431
	i32 105, ; 432
	i32 317, ; 433
	i32 186, ; 434
	i32 187, ; 435
	i32 133, ; 436
	i32 289, ; 437
	i32 278, ; 438
	i32 266, ; 439
	i32 323, ; 440
	i32 243, ; 441
	i32 203, ; 442
	i32 189, ; 443
	i32 159, ; 444
	i32 302, ; 445
	i32 230, ; 446
	i32 163, ; 447
	i32 132, ; 448
	i32 266, ; 449
	i32 161, ; 450
	i32 315, ; 451
	i32 254, ; 452
	i32 140, ; 453
	i32 278, ; 454
	i32 274, ; 455
	i32 169, ; 456
	i32 188, ; 457
	i32 190, ; 458
	i32 215, ; 459
	i32 193, ; 460
	i32 283, ; 461
	i32 40, ; 462
	i32 241, ; 463
	i32 81, ; 464
	i32 56, ; 465
	i32 37, ; 466
	i32 97, ; 467
	i32 166, ; 468
	i32 172, ; 469
	i32 279, ; 470
	i32 82, ; 471
	i32 217, ; 472
	i32 98, ; 473
	i32 30, ; 474
	i32 159, ; 475
	i32 18, ; 476
	i32 286, ; 477
	i32 127, ; 478
	i32 119, ; 479
	i32 237, ; 480
	i32 269, ; 481
	i32 250, ; 482
	i32 271, ; 483
	i32 165, ; 484
	i32 245, ; 485
	i32 196, ; 486
	i32 330, ; 487
	i32 268, ; 488
	i32 259, ; 489
	i32 170, ; 490
	i32 16, ; 491
	i32 144, ; 492
	i32 308, ; 493
	i32 125, ; 494
	i32 118, ; 495
	i32 38, ; 496
	i32 115, ; 497
	i32 47, ; 498
	i32 142, ; 499
	i32 117, ; 500
	i32 204, ; 501
	i32 34, ; 502
	i32 192, ; 503
	i32 174, ; 504
	i32 95, ; 505
	i32 53, ; 506
	i32 260, ; 507
	i32 202, ; 508
	i32 129, ; 509
	i32 153, ; 510
	i32 24, ; 511
	i32 161, ; 512
	i32 236, ; 513
	i32 148, ; 514
	i32 104, ; 515
	i32 191, ; 516
	i32 89, ; 517
	i32 224, ; 518
	i32 60, ; 519
	i32 142, ; 520
	i32 100, ; 521
	i32 5, ; 522
	i32 13, ; 523
	i32 122, ; 524
	i32 135, ; 525
	i32 28, ; 526
	i32 303, ; 527
	i32 72, ; 528
	i32 234, ; 529
	i32 24, ; 530
	i32 200, ; 531
	i32 222, ; 532
	i32 264, ; 533
	i32 261, ; 534
	i32 320, ; 535
	i32 137, ; 536
	i32 215, ; 537
	i32 231, ; 538
	i32 168, ; 539
	i32 265, ; 540
	i32 299, ; 541
	i32 101, ; 542
	i32 208, ; 543
	i32 123, ; 544
	i32 235, ; 545
	i32 177, ; 546
	i32 163, ; 547
	i32 167, ; 548
	i32 238, ; 549
	i32 39, ; 550
	i32 184, ; 551
	i32 307, ; 552
	i32 17, ; 553
	i32 171, ; 554
	i32 320, ; 555
	i32 319, ; 556
	i32 137, ; 557
	i32 150, ; 558
	i32 227, ; 559
	i32 155, ; 560
	i32 130, ; 561
	i32 19, ; 562
	i32 65, ; 563
	i32 147, ; 564
	i32 47, ; 565
	i32 327, ; 566
	i32 213, ; 567
	i32 79, ; 568
	i32 61, ; 569
	i32 106, ; 570
	i32 263, ; 571
	i32 217, ; 572
	i32 49, ; 573
	i32 248, ; 574
	i32 324, ; 575
	i32 260, ; 576
	i32 14, ; 577
	i32 176, ; 578
	i32 68, ; 579
	i32 171, ; 580
	i32 223, ; 581
	i32 227, ; 582
	i32 329, ; 583
	i32 78, ; 584
	i32 232, ; 585
	i32 108, ; 586
	i32 216, ; 587
	i32 259, ; 588
	i32 67, ; 589
	i32 63, ; 590
	i32 27, ; 591
	i32 160, ; 592
	i32 194, ; 593
	i32 225, ; 594
	i32 10, ; 595
	i32 184, ; 596
	i32 11, ; 597
	i32 78, ; 598
	i32 258, ; 599
	i32 126, ; 600
	i32 83, ; 601
	i32 178, ; 602
	i32 66, ; 603
	i32 107, ; 604
	i32 65, ; 605
	i32 128, ; 606
	i32 122, ; 607
	i32 77, ; 608
	i32 274, ; 609
	i32 264, ; 610
	i32 328, ; 611
	i32 8, ; 612
	i32 231, ; 613
	i32 2, ; 614
	i32 44, ; 615
	i32 277, ; 616
	i32 156, ; 617
	i32 128, ; 618
	i32 262, ; 619
	i32 23, ; 620
	i32 133, ; 621
	i32 219, ; 622
	i32 250, ; 623
	i32 323, ; 624
	i32 305, ; 625
	i32 29, ; 626
	i32 218, ; 627
	i32 62, ; 628
	i32 186, ; 629
	i32 90, ; 630
	i32 87, ; 631
	i32 148, ; 632
	i32 188, ; 633
	i32 36, ; 634
	i32 86, ; 635
	i32 239, ; 636
	i32 318, ; 637
	i32 313, ; 638
	i32 177, ; 639
	i32 50, ; 640
	i32 6, ; 641
	i32 90, ; 642
	i32 325, ; 643
	i32 21, ; 644
	i32 162, ; 645
	i32 96, ; 646
	i32 50, ; 647
	i32 207, ; 648
	i32 113, ; 649
	i32 255, ; 650
	i32 130, ; 651
	i32 198, ; 652
	i32 76, ; 653
	i32 27, ; 654
	i32 232, ; 655
	i32 254, ; 656
	i32 7, ; 657
	i32 185, ; 658
	i32 110, ; 659
	i32 255, ; 660
	i32 241 ; 661
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.2xx @ 96b6bb65e8736e45180905177aa343f0e1854ea3"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
