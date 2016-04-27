
# Android应用增量更新、省流量升级、补丁生成与应用 - Incremental Update

------

## 介绍

这是一个用于Android应用程序增量更新的库。包括客户端、服务端，其中服务器端又分为c/s、b/s两部分代码。

## 为什么会有增量更新？  
智能手机发展到现在，已经有成千上万的APP,这些APP的安装包也越来越大，小则几M，多则几十M甚至上百M。传统方式更新APP需要下载APP的完整包。如果安装包比较大，用户在更新APP的时候不仅等待的时间长，而且很消耗流量(二十一世纪最贵的莫非是流量了)。所以说用户很不愿意将APP更新到最新版本。
1. 对于用户来说下载完整包进行更新费流量，且等待时间长。
2. 对于每次版本迭代本身来说，一般是修复BUG，添加一些新功能，这些所产生的增量很小。
3. 对于APP的所有者来说，希望将用户使用的是最新的APP。

（有需求就有市场）增量更新便解决了这些痛点。

## 原理

增量更新不是什么黑科技，而是对原有技术的新应用，就像AJAX。

现在越来越多的应用市场开始支持增量更新，比如百度手机助手，小米应用市场，华为应用市场等。

增量更新的原理，就是将手机上已安装apk与服务器端最新apk进行二进制对比，得到增量包，用户更新程序时，只需要下载增量包，并在本地使用增量包与已安装apk，合成新版apk。

例如，当前手机中已安装APPV1，大小为10MB，现在APP发布了最新版V2，大小为12.6MB，我们对两个版本的apk文件增量比对之后，发现差异只有2M，那么用户就只需要要下载一个2M的增量包，使用旧版apk与这个增量包，合成得到一个新版本apk，提醒用户安装即可，不需要整包下载12.6M的APPV2版apk。

apk文件的增量、合成，可以通过 [开源的二进制比较工具 bsdiff] 来实现，又因为bsdiff依赖bzip2，所以我们还需要用到 [bzip2]

bsdiff中，`bsdiff.c` 用于生成增量包，`bspatch.c` 用于合成文件。 

弄清楚原理之后，我们想实现增量更新，共需要做3件事：

* 在服务器端，生成两个版本apk的增量包； 

* 在手机客户端，使用已安装的apk与这个增量包进行合成，得到新版的微博apk； 

* 校验新合成的apk文件是否完整，MD5或SHA1是否正确，如正确，则引导用户安装；

## 过程分析

### 1 生成增量包

这一步需要在服务器端来实现，一般来说，每当apk有新版本需要提示用户升级，都需要运营人员在后台管理端上传新apk，上传时就应该由程序生成与之前所有旧版本们与最新版的增量包。 

例如：
你的apk已经发布了3个版，V1.0、V2.0、V3.0，这时候你要在后台发布V4.0，那么，当你在服务器上传最新的V4.0包时，服务器端就应该立即生成以下增量包：

 1. V1.0 ——> V4.0的增量包；
 2. V2.0 ——> V4.0的增量包；
 3. V3.0 ——> V4.0的增量包；

ApkPatchLibraryServer 工程即为 Java 语言实现的服务器端增量程序。

下面对ApkPatchLibraryServer做一些简单说明：

#### 1.1 C部分

ApkPatchLibraryServer/jni 中，除了以下4个：

>com_jph_utils_DiffUtils.c

>com_jph_utils_DiffUtils.h

>com_jph_utils_PatchUtils.c

>com_jph_utils_PatchUtils.h

jni/bzip2目录中的文件，全部来自bzip2项目。

>com_jph_utils_DiffUtils.c

>com_jph_utils_DiffUtils.h

用于生成增量包。

>com_jph_utils_PatchUtils.c

>com_jph_utils_PatchUtils.h

用于合成新apk文件。

`com_jph_utils_DiffUtils.c` 修改自 `bsdiff/bsdiff.c`，`com_jph_utils_PatchUtils.c`修改自`bsdiff/bspatch.c`。

我们在需要将jni中的C文件，build输出为动态链接库，以供Java调用（Window环境下生成的文件名为libApkPatchLibraryServer.dll，Unix-like系统下为libApkPatchLibraryServer.so，OSX下为libApkPatchLibraryServer.dylib）。

Build成功后，将该动态链接库文件，加入环境变量，供Java语言调用。

`com_jph_utils_DiffUtils.c` 中 `Java_com_jph_utils_DiffUtils_genDiff()` 方法，用于生成增量包的：

