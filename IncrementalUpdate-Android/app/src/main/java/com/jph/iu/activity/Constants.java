package com.jph.iu.activity;

import java.io.File;

import android.os.Environment;

/**
 * 常量类
 * @author 	JPH
 */
public class Constants {

	public static final boolean DEBUG = true;

	//KSD接单(V1.0.7).apk 正确的MD5值，如果本地安装的apk MD5值不是TA，说明本地安装的是被二次打包的apk
	public static final String KSD_OLD_MD5 = "6da2aaa9a5acfbbff2a8f6466e81ba6c";

	//KSD接单(V1.0.8).apk正确的MD5值
	public static final String KSD_NEW_MD5 = "7a333adaadfa08bd707e9b0b86a973e7";

	//用于测试的packageName
	public static final String TEST_PACKAGENAME = "com.ksudi.shuttle";

	public static final String PATH = Environment.getExternalStorageDirectory() + File.separator;

	//合成得到的新版apk
	public static final String NEW_APK_PATH = PATH + "KSD接单_new.apk";

	//从服务器下载来的差分包
	public static final String PATCH_PATH = PATH + "KSD接单.patch";
//	public static final String PATCH_PATH = PATH + "weibo.patch";
}