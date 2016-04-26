package com.jph.iu.server.util;

import java.io.File;
import java.io.UnsupportedEncodingException;
import javax.servlet.http.HttpServletRequest;

/**
 * 生成增量包工具类
 * 
 * @author Penn
 */
public class PatchFile {
	private String bsdiffPath;
	private File oldFile;
	private File newFile;
	private File patchFile;
	private boolean isApplyPatch;
	public PatchFile(HttpServletRequest request,boolean isApplyPatch) {
		init(request,isApplyPatch);
	}
	private void init(HttpServletRequest request,boolean isApplyPatch) {
		this.isApplyPatch=isApplyPatch;
		try {
			request.setCharacterEncoding("UTF-8");
		} catch (UnsupportedEncodingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		StringBuffer bsdiffPathSb=new StringBuffer();
		bsdiffPathSb.append("\"");
		bsdiffPathSb.append(request.getSession().getServletContext().getRealPath(""));
		bsdiffPathSb.append("WEB-INF/lib/");
		bsdiffPathSb.append(isApplyPatch?"bspatch.exe":"bsdiff.exe");
		bsdiffPathSb.append("\"");
		bsdiffPath=bsdiffPathSb.toString();
		oldFile=new File(request.getParameter("oldFile"));
		newFile=new File(request.getParameter("newFile"));
	}
	public boolean patch() {
		patchFile=new File(oldFile.getParentFile(), genPachFileName());
		Runtime rn = Runtime.getRuntime();
		Process p = null;
		try {
			StringBuffer path = new StringBuffer();
			path.append(bsdiffPath);
			path.append("  ");
			path.append(oldFile.getAbsolutePath());
			path.append("  ");
			if (isApplyPatch) {
				path.append(patchFile);
				path.append("  ");
				path.append(newFile.getAbsolutePath());
			}else {
				path.append(newFile.getAbsolutePath());
				path.append("  ");
				path.append(patchFile);
			}
			
			System.out.println("----------start patch----------");
			p = rn.exec(path.toString());
			p.waitFor();		
			System.out.println("----------end patch----------");
		} catch (Exception e) {
			System.out.println("Error my exec ");
			return false;
		}
		return true;
	}
	private String genPachFileName() {
		StringBuffer sb=new StringBuffer();
		String oldFileName=oldFile.getName();
		String newFileName=newFile.getName();
		sb.append(oldFileName.substring(0,oldFileName.lastIndexOf(".")));
		sb.append("_");
		sb.append(newFileName.substring(0,newFileName.lastIndexOf(".")));
		sb.append(isApplyPatch?oldFileName.substring(oldFileName.lastIndexOf(".")):".patch");
		return sb.toString();
	}

}