```C

JNIEXPORT jint JNICALL Java_com_jph_utils_DiffUtils_genDiff(JNIEnv *env,
		jclass cls, jstring old, jstring new, jstring patch) {
	int argc = 4;
	char * argv[argc];
	argv[0] = "bsdiff";
	argv[1] = (char*) ((*env)->GetStringUTFChars(env, old, 0));
	argv[2] = (char*) ((*env)->GetStringUTFChars(env, new, 0));
	argv[3] = (char*) ((*env)->GetStringUTFChars(env, patch, 0));

	printf("old apk = %s \n", argv[1]);
	printf("new apk = %s \n", argv[2]);
	printf("patch = %s \n", argv[3]);

	int ret = genpatch(argc, argv);

	printf("genDiff result = %d ", ret);

	(*env)->ReleaseStringUTFChars(env, old, argv[1]);
	(*env)->ReleaseStringUTFChars(env, new, argv[2]);
	(*env)->ReleaseStringUTFChars(env, patch, argv[3]);

	return ret;
}

```
`com_jph_utils_PatchUtils.c` 中 `Java_com_jph_utils_PatchUtils_patch()` 方法，用于合成新的APK；

```C
JNIEXPORT jint JNICALL Java_com_jph_utils_PatchUtils_patch
  (JNIEnv *env, jclass cls,
			jstring old, jstring new, jstring patch){
	int argc = 4;
	char * argv[argc];
	argv[0] = "bspatch";
	argv[1] = (char*) ((*env)->GetStringUTFChars(env, old, 0));
	argv[2] = (char*) ((*env)->GetStringUTFChars(env, new, 0));
	argv[3] = (char*) ((*env)->GetStringUTFChars(env, patch, 0));

	printf("old apk = %s \n", argv[1]);
	printf("patch = %s \n", argv[3]);
	printf("new apk = %s \n", argv[2]);

	int ret = applypatch(argc, argv);

	printf("patch result = %d ", ret);

	(*env)->ReleaseStringUTFChars(env, old, argv[1]);
	(*env)->ReleaseStringUTFChars(env, new, argv[2]);
	(*env)->ReleaseStringUTFChars(env, patch, argv[3]);
	return ret;
}
```

#### 1.2 Java部分

com.jph.utils包，为调用C语言的Java实现；
com.jph.apkdiff包，为apk增量程序的Demo；
com.jph.apkpatch包，为apk合并程序的Demo；

调用，`com.jph.utils.DiffUtils`中`genDiff()`方法，可以通过传入的新旧apk路径，得到增量包。 

```java
/**
 * 类说明： 	APK Diff工具类
 * 
 * @author     jph
 * @date 	      2013-9-6
 * @version  1.0
 */
public class DiffUtils {

	/**
	 * native方法 比较路径为oldPath的apk与newPath的apk之间差异，并生成patch包，存储于patchPath
	 * 
	 * 返回：0，说明操作成功
	 *  
	 * @param oldApkPath 示例:/sdcard/old.apk
	 * @param newApkPath 示例:/sdcard/new.apk
	 * @param patchPath  示例:/sdcard/xx.patch
	 * @return
	 */
	public static native int genDiff(String oldApkPath, String newApkPath, String patchPath);
}
```

调用，`com.jph.utils.PatchUtils`中`patch()`方法，可以通过旧apk与增量包，合成为新apk。

```java
/**
 * 类说明： 	APK Patch工具类
 * 
 * @author    jph
 * @date 	     2013-9-6
 * @version 1.0
 */
public class PatchUtils {

	/**
	 * native方法 使用路径为oldApkPath的apk与路径为patchPath的补丁包，合成新的apk，并存储于newApkPath
	 * 
	 * 返回：0，说明操作成功
	 * 
	 * @param oldApkPath 示例:/sdcard/old.apk
	 * @param newApkPath 示例:/sdcard/new.apk
	 * @param patchPath  示例:/sdcard/xx.patch
	 * @return
	 */
	public static native int patch(String oldApkPath, String newApkPath,
			String patchPath);
}
```

### 2.使用旧版apk与增量包，在客户端合成新apk

需要在手机客户端实现，ApkPatchLibrary 工程封装了这个过程。

#### 2.1 C部分
同ApkPatchLibraryServer工程一样，ApkPatchLibrary/jni/bzip2 目录中所有文件都来自bzip2项目。

`ApkPatchLibrary/jni/com_jph_utils_PatchUtils.c`、`ApkPatchLibrary/jni/com_jph_utils_PatchUtils.c`实现文件的合并过程，其中`com_jph_utils_PatchUtils.c`修改自`bsdiff/bspatch.c`。

我们需要用NDK编译出一个libApkPatchLibrary.so文件，生成的so文件位于libs/armeabi/ 下，其他 Android 工程便可以使用该libApkPatchLibrary.so文件来合成apk（如果需要支持多种CPU架构需要自己配置）。

`com_jph_utils_PatchUtils.Java_com_jph_utils_PatchUtils_patch()`方法，即为生成增量包的代码：

```C
/*
 * Class:     com_jph_utils_PatchUtils
 * Method:    patch
 * Signature: (Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I
 */
JNIEXPORT jint JNICALL Java_com_jph_utils_PatchUtils_patch(JNIEnv *env,
		jobject obj, jstring old, jstring new, jstring patch) {

	char * ch[4];
	ch[0] = "bspatch";
	ch[1] = (char*) ((*env)->GetStringUTFChars(env, old, 0));
	ch[2] = (char*) ((*env)->GetStringUTFChars(env, new, 0));
	ch[3] = (char*) ((*env)->GetStringUTFChars(env, patch, 0));

	__android_log_print(ANDROID_LOG_INFO, "ApkPatchLibrary", "old = %s ", ch[1]);
	__android_log_print(ANDROID_LOG_INFO, "ApkPatchLibrary", "new = %s ", ch[2]);
	__android_log_print(ANDROID_LOG_INFO, "ApkPatchLibrary", "patch = %s ", ch[3]);

	int ret = applypatch(4, ch);

	__android_log_print(ANDROID_LOG_INFO, "ApkPatchLibrary", "applypatch result = %d ", ret);

	(*env)->ReleaseStringUTFChars(env, old, ch[1]);
	(*env)->ReleaseStringUTFChars(env, new, ch[2]);
	(*env)->ReleaseStringUTFChars(env, patch, ch[3]);

	return ret;
}
```

#### 2.2 Java部分

com.jph.utils包，为调用C语言的Java实现；

调用，`com.jph.utils.PatchUtils中patch()`方法，可以通过旧apk与增量包，合成为新apk。

```java
/**
 * 类说明： 	APK Patch工具类
 * 
 * @author   jph
 * @date      2013-9-6
 * @version 1.0
 */
public class PatchUtils {

	/**
	 * native方法 使用路径为oldApkPath的apk与路径为patchPath的补丁包，合成新的apk，并存储于     newApkPath
	 * 
	 * 返回：0，说明操作成功
	 * 
	 * @param oldApkPath 示例:/sdcard/old.apk
	 * @param newApkPath 示例:/sdcard/new.apk
	 * @param patchPath  示例:/sdcard/xx.patch
	 * @return
	 */
	public static native int patch(String oldApkPath, String newApkPath,
			String patchPath);
}
```

### 3.校验新合成的apk文件

在执行patch之前，需要先读取本地安装旧版本APK的MD5或SHA1，判断当前安装的文件是否为合法版本，同样，patch得到新包之后，也需要对它进行MD5或SHA1校验，校验失败，说明合成过程有问题。

## 注意事项

增量更新的前提条件，是在手机客户端能让我们读取到当前应用程序安装后的源apk，如果获取不到源apk，那么就无法进行增量更新了，另外，如果你的应用程序不是很大，比如只有2、3M，那么完全没有必要使用增量更新，增量更新只适用于apk包比较大的情况，比如手机游戏客户端。

## 一些说明

* ApkPatchLibraryServer：服务器端生成增量包工程，使用Java实现；

* ApkPatchLibrary：客户端使用的apk合成库，用于生成libApkPatchLibrary.so，使用Eclipse开发；

* ApkPatchLibrarySample：一个Sample，手机上安装 Weibo5.5.apk，通过与SD卡上预先存放的weibo.patch文件进行合并，得到Weibo5.6.apk，使用AndroidStudio开发。 

* 二进制增量或许有更好的实现方案，如：xdelta；

另外， ApkPatchLibraryServer、ApkPatchLibrarySample 中用到的Weibo5.5.apk，Weibo5.6.apk，以及使用ApkPatchLibraryServer生成的增量包(Weibo5.5.apk->Weibo5.6.apk)， [都通过云盘共享了][5]。


